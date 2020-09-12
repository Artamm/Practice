package Controller;

import DBConnection.DBClass;
import Data.Book;
import Data.Review;
import Data.User;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.pdf.PdfWriter;
import com.itextpdf.tool.xml.XMLWorkerHelper;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.CheckBox;
import javafx.scene.control.ComboBox;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;

import java.awt.*;
import java.io.*;
import java.sql.*;
import java.util.Iterator;
import java.util.List;


public class ControllerReviews {
    @FXML private GridPane sceneForReviews;

    @FXML private ComboBox users;
    private ObservableList<Integer>userOption= FXCollections.observableArrayList();

    @FXML private ComboBox bookCombox;
    @FXML private ComboBox ratings;
    @FXML private CheckBox dTheme;
    private Connection conn = null;
    private DBClass objDbClass = new DBClass();

    @FXML private TableView<Review> tableReview;
    @FXML private TableColumn<Review,Integer> reviewId;
    @FXML private TableColumn<Review,String> book;
    @FXML private TableColumn<Review,Integer> userId;
    @FXML private TableColumn<Review,Integer> rate;
    @FXML private TableColumn<Review,String> date;


    ControllerAddReview add_review;

    /*connection*/
    private static SessionFactory factory;
    private static final ServiceRegistry serviceRegistry;

    static {
        try {
            Configuration configuration = new Configuration();
            configuration.configure();

            serviceRegistry = new ServiceRegistryBuilder().applySettings(configuration.getProperties()).buildServiceRegistry();
            factory = configuration.buildSessionFactory(serviceRegistry);
        } catch (Throwable ex) {
            throw new ExceptionInInitializerError(ex);
        }
    }  //Hibernate configurations

    /*Menu control */
    public Stage openBookScene(ActionEvent actionEvent) {
        controlMethods sbutton = new controlMethods();
        return sbutton.setScene("/fxml/vBooks.fxml");
    }

    public Stage openUsersScene(ActionEvent actionEvent) {
        controlMethods sbutton = new controlMethods();
        return sbutton.setScene("/fxml/vUsers.fxml");
    }

    public Stage openUsersBooks(ActionEvent actionEvent) {
        controlMethods sbutton = new controlMethods();
        return sbutton.setScene("/fxml/vUser_books.fxml");

    }

    public Stage openReviewScene(ActionEvent actionEvent) {
        Stage bookStage =new Stage();
        ControllerReviews reviews;

        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/fxml/vReviews_.fxml"));
            Parent root= loader.load();
            reviews= loader.<ControllerReviews>getController();
            Scene book = new Scene(root);
            bookStage.setScene(book);
            reviews.printData(actionEvent); //uploads data in Comboboxes from DB
            bookStage.showAndWait();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return bookStage;
    }

    public void setdTheme(ActionEvent actionEvent) {
        controlMethods dbutton = new controlMethods();
        dbutton.setdTheme(dTheme,sceneForReviews);
    }


