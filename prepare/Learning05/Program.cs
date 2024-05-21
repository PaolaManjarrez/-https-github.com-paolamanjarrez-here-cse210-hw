using System;
using System.Collections.Generic;

public abstract class Shape
{
    private string color;

    public Shape(string color)
    {
        this.color = color;
    }

    public string GetColor()
    {
        return color;
    }

    public abstract double GetArea();
}

public class Square : Shape
{
    private double side;

    public Square(string color, double side) : base(color)
    {
        this.side = side;
    }

    public override double GetArea()
    {
        return side * side;
    }
}

public class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(string color, double width, double height) : base(color)
    {
        this.width = width;
        this.height = height;
    }

    public override double GetArea()
    {
        return width * height;
    }
}

public class Circle : Shape
{
    private double radius;

    public Circle(string color, double radius) : base(color)
    {
        this.radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();


        Square s1 = new Square("Red", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Blue", 4, 5);
        shapes.Add(s2);

        Circle s3 = new Circle("Green", 6);
        shapes.Add(s3);

    
        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}
