package Controller;

import Data.Author;
import Data.Book;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Spinner;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;

public class BookEditWindow {


    @FXML
    private GridPane EditBookWindow;

    public GridPane getEditBookWindow() {
        return EditBookWindow;
    }
    @FXML
    private TextField new_title;
    @FXML
    private TextField new_name;
    @FXML
    private TextField new_surname;
    @FXML
    private ComboBox new_gen_select;
    @FXML
    private Spinner new_year;
    Book thisBook;


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

    public void RewriteData(ActionEvent actionEvent) {
        Session session = factory.openSession();
        Transaction tx = null;
        try {
            tx = session.beginTransaction();
            Book book = (Book) session.get(Book.class,thisBook.getNumber());
            book.setGenre(new_gen_select.getValue().toString());
            controlMethods m = new controlMethods();
            book.setTitle(new_title.getText());
            book.setYear(Integer.parseInt(new_year.getEditor().getText()));
            book.setDate(m.currentDate());
            book.setAuthorsString(thisBook.strigAuthors());
            book.setAuthors(thisBook.getAuthors());
            session.update(book);
            tx.commit();
        }
        catch (Exception e) {
            if (tx!=null)
                tx.rollback();
            e.printStackTrace();
        } finally {
            session.close();
        }


       //Book book = new Book(new_title.getText(), Integer.parseInt(new_year.getEditor().getText()));





    }
     public void setData( Book book){
        this.thisBook=book;
        String names="";
        String surnames="";
        this.new_title.setText(book.getTitle());
        this.new_gen_select.getEditor().setText(book.getGenre());
        this.new_year.getEditor().setText(Integer.toString(book.getYear()));
        for (Author author: book.getAuthors()){
          names =names + author.getName()+",";
            surnames= surnames+author.getSurname() +",";
        }
        this.new_name.setText(names);
         this.new_surname.setText(surnames);


     }
}
