package Figures;


import java.awt.*;
import java.util.ArrayList;
import java.util.List;

public class Figure {
    public static List<Figure> figures = new ArrayList<>();
    static {
        figures.add(new Circle("Circle", 16, 1, 14, 16));
        figures.add(new Square("Square", 16, 16, 32, 32));
        figures.add(new Triangle("Triangle", 45, 12, 3, 43));
        figures.add(new Rhombus ("Rhombus", 12, 12, 24, 24));
        figures.add(new Rectang("Rectangle", 12, 12, 36, 36));
        figures.add(new LineSegment("Line Segment", 12, 13, 13, 64));
        figures.add(new Oval("Oval", 13, 56, 65, 56));
    }
    public Figure(String name, int x1, int y1, int x2, int y2) {
        this.FigureName = name;
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    public void print() {
        System.out.println(FigureName + "(" + x1 + "; " + y1 + "; " + x2 + "; " + y2 +  ")");
    }

    public static void FigureData (){
        for (Figure figure : figures) {
            figure.print();
        }
    }

    private String FigureName;
    private int x1;
    private int y1;
    private int x2;
    private int y2;
}
