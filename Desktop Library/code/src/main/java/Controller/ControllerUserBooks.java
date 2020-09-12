package Controller;

import DBConnection.DBClass;
import Data.Author;
import Data.Book;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.GridPane;
import javafx.scene.control.*;
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
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;


public class ControllerUserBooks {

    @FXML
    GridPane sceneForUsersBooks;

    @FXML
    private CheckBox dTheme;

    @FXML private TableView <Book> tableBooks;
    @FXML private TableColumn<Book,Integer> number;
    @FXML private TableColumn<Book,String> title;
    @FXML private TableColumn<Book,Integer> year;
    @FXML private TableColumn<Book,String> genre;
    @FXML private TableColumn<Book,String> authors;
    @FXML private TableColumn<Book,String> date;



    /* Already read table*/
    @FXML private TableView <Book> tableBooksR;
    @FXML private TableColumn<Book,Integer> numberR;
    @FXML private TableColumn<Book,String> titleR;
    @FXML private TableColumn<Book,Integer> yearR;
    @FXML private TableColumn<Book,String> genreR;
    @FXML private TableColumn<Book,String> authorsR;
    @FXML private TableColumn<Book,String> dateR;

    /* Currently reading table*/
    @FXML private TableView <Book> tableBooksC;
    @FXML private TableColumn<Book,Integer> numberC;
    @FXML private TableColumn<Book,String> titleC;
    @FXML private TableColumn<Book,Integer> yearC;
    @FXML private TableColumn<Book,String> genreC;
    @FXML private TableColumn<Book,String> authorsC;
    @FXML private TableColumn<Book,String> dateC;

    /* Will be reading table*/
    @FXML private TableView <Book> tableBooksW;
    @FXML private TableColumn<Book,Integer> numberW;
    @FXML private TableColumn<Book,String> titleW;
    @FXML private TableColumn<Book,Integer> yearW;
    @FXML private TableColumn<Book,String> genreW;
    @FXML private TableColumn<Book,String> authorsW;
    @FXML private TableColumn<Book,String> dateW;



    private ObservableList<Book> books;
    /* Controls for Search*/

    @FXML private TextField areaId;
    @FXML private ComboBox list_select;
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



    @FXML
    /*Data updating */
    public void initialize() {
        try {
            conn= objDbClass.getConnection();
            BuildAllBooks();
        } catch (Exception ex) {
            ex.printStackTrace();

        }
    } //database connection

 /*Scene stuff*/
    public void setdTheme(ActionEvent actionEvent) {
        controlMethods dbutton = new controlMethods();
        dbutton.setdTheme(dTheme,sceneForUsersBooks);
    } //theme selection


    /*Menu control */

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

    public Stage openBookScene(ActionEvent actionEvent) {
        controlMethods sbutton = new controlMethods();
        return sbutton.setScene("/fxml/vBooks.fxml");
    } //open Book stage

    public Stage openUsersScene(ActionEvent actionEvent) {
        controlMethods sbutton = new controlMethods();
        return sbutton.setScene("/fxml/vUsers.fxml");
    } //open User stage


/*Show tables with data*/

    public void BuildAllBooks(){
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
            title.setCellValueFactory(new PropertyValueFactory<Book, String>("title"));
            genre.setCellValueFactory(new PropertyValueFactory<Book, String>("genre"));
            date.setCellValueFactory(new PropertyValueFactory<Book, String>("date"));
            authors.setCellValueFactory(new PropertyValueFactory<Book, String>("authorsString"));
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


    } /*Shows all books. Needed to add books to the user selected list*/

    public void ShowUsersBooks(ActionEvent actionEvent){
        BuildAlreadyRead(actionEvent);
        BuildCurrentBooks(actionEvent);
        BuildWillReadBooks(actionEvent);
    } /*Shows all users books. Prints only after button "Find" is clicked*/

/*Extracts title from user list table and gets all information about a book from books table */

