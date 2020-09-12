package Controller;

import DBConnection.DBClass;
import Data.Review;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.ComboBox;

import javafx.event.ActionEvent;
import javafx.scene.control.Slider;
import javafx.scene.web.HTMLEditor;
import javafx.scene.web.WebEngine;
import javafx.scene.web.WebView;

import java.sql.*;

public class ControllerAddReview {

@FXML private ComboBox bookBox;
@FXML private ComboBox userBox;
@FXML private WebView prePic;
@FXML private HTMLEditor editor;
@FXML private Slider rating;

Review review;

    private ObservableList<Integer>userOption= FXCollections.observableArrayList();

    private Connection conn = null;
    private DBClass objDbClass = new DBClass();

    public void initialize() {

        try {
            conn= objDbClass.getConnection();
            System.out.println("Connected!");

        } catch (Exception ex) {
            ex.printStackTrace();

        }
    } //database connection


    public void fillUserBox(){
        String SQL = "Select id from users;";
        try {
            Statement stat = conn.createStatement();
            ResultSet rs = stat.executeQuery(SQL);
            while(rs.next()){
                userOption.add(rs.getInt("id"));
            }
            userBox.setItems(userOption);
            userBox.setVisible(true);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void fillBookBox(){
        ObservableList<String> booksCombo = FXCollections.observableArrayList();;
        String SQL = "Select Title from books;";
        try {
            Statement stat = conn.createStatement();
            ResultSet rs = stat.executeQuery(SQL);
            while(rs.next()){
                booksCombo.add(rs.getString("Title"));
            }
            bookBox.setItems(booksCombo);
            bookBox.setVisible(true);

        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    public void printData(ActionEvent actionEvent) {
        fillUserBox();
        fillBookBox();
    }

    public void ShowPreview(ActionEvent actionEvent){
        WebEngine webEngine = prePic.getEngine();
        webEngine.loadContent(editor.getHtmlText());

    }

    public HTMLEditor getEditor() {
        return editor;
    }

    public void setEditor(HTMLEditor editor) {
        this.editor = editor;
    }

    public void AddData(){
        controlMethods m =new controlMethods();
        String SQL = "INSERT INTO reviews( book, user_id, rate, review, date) VALUES (?,?,?,?,?)";
        try {
            PreparedStatement stat = conn.prepareStatement(SQL);
            stat.setString(1,bookBox.getValue().toString());
            stat.setString(2,userBox.getValue().toString());
            stat.setString(3,Double.toString(rating.getValue()));
            stat.setString(4,editor.getHtmlText());
            stat.setString(5,m.currentDate());
            stat.executeUpdate();


        } catch (SQLException e) {
            e.printStackTrace();
        }

    }
    public void setReview(Review review) {
        this.review = review;
        this.bookBox.setValue(review.getBook());
        this.userBox.setValue(review.getUser_id());
        this.rating.setValue(review.getRate());
    }

}
