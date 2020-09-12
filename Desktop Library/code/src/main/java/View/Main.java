package View;

import Controller.ControllerBooks;
import Controller.ControllerUsers;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

public class Main extends Application {

    @Override
    public void start(Stage primaryStage) throws Exception{
        FXMLLoader loader = new FXMLLoader(getClass().getResource("/fxml/vBooks.fxml"));
        Parent root = loader.load();
        ControllerBooks user_control = loader.<ControllerBooks>getController();
        Scene book = new Scene(root);
        user_control.setMainview(this);

        primaryStage.setScene(book);
        primaryStage.show();

    }


    public static void main(String[] args) {

        launch(args);

    }
}