    public void BuildAlreadyRead(ActionEvent actionEvent){
        try {
            String SQL = "Select BookTitle from RBlist WHERE User_id=?";
            PreparedStatement stat = conn.prepareStatement(SQL);
            stat.setString(1,areaId.getText());
            ResultSet rs = stat.executeQuery();
            List <String> titles = new ArrayList<>();
            while(rs.next()){
                titles.add(rs.getString("BookTitle"));
            }
           ObservableList<Book> books = BuildCertainUserList(titles);
            ShowAlreadyRead(books);


        }
        catch (Exception ex){

        }


    } //for already read books

    public void BuildCurrentBooks(ActionEvent actionEvent){
        try {
            String SQL = "Select BookTitle from CBlist WHERE User_id=?";
            PreparedStatement stat = conn.prepareStatement(SQL);
            stat.setString(1,areaId.getText());
            ResultSet rs = stat.executeQuery();
            List <String> titles = new ArrayList<>();
            while(rs.next()){
                titles.add(rs.getString("BookTitle"));
            }
            ObservableList<Book> books =  BuildCertainUserList(titles);
            ShowCurrentlyReading(books);
        }
        catch (Exception ex){

        }
    }// for currently reading books

    public void BuildWillReadBooks(ActionEvent actionEvent){
        try {
            String SQL = "Select BookTitle from WBlist WHERE User_id=?";
            PreparedStatement stat = conn.prepareStatement(SQL);
            stat.setString(1,areaId.getText());
            ResultSet rs = stat.executeQuery();
            List <String> titles = new ArrayList<>();
            while(rs.next()){
                titles.add(rs.getString("BookTitle"));
            }
            ObservableList<Book> books =  BuildCertainUserList(titles);
            ShowWillBeReading(books);
        }
        catch (Exception ex){

        }
    }//for will be reading books


    public ObservableList<Book> BuildCertainUserList(List <String> titles){
        books = FXCollections.observableArrayList();

        try {
            String SQL = "SELECT * FROM books WHERE Title=?";
            PreparedStatement stat = conn.prepareStatement(SQL);

            for (String title : titles){
                stat.setString(1,title);
                ResultSet rs = stat.executeQuery();
                while(rs.next()){
                    Book book =new Book("",0);
                    book.setTitle(rs.getString("Title"));
                    book.setYear(rs.getInt("Year"));
                    book.setGenre(rs.getString("Genre"));
                    book.setDate(rs.getString("Date"));
                    book.authors.add(new Author(" ",rs.getString("Author")));
                    book.strigAuthors(); //sets String for DB
                    book.setNumber(rs.getInt("id"));
                    books.add(book);
                }

            }

        }catch(Exception ex){

        }
        return books;
    } //function to get user's books information. Returns a list.

    /*Fills tableView*/
    public void ShowAlreadyRead(ObservableList <Book> books){
        titleR.setCellValueFactory(new PropertyValueFactory<Book, String>("title"));
        genreR.setCellValueFactory(new PropertyValueFactory<Book, String>("genre"));
        dateR.setCellValueFactory(new PropertyValueFactory<Book, String>("date"));
        authorsR.setCellValueFactory(new PropertyValueFactory<Book, String>("authorsString"));
        numberR.setCellValueFactory(new PropertyValueFactory<Book, Integer>("number"));
        yearR.setCellValueFactory(new PropertyValueFactory<Book, Integer>("year"));

        tableBooksR.setItems(books);
        tableBooksR.setVisible(true);
    }

