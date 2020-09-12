/*
Templates for methods that  are applied in all controllers
 */

package Controller;

import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.CheckBox;
import javafx.scene.layout.GridPane;
import javafx.stage.Stage;

import java.io.IOException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

public class controlMethods {

    Stage bookStage =new Stage();


    public void setdTheme( CheckBox dTheme, GridPane sceneForUsers) {

        if(dTheme.isSelected()){
            sceneForUsers.getStylesheets().add(getClass().getResource("/css/dark-theme.css").toExternalForm());
        }else
        {
            sceneForUsers.getStylesheets().remove(getClass().getResource("/css/dark-theme.css").toExternalForm());
        }
    } //set dark theme
    public Stage setScene(String sceneName){
        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource(sceneName));
            Parent root = loader.load();
            Scene book = new Scene(root);
            bookStage.setScene(book);
            bookStage.show();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return bookStage;
    } //open new stage
    public Stage setEditScene(String sceneName, UserEditWindow userEditWindow){
        try {
            FXMLLoader loader = new FXMLLoader(getClass().getResource(sceneName));
            loader.setController(userEditWindow);
            Parent root= loader.load();
            Scene book = new Scene(root);
            bookStage.setScene(book);
        } catch (IOException e) {
            e.printStackTrace();
        }
        return bookStage;
    } //open new stage

    public void alert(String reason,String explanation ){
        Alert alert = new Alert(Alert.AlertType.INFORMATION);
        alert.setTitle("Information");
        alert.setHeaderText(reason);
        alert.setContentText(explanation);
        alert.showAndWait();

    } //error dialogs template
    public String currentDate(){
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd-MM-yyyy");
        LocalDate localDate = LocalDate.now();
        String date = localDate.toString();
        return date;
    } //set the current date


}
