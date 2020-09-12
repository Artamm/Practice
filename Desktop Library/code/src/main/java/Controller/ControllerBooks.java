package Controller;

import DBConnection.DBClass;
import Data.Author;
import Data.Book;
import View.Main;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.*;
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

public class ControllerBooks  {
    /* Controls to add and modify scene*/
    @FXML private CheckBox dTheme; //dark theme button
    @FXML private GridPane sceneForUsers; // scene itself

    private Main Mainview;
    public void setMainview(Main mainview) {
        Mainview = mainview;
    }

    /* Table with data*/
    @FXML private TableView <Book> tableBooks;
    @FXML private TableColumn<Book,Integer> number;
    @FXML private TableColumn<Book,String> title;
    @FXML private TableColumn<Book,Integer> year;
    @FXML private TableColumn<Book,String> genre;
    @FXML private TableColumn<Book,String> authorsString;
    @FXML private TableColumn<Book,String> date;
    private ObservableList<Book> books;


    /* Controls to add new book*/
    @FXML private ComboBox gen_select;
    @FXML private TextField Title;
    @FXML private TextField Name;
    @FXML private TextField Surname;
    @FXML private Spinner Year;

    /* Controls for Search*/
    @FXML private TextField searchTitle;
    @FXML private TextField searchYear;


    /* Database Connection  */
    Connection conn = null;
    DBClass objDbClass = new DBClass();

    BookEditWindow editBook;

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
    public void initialize() {
        try {
            conn= objDbClass.getConnection();
        } catch (Exception ex) {
            ex.printStackTrace();

        }
        buildData();

    }



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


    public void setdTheme(ActionEvent actionEvent) {
        controlMethods dbutton = new controlMethods();
        dbutton.setdTheme(dTheme,sceneForUsers);
    } //dark theme


    /*CRUD and Search */
    public void AddDataB(ActionEvent actionEvent){
        String book_title = Title.getText();
        String genres = (gen_select.getValue()).toString();

        String book_year = Year.getEditor().getText();
        int year= Integer.parseInt(book_year);

        Book bookAdd =new Book("",0);
        bookAdd.setTitle(book_title);
        bookAdd.setGenre(genres);
        bookAdd.setYear(year);
        controlMethods dateButton = new controlMethods();
        bookAdd.setDate(dateButton.currentDate());

        String name = Name.getText();
        String surname = Surname.getText();
        String[] names;
        String [] surnames;
        if (name.contains(",") | surname.contains(",")){
            names = name.split(",");
            surnames = surname.split(",");
            System.out.println("Names "+names.length);
            System.out.println("Surnames "+surnames.length);
            for (int i=0; i<surnames.length;i++){
                Author author = new Author(names[i],surnames[i]);
                bookAdd.authors.add(author);
            }
            bookAdd.setAuthorsString(bookAdd.strigAuthors());
        }else{
            Author author = new Author(name, surname);
            bookAdd.authors.add(author);
            bookAdd.setAuthorsString(bookAdd.strigAuthors());
        }

        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            session.save(bookAdd);
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



    } //Create

