package Controller;

import Data.Review;
import Data.User;
import javafx.fxml.FXML;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Slider;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.web.HTMLEditor;
import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;

import java.awt.event.ActionEvent;
import java.util.Iterator;
import java.util.List;

public class ControllerEditReview extends ControllerAddReview {

    Review review;
    @FXML private ComboBox bookBox;
    @FXML private ComboBox userBox;
    @FXML private Slider rating;
    @FXML private HTMLEditor editor;


    public Review getReview() {
        return review;
    }

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

    public void setReview(Review review) {
        this.review = review;
        this.bookBox.setValue(review.getBook());
        this.userBox.setValue(review.getUser_id());
        this.rating.setValue(review.getRate());
    }

    public ComboBox getBookBox() {
        return bookBox;
    }

    public ComboBox getUserBox() {
        return userBox;
    }

    public void saveEdition(){

        Session session = factory.openSession();
        Transaction tx = null;
        try{
            tx = session.beginTransaction();
            Review changed = (Review) session.get(Review.class,review.getId());
            changed.setRate((int)this.rating.getValue());
            changed.setText(editor.getHtmlText());
            controlMethods m = new controlMethods();
            changed.setDate(m.currentDate());
            session.update(changed);
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


}
