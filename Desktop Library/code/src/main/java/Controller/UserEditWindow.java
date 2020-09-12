package Controller;

import DBConnection.DBClass;
import Data.User;
import javafx.fxml.FXML;
import javafx.scene.control.Spinner;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;

public class UserEditWindow extends ControllerUsers {
    @FXML
    private GridPane EditUserWindow;

    public GridPane getEditUserWindow() {
        return EditUserWindow;
    }

    @FXML
    private Spinner new_id;

    Connection conn = null;
    DBClass objDbClass = new DBClass();

    public TextField getNew_surname() {
        return new_surname;
    }

    public void setNew_surname(String new_surname) {
        this.new_surname.setText(new_surname);
    }

    public void initialize(){}
    @FXML

    private TextField new_name;
    @FXML
    private TextField new_surname;


@FXML ControllerUsers control;

    User user;
    @FXML


    public void initializeData(User user ){
      System.out.println(user.getName());
//controlMethods m = new controlMethods();
//m.setEditScene("vEdit_User_window.fxml",user);



       /* String SQL = "SELECT Name, Surname from users where id =? ";
        try {

            PreparedStatement stat = conn.prepareStatement(SQL);
            stat.setString(1,Integer.toString(user.getUserId()) );
            ResultSet rs = stat.executeQuery();
            while (rs.next()) {
                System.out.println("YAY");
            }
        }catch (Exception ex){
            ex.printStackTrace();
        }
        */


    }

    public void setUser(User user) {
        this.user = user;
    }

    public void RewriteData(){
        User edited_user = new User(new_name.getText(),new_surname.getText()) ;
        controlMethods dateButton = new controlMethods();
        edited_user.setUserId(Integer.parseInt(new_id.getEditor().getText()));
        String date = dateButton.currentDate();
        edited_user.setDate(date);
        this.user=edited_user;

        try {
            conn= objDbClass.getConnection();
            System.out.println("Connected!");

        } catch (Exception ex) {
            ex.printStackTrace();

        }

        String SQL = "UPDATE users SET Name=?, Surname=?, Date=? WHERE  id =?;";
        try {
            PreparedStatement stat = conn.prepareStatement(SQL);
            stat.setString(1, edited_user.getName());
            stat.setString(2, user.getSurname());
            stat.setString(3, user.getDate());
            stat.setString(4, Integer.toString(user.getUserId()));

            stat.executeUpdate();


        } catch (SQLException e) {
            System.out.println("Failed.");
            e.printStackTrace();

        }

        System.out.println("Data edited.");
    }


    public void setData(User user) {
        this.new_id.getEditor().setText(Integer.toString(user.getUserId()));
        this.new_surname.setText(user.getSurname());
        this.new_name.setText(user.getName());


}

    public User getUser() {
        return user;
    }


}