    @FXML
    private void buildData(){

        books = FXCollections.observableArrayList();

        /* Print from DB*/
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            Query query = session.createQuery("from Data.Book");
            List booky= query.list();
            for (Iterator iterator = booky.iterator(); iterator.hasNext();) {
                Book bookTable = (Book) iterator.next();
                books.add(bookTable);
            }
            /*Insert in table */
            title.setCellValueFactory(new PropertyValueFactory<Book, String>("title"));
            genre.setCellValueFactory(new PropertyValueFactory<Book, String>("genre"));
            date.setCellValueFactory(new PropertyValueFactory<Book, String>("date"));
            authorsString.setCellValueFactory(new PropertyValueFactory<Book, String>("authorsString"));
            number.setCellValueFactory(new PropertyValueFactory<Book, Integer>("number"));
            year.setCellValueFactory(new PropertyValueFactory<Book, Integer>("year"));

            tableBooks.setItems(books);
            tableBooks.setVisible(true);

            tx.commit();
        }
        catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }



    } // Reading and updating table

    public void DeleteData(ActionEvent actionEvent){
        try{
            Book book = (Book) tableBooks.getSelectionModel().getSelectedItem();
            Session session = factory.openSession();
            Transaction tx = null;
            try {
                tx = session.beginTransaction();
                session.delete(book);
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
            m.alert("Select something","To work with this method you need to select item from the table.");
        }
    } //Delete

    public void DeleteAllData(ActionEvent actionEvent) {
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            Query query = session.createQuery("delete from Data.Book");
            query.executeUpdate();
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

    } //Delete everything

    public void EditBook(ActionEvent actionEvent) throws IOException {
        controlMethods m = new controlMethods();

        Stage bookStage =new Stage();
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/fxml/vEdit_Book_window.fxml"));
        Parent root= loader.load();
        editBook = loader.<BookEditWindow>getController();

        m.setdTheme(dTheme,editBook.getEditBookWindow());
        Scene scene = new Scene(root);
        bookStage.setScene(scene);
        try {
            Book book = (Book) tableBooks.getSelectionModel().getSelectedItem();
            prepareAuthor(book);
            editBook.setData(book);
            bookStage.showAndWait();
            bookStage.onCloseRequestProperty();
            {
                buildData();
            }
        }
        catch (Exception ex){
            m.alert("Select something first", "Please select data from table to start edit");
        }
    } //opens editor in new window

    public void Search(ActionEvent actionEvent){
        books.clear();
        /* Print from DB*/
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            Query query = session.createQuery(querySearch());
            switch (querySearch()){
                case "from Data.Book where Title= :t" :{
                    query.setString("t",searchTitle.getText());
                    break;
                }

                case "from Data.Book where Year= :y" :{
                    query.setInteger("y",Integer.parseInt(searchYear.getText()));
                    break;
                }
                case "from Data.Book where Year= :y AND Title= :t" :{
                    query.setString("t",searchTitle.getText());
                    query.setInteger("y",Integer.parseInt(searchYear.getText()));
                    break;
                }
                default: break;
            }

            List spec_book= query.list();
            for (Iterator iterator = spec_book.iterator(); iterator.hasNext();) {
                Book bookTable = (Book) iterator.next();
                books.add(bookTable);
            }
            /*Insert in table */
            title.setCellValueFactory(new PropertyValueFactory<Book, String>("title"));
            genre.setCellValueFactory(new PropertyValueFactory<Book, String>("genre"));
            date.setCellValueFactory(new PropertyValueFactory<Book, String>("date"));
            authorsString.setCellValueFactory(new PropertyValueFactory<Book, String>("authorsString"));
            number.setCellValueFactory(new PropertyValueFactory<Book, Integer>("number"));
            year.setCellValueFactory(new PropertyValueFactory<Book, Integer>("year"));

            tableBooks.setItems(books);
            tableBooks.setVisible(true);

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


    /*To split authors name/surname from cell in DB*/
    private void prepareAuthor( Book book){
        String[] array = book.getAuthorsString().split(",");
        book.getAuthors().clear();
        for( String author : array){
            String [] name_surname = author.split(" ");
            book.authors.add(new Author (name_surname[0],name_surname[1]));
        }
    }

    private String querySearch(){
        String HQL="from Data.Book";
        if (!(searchTitle.getText().equals(""))& searchYear.getText().equals("")) {
            HQL = "from Data.Book where Title= :t";
        }
        if (searchTitle.getText().equals("") & !(searchYear.getText().equals(""))){
            HQL="from Data.Book where Year= :y";}
        if (!(searchTitle.getText().equals("")) & !(searchYear.getText().equals(""))){
            HQL="from Data.Book where Year= :y AND Title= :t";}
        return HQL;
    }




}
