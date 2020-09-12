package Controller;

import Data.User;
import DBConnection.DBClass;
import View.Main;
import javafx.collections.FXCollections;
import javafx.collections.*;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.control.Spinner;
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

import java.io.IOException;
import java.sql.*;

import java.util.Iterator;
import java.util.List;
import java.util.Random;


public class ControllerUsers {


    private Main Mainview;

    public void setMainview(Main mainview) {
        Mainview = mainview;
    }
    @FXML  private CheckBox dTheme; //dark theme button
    @FXML private GridPane sceneForUsers; //Main scene


    @FXML private Spinner id_field; // area for id
    @FXML private javafx.scene.control.TableView <User> tableUser;
    @FXML private TableColumn <User,String> name;
    @FXML private TableColumn <User,String> surname;
    @FXML private TableColumn <User,Integer> date;
    @FXML private TableColumn <User,Integer> userId;
    @FXML private TextField user_name;
    @FXML private TextField user_surname;
    @FXML private TextField search_name;
    @FXML private TextField search_surname;


    @FXML private GridPane EditUserWindow;
    @FXML private Spinner new_id;
    @FXML private TextField new_name;
    @FXML private TextField new_surname;
    UserEditWindow edit;
    ControllerReviews reviews;



    Connection conn = null;
    DBClass objDbClass = new DBClass();