    public void AddData() {
        ObservableList<Review> reviews=  FXCollections.observableArrayList();
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            Query query = session.createQuery("from Data.Review");
            List booky= query.list();
            for (Iterator iterator = booky.iterator(); iterator.hasNext();) {
                Review bookTable = (Review) iterator.next();
                reviews.add(bookTable);
            }
           reviewId.setCellValueFactory(new PropertyValueFactory<Review,Integer>("id"));
            book.setCellValueFactory(new PropertyValueFactory<Review,String>("book"));
            userId.setCellValueFactory(new PropertyValueFactory<Review,Integer>("user_id"));
            rate.setCellValueFactory(new PropertyValueFactory<Review,Integer>("rate"));
            date.setCellValueFactory(new PropertyValueFactory<Review,String>("date"));

        tableReview.setItems(reviews);
        tableReview.setVisible(true);


            tx.commit();
        }
        catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }

    }
    public void initialize(){
        try {
            conn= objDbClass.getConnection();
            System.out.println("Connected!");
            AddData();

        } catch (Exception ex) {
            ex.printStackTrace();

        }

    }

    public void printData(ActionEvent actionEvent) {
        fillUserBox();
        fillBookBox();
    }

    public void DeleteData(ActionEvent actionEvent) {
        Review review =(Review)tableReview.getSelectionModel().getSelectedItem();
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            session.delete(review);
            tx.commit();
        }
        catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
            AddData();
        }

    }

    public Stage openEdit(ActionEvent actionEvent) {
        Stage bookStage =new Stage();
        ControllerEditReview edit_review;

        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/fxml/vReviewEdit.fxml"));
            Parent root= loader.load();
            edit_review= loader.<ControllerEditReview>getController();
            Scene book = new Scene(root);
            bookStage.setScene(book);
            edit_review.printData(actionEvent); //uploads data in Comboboxes from DB
            Review review =(Review)tableReview.getSelectionModel().getSelectedItem();
            edit_review.getEditor().setHtmlText(review.getText());
            edit_review.setReview(review);
            bookStage.show();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return bookStage;

    }


    public void DeleteAllData(ActionEvent actionEvent) {
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            Query query = session.createQuery("delete from Data.Review");
            query.executeUpdate();
            tx.commit();
        }
        catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
            AddData();
        }
    }

    public void fillUserBox(){

        /* Print from DB*/
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();

            Query query= session.createQuery( "Select r.user_id from Data.Review r");
            List user= query.list();
            for (Iterator iterator = user.iterator(); iterator.hasNext();) {
                userOption.add((int)iterator.next());
            }

            users.setItems(userOption);
            users.setVisible(true);
            tx.commit();
        }
        catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }
    }

    public void fillBookBox(){
        ObservableList<String>booksCombo = FXCollections.observableArrayList();;

/* Print from DB*/
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();

            Query query= session.createQuery( "Select r.book from Data.Review r");
            List book= query.list();
            for (Iterator iterator = book.iterator(); iterator.hasNext();) {
                booksCombo.add((String)iterator.next());
            }
            bookCombox.setItems(booksCombo);
            bookCombox.setVisible(true);
            tx.commit();
        }
        catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }
    }


    public Stage AddReview(ActionEvent actionEvent) {
        Stage bookStage =new Stage();

        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/fxml/vReviewAdd.fxml"));
            Parent root= loader.load();
            add_review= loader.<ControllerAddReview>getController();
            Scene book = new Scene(root);
            bookStage.setScene(book);
            add_review.printData(actionEvent); //uploads data in Comboboxes from DB
            bookStage.showAndWait();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return bookStage;
    }

    public void Search (ActionEvent actionEvent){
        ObservableList<Review> reviews=  FXCollections.observableArrayList();
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            Query query = session.createQuery(SearchHQL()+Rates());

            switch (SearchHQL()){
                case "from Data.Review where book= :b":{
                    query.setString("b",bookCombox.getValue().toString());
                    break;
                }
                case "from Data.Review where user_id= :y":{
                    query.setString("y",users.getValue().toString());
                    break;
                }
                case "from Data.Review where book= :b AND user_id= :y":{
                    query.setString("b",bookCombox.getValue().toString());
                    query.setString("y",users.getValue().toString());
                    break;
                }
            }
            List booky= query.list();
            for (Iterator iterator = booky.iterator(); iterator.hasNext();) {
                Review bookTable = (Review) iterator.next();
                reviews.add(bookTable);
            }
            reviewId.setCellValueFactory(new PropertyValueFactory<Review,Integer>("id"));
            book.setCellValueFactory(new PropertyValueFactory<Review,String>("book"));
            userId.setCellValueFactory(new PropertyValueFactory<Review,Integer>("user_id"));
            rate.setCellValueFactory(new PropertyValueFactory<Review,Integer>("rate"));
            date.setCellValueFactory(new PropertyValueFactory<Review,String>("date"));

            tableReview.setItems(reviews);
            tableReview.setVisible(true);



            tx.commit();
        }
            catch (Exception e) {
                if (tx!=null)
                    tx.rollback();
                e.printStackTrace();
            } finally {
                session.close();
            }

    }

    public String SearchHQL(){
        String HQL="from Data.Review";
        if (!(bookCombox.getEditor().getText().equals(""))& users.getEditor().getText().equals("")) {
            HQL = "from Data.Review where book= :b";
        }
        if ((bookCombox.getEditor().getText().equals(""))& !(users.getEditor().getText().equals(""))){
            HQL="from Data.Review where user_id= :y";}
        if (!(bookCombox.getEditor().getText().equals(""))& !(users.getEditor().getText().equals(""))){
            HQL="from Data.Review where book= :b AND user_id= :y";}
        return HQL;
    }

    public String Rates(){
        String HQL2="";
        switch (ratings.getValue().toString()){
            case "All":{break;}
            case "Positive":{HQL2=" AND  rate > 3"; break;}
            case "Neutral":{HQL2=" AND  rate < 4";break;}
            case "Negative":{HQL2=" AND  rate < 2";break;}
            default:break;
        }
        return HQL2;

    }


    public void Export(ActionEvent actionEvent) throws IOException {


         Document document = new Document();
        PdfWriter writer = null;
        try {
            writer = PdfWriter.getInstance(document, new FileOutputStream("Review.pdf"));
        } catch (DocumentException e) {
            e.printStackTrace();
        }
        document.open();
        try {
            XMLWorkerHelper.getInstance().parseXHtml(writer, document,
            new FileInputStream(prepareHTML()));
        } catch (IOException e) {
            e.printStackTrace();
        }
            document.close();
    }

    private String prepareHTML() {
        Review review =(Review)tableReview.getSelectionModel().getSelectedItem();
        Session session = factory.openSession();
        Transaction tx = null;
        String text="";

        try {
            tx = session.beginTransaction();
            Query query= session.createQuery("select text from Data.Review where id=:r");
            query.setInteger("r",review.getId());
            List booky= query.list();
            for (Iterator iterator = booky.iterator(); iterator.hasNext();) {
                 text = (String) iterator.next();
            }

            tx.commit();

        }  catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
            FileWriter fWriter = null;
            BufferedWriter writer = null;
            try {
             fWriter = new FileWriter("Review.html");
            writer = new BufferedWriter(fWriter);
            writer.write(text);

            writer.close();
            } catch (Exception e) {
                //catch any exceptions here
            }
        }
        return "Review.html" ;
    }

    public void openReview(ActionEvent actionEvent){

        File htmlFile = new File(prepareHTML());
        try {
            Desktop.getDesktop().browse(htmlFile.toURI());
        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    public Stage openTutorial(ActionEvent actionEvent) {
        Stage bookStage =new Stage();
        ControllerReviews reviews;

        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/fxml/Tutorial.fxml"));
            Parent root= loader.load();
            Scene book = new Scene(root);
            bookStage.setScene(book);
            bookStage.showAndWait();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return bookStage;
    }
}
