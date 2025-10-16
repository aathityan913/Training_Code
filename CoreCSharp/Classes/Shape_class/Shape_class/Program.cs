using System;
using System.Collections.Generic;

namespace csharp.training.congruent.classes
{
    // Base abstract class for all shapes
    public abstract class Shape
    {
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double GetArea();   // For 1D length or 2D area
        public virtual double GetVolume() => 0; // Default 0 for non-3D shapes
    }

    // 1D Shape
    public class Line : Shape
    {
        public double Length { get; set; }

        public Line(double length) : base("Line") => Length = length;
        public override double GetArea() => Length;
    }

    // 2D Shapes
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height) : base("Rectangle")
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius) : base("Circle") => Radius = radius;
        public override double GetArea() => Math.PI * Radius * Radius;
    }

    // 3D Shapes
    public class Sphere : Shape
    {
        public double Radius { get; set; }
        public Sphere(double radius) : base("Sphere") => Radius = radius;
        public override double GetArea() => 4 * Math.PI * Radius * Radius;
        public override double GetVolume() => (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3);
    }

    public class Cube : Shape
    {
        public double Side { get; set; }
        public Cube(double side) : base("Cube") => Side = side;
        public override double GetArea() => 6 * Side * Side;
        public override double GetVolume() => Math.Pow(Side, 3);
    }

    class Program
    {
        static double ReadDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value))
                    return value;
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }

        static int ReadInt(string prompt, int min, int max)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Invalid input. Enter a number between {min} and {max}.");
            }
        }

        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();

            Console.WriteLine("Select shapes to create:");
            Console.WriteLine("1. Line (1D)");
            Console.WriteLine("2. Rectangle (2D)");
            Console.WriteLine("3. Circle (2D)");
            Console.WriteLine("4. Sphere (3D)");
            Console.WriteLine("5. Cube (3D)");
            Console.WriteLine("Enter numbers separated by spaces (e.g., 1 3 5):");

            string[] selections = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string sel in selections)
            {
                switch (sel)
                {
                    case "1":
                        shapes.Add(new Line(ReadDouble("Enter length of the line: ")));
                        break;
                    case "2":
                        shapes.Add(new Rectangle(
                            ReadDouble("Enter width of the rectangle: "),
                            ReadDouble("Enter height of the rectangle: ")
                        ));
                        break;
                    case "3":
                        shapes.Add(new Circle(ReadDouble("Enter radius of the circle: ")));
                        break;
                    case "4":
                        shapes.Add(new Sphere(ReadDouble("Enter radius of the sphere: ")));
                        break;
                    case "5":
                        shapes.Add(new Cube(ReadDouble("Enter side of the cube: ")));
                        break;
                    default:
                        Console.WriteLine($"Invalid selection: {sel}");
                        break;
                }
            }

            Console.WriteLine("\n=== Shape Details ===");
            foreach (var shape in shapes)
            {
                Console.WriteLine($"Shape: {shape.Name}");
                Console.WriteLine($"Area/Length: {shape.GetArea():F2}");
                if (shape.GetVolume() > 0)
                    Console.WriteLine($"Volume: {shape.GetVolume():F2}");
                Console.WriteLine();
            }
        }
    }
}