    private ObservableList<User> users;

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
    }


    public void setdTheme(ActionEvent actionEvent) {
        controlMethods dbutton = new controlMethods();
        dbutton.setdTheme(dTheme,sceneForUsers);
    } //dark theme set
    public void genKey(ActionEvent actionEvent) {
        Random rand = new Random();
        int n = rand.nextInt(1000) + 1;
        id_field.getValueFactory().setValue(n);

    } //random id generator

    @FXML
    public void initialize() {

        try {
           conn= objDbClass.getConnection();
           buildData();

        } catch (Exception ex) {
            ex.printStackTrace();

        }

    } //database connection


    public Stage openBookScene(ActionEvent actionEvent) {
       controlMethods sbutton = new controlMethods();
       return sbutton.setScene("/fxml/vBooks.fxml");
    }

    public Stage openUsersScene(ActionEvent actionEvent) {
        controlMethods sbutton = new controlMethods();
       return sbutton.setScene("/fxml/vUsers.fxml");
    }
    public Stage openReviewScene(ActionEvent actionEvent) {
        Stage bookStage =new Stage();

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



    public void buildData(){

        users = FXCollections.observableArrayList();
        Session session = factory.openSession();
        Transaction tx = null;
        try{
            tx = session.beginTransaction();
            Query query = session.createQuery("from Data.User");
            List usery= query.list();
            for (Iterator iterator = usery.iterator(); iterator.hasNext();) {
                User userTable = (User) iterator.next();
                users.add(userTable);
            }
            name.setCellValueFactory(new PropertyValueFactory<User, String>("name"));
            surname.setCellValueFactory(new PropertyValueFactory<User, String>("surname"));
            date.setCellValueFactory(new PropertyValueFactory<User, Integer>("date"));
            userId.setCellValueFactory(new PropertyValueFactory<User, Integer>("userId"));

            tableUser.setItems(users);
            tableUser.setVisible(true);


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

    public void DeleteData(ActionEvent actionEvent){
        try{
            User user = (User) tableUser.getSelectionModel().getSelectedItem();
            Session session = factory.openSession();
            Transaction tx = null;
            try {
                tx = session.beginTransaction();
                session.delete(user);
                tx.commit();
            }
            catch (Exception e) {
                if (tx!=null)
                    tx.rollback();
                e.printStackTrace();
            } finally {
                session.close();
                buildData();
            }

        }
            catch (Exception ex){
                controlMethods m = new controlMethods();
                m.alert("Select something","To work with this method you need to select item from the table.");        }
    }

    public void AddData(ActionEvent actionEvent){
        String name = user_name.getText();
        String surname = user_surname.getText();
        String idString = id_field.getEditor().getText();
        int id= Integer.parseInt(idString);
        if(!checkId(id)){
            controlMethods alertM =new controlMethods();
            alertM.alert("User with the same id already exists",("User with such id already exists (check table)"));}
        else {
            controlMethods dateButton = new controlMethods();
            String date = dateButton.currentDate();
            User user = new User(name, surname);
            user.setDate(date);
            user.setUserId(id);
            String SQL = "INSERT INTO users (Id, Name, Surname,Date) VALUES(?,?,?,?);";
            try {
                PreparedStatement stat = conn.prepareStatement(SQL);
                stat.setString(1, Integer.toString(user.getUserId()));
                stat.setString(2, user.getName());
                stat.setString(3, user.getSurname());
                stat.setString(4, user.getDate());
                stat.executeUpdate();
                buildData();


            } catch (SQLException e) {
                e.printStackTrace();
            }

        }
    }

    private boolean checkId(int id){
        boolean b =true;
        String sql = "SELECT COUNT(*) from users WHERE id=?";
        try {
            int count = 0;
            PreparedStatement stat = conn.prepareStatement(sql);
            stat.setString(1,Integer.toString(id));
            ResultSet  rs = stat.executeQuery();
            while (rs.next()){
                count =rs.getInt("count(*)");
            }
            if(count==0)
                b = true;
            else
                b = false;

            stat.clearParameters();
        } catch (SQLException e) {
            e.printStackTrace();
        }
      return b;
    }

    public void  searchData(ActionEvent actionEvent){

        String nameS = search_name.getText();
        String surnameS =search_surname.getText();


        int number = fieldsEmpty(nameS,surnameS);

        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();

        String HQL = "from Data.User where name= :n";
        Query query = session.createQuery(HQL);

        switch (number){
            case 0:{
                 HQL = "from Data.User where name= :n";
                 query = session.createQuery(HQL);
                 query.setString("n",nameS);
                 break;}
            case 1: {
                 HQL = "from Data.User where name= :n";
                 query = session.createQuery(HQL);
                query.setString("n",nameS);

                break;}

            case 2:{
                 HQL = "from Data.User where surname= :s";
                 query = session.createQuery(HQL);
                query.setString("s",surnameS);


                break;
            }
            case 3:{
                 HQL = "from Data.User where name= :n and surname= :s";
                 query = session.createQuery(HQL);
                query.setString("n",nameS);
                query.setString("s",surnameS);


                break;
            }
            default:break;

        }
        ObservableList<User> specified_users;
        specified_users = FXCollections.observableArrayList();
            List spec_book= query.list();
            for (Iterator iterator = spec_book.iterator(); iterator.hasNext();) {
                User userTable = (User) iterator.next();
                specified_users.add(userTable);
            }

            name.setCellValueFactory(new PropertyValueFactory<User, String>("name"));
            surname.setCellValueFactory(new PropertyValueFactory<User, String>("surname"));
            date.setCellValueFactory(new PropertyValueFactory<User, Integer>("date"));
            userId.setCellValueFactory(new PropertyValueFactory<User, Integer>("userId"));

            tableUser.setItems(specified_users);
            tableUser.setVisible(true);


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

/*
    Opens edit window
 */
    public Stage openEdit(ActionEvent actionEvent) throws IOException {
        controlMethods m = new controlMethods();

            Stage bookStage =new Stage();
            FXMLLoader loader = new FXMLLoader(getClass().getResource("/fxml/vEdit_User_window.fxml"));
            Parent root= loader.load();
        edit = loader.<UserEditWindow>getController();

        m.setdTheme(dTheme,edit.getEditUserWindow());
        Scene book = new Scene(root);
            bookStage.setScene(book);
        User user = (User) tableUser.getSelectionModel().getSelectedItem();
        edit.setData( user);
        bookStage.showAndWait();


        //edit.setUser(user);
       //edit.starts(this);
       // UserEditWindow.initializeData(user);
return  bookStage;

    }


    /*
       Opens search window
    */
    public Stage openUsersBooks(ActionEvent actionEvent) {
        controlMethods sbutton = new controlMethods();
        return sbutton.setScene("/fxml/vUser_books.fxml");

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

   /*
   Checks if textfields for search are empty and which are filled
    */
   private int fieldsEmpty(String name, String surname){
        int number = 0;
        if (name.equals("") & surname.equals("") )   // both are empty
            number =  0;
         if (!name.equals("") & surname.equals(""))  //only name
            number = 1;
         if (name.equals("") & !surname.equals(""))  //only surname
            number = 2;
         if (!name.equals("") & !surname.equals("")) //both
            number = 3;
        return number;
    }

    public void DeleteAllData(ActionEvent actionEvent) {
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            Query query = session.createQuery("delete from Data.User");
            tx.commit();
        }
        catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
            buildData();
        }
    }
}