    public void ShowCurrentlyReading(ObservableList <Book> books){
        titleC.setCellValueFactory(new PropertyValueFactory<Book, String>("title"));
        genreC.setCellValueFactory(new PropertyValueFactory<Book, String>("genre"));
        dateC.setCellValueFactory(new PropertyValueFactory<Book, String>("date"));
        authorsC.setCellValueFactory(new PropertyValueFactory<Book, String>("authorsString"));
        numberC.setCellValueFactory(new PropertyValueFactory<Book, Integer>("number"));
        yearC.setCellValueFactory(new PropertyValueFactory<Book, Integer>("year"));

        tableBooksC.setItems(books);
        tableBooksC.setVisible(true);
    }
    public void ShowWillBeReading(ObservableList <Book> books){
        titleW.setCellValueFactory(new PropertyValueFactory<Book, String>("title"));
        genreW.setCellValueFactory(new PropertyValueFactory<Book, String>("genre"));
        dateW.setCellValueFactory(new PropertyValueFactory<Book, String>("date"));
        authorsW.setCellValueFactory(new PropertyValueFactory<Book, String>("authorsString"));
        numberW.setCellValueFactory(new PropertyValueFactory<Book, Integer>("number"));
        yearW.setCellValueFactory(new PropertyValueFactory<Book, Integer>("year"));

        tableBooksW.setItems(books);
        tableBooksW.setVisible(true);
    }

/*Add */
public void AddToList(ActionEvent actionEvent){
    Book book = (Book) tableBooks.getSelectionModel().getSelectedItem();
    String addList="";
    switch ((list_select.getValue()).toString()){
        case "Already read": {addList ="RBList";break;}
        case "Reading":{ addList="CBList";break;}
        case "Will read":{addList="WBList";break;}
    }
    try {
        String SQL = "INSERT INTO "+addList+" (User_id, BookTitle) VALUES(?,?);";
        PreparedStatement stat = conn.prepareStatement(SQL);
        stat.setString(1,areaId.getText());
        stat.setString(2,book.getTitle());
        stat.executeUpdate();
        ShowUsersBooks(actionEvent);
    }
    catch (Exception ex){
ex.printStackTrace();
    }




}

public void DeleteFromList(ActionEvent actionEvent){
String DeleteList ="";
Book book = new Book("",0);
    switch ((list_select.getValue()).toString()){
        case "Already read": {DeleteList ="RBList";
            book = (Book) tableBooksR.getSelectionModel().getSelectedItem();
        break;}
        case "Reading":{ DeleteList="CBList";
            book = (Book) tableBooksC.getSelectionModel().getSelectedItem();
        break;}
        case "Will read":{DeleteList="WBList";
            book = (Book) tableBooksW.getSelectionModel().getSelectedItem();
        break;}
        default:{
            controlMethods methods = new controlMethods();
            methods.alert("Not allowed","You're not allowed to delete books from the main list here. Open book tab instead");
            break;
        }
    }

    try {
        String SQL = "Delete FROM "+DeleteList+" WHERE User_id = ? AND BookTitle=?;";
        PreparedStatement stat = conn.prepareStatement(SQL);
        stat.setString(1,areaId.getText());
        stat.setString(2,book.getTitle());
        stat.executeUpdate();
        ShowUsersBooks(actionEvent);
    }
    catch (Exception ex){
        ex.printStackTrace();
    }


}

public void Search(ActionEvent actionEvent){
    if ( areaId.getText().equals("")){
        SearchGeneral();
    }else{
        searchInlists();
    }
}

    private void searchInlists() {
    checkEmptyFields();

    }

    private String checkEmptyFields() {
        String SQL="from Data.Book";
        if (!(searchTitle.getText().equals(""))& searchYear.getText().equals("")) {
            SQL = "SELECT * FROM";
        }
        if (searchTitle.getText().equals("") & !(searchYear.getText().equals(""))){
            SQL="from Data.Book where Year= :y";}
        if (!(searchTitle.getText().equals("")) & !(searchYear.getText().equals(""))){
            SQL="from Data.Book where Year= :y AND Title= :t";}
        return SQL;
    }


    private void SearchGeneral() {
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
            authors.setCellValueFactory(new PropertyValueFactory<Book, String>("authorsString"));
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
