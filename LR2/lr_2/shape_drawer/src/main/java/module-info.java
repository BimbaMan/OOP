module com.example.shape_drawer {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.shape_drawer to javafx.fxml;
    exports com.example.shape_drawer;
}