using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MathApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Quad q = new Quad("poly", "rect", 4, 5);
            //   double areaQuad = q.getArea(4, 5);
            // double peri = q.getPerimeter(4, 5);
             Circle c = new Circle("Circle", 3.2);
            // double d= c.calcPeri(3.2);
            // double areaCircle = c.calcArea(3.2);
            Triangle t = new Triangle("Triangle", "iso", 4, 4, 5);
            //
            // double area = t.getAreaTriangle(4,4);
            //   Shapes s1 = new Triangle("Triangle", "iso", 1, 2, 3);
            //  double areaTriangle= s1.getAreaTriangle(1,2);
            // String s= s1.shapeName.ToString();
            //  Console.WriteLine(areaTriangle);#
           sortArray(q, c, t);
            serialJason(q,c,t);
        }
           
             static void sortArray(Quad q, Circle c, Triangle t) {
                double areaTriangle = t.getAreaTriangle(4, 5);
                double areaCircle = c.calcArea(3.2);
                double areaQuad = q.getArea(4, 5);
                List<double> shapesArea = new List<double>();
                shapesArea.Add(areaTriangle);
                shapesArea.Add(areaQuad);
                shapesArea.Add(areaCircle);
                shapesArea.Sort();
                Console.WriteLine(string.Join(",", shapesArea));
            }


        static void serialJason(Quad q, Circle c, Triangle t)
        {
            List<Shapes> listShapes = new List<Shapes>();
            listShapes.Add(q);
            listShapes.Add(c);
            listShapes.Add(t);

            String s = listShapes.ToString();
            string fileName = "WeatherForecast.json";
            string jsonString = JsonSerializer.Serialize(s);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine(File.ReadAllText(fileName));
        }









        
    }
    class Shapes
    {
        public String shapeName { set; get; }
        public String shapeType { set; get; }
        
        public Shapes(string shapeName)
        {
            this.shapeName = shapeName;
        }
        public Shapes(string shapeName, string shapeType)
        {
            this.shapeName = shapeName;
            this.shapeType = shapeType;
        }
        public double getAreaTriangle(double ab, double bc)
        {
            double area;

            area = 0.5 * ab * bc;
            return area;
        }

        public double getPerimeter(double ab, double bc, double ca)
        {
            return ab + bc + ca;
        }

        public double calcArea(double rad)
        {
            return 3.14 * rad * rad;
        }
        public double calcPeri(double rad)
        {
            return 2 * 3.14 * rad;
        }
        public double getArea(double l, double w)
        {
            return l * w;
        }
        public double getPerimeter(double l, double w)
        {
            return 2 * (l + w);
        }

        public override bool Equals(object obj)
        {
            return obj is Shapes shapes &&
                   shapeName == shapes.shapeName &&
                   shapeType == shapes.shapeType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(shapeName, shapeType);
        }
        public override string ToString()
        {
            return "[" + shapeName + "," + shapeType + "]";
        }
    }

    class Circle : Shapes
    {
        public double radius { set; get; }

        public Circle (String shapeName, double radius) :base(shapeName)
        {
            this.radius = radius;
        }




        public override bool Equals(object obj)
        {
            return obj is Circle circle &&
                   radius == circle.radius;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(radius);
        }
       

        public override string ToString()
        {
            return  "["+shapeName+","+ radius +"]";
        }
    }
    class Triangle:Shapes
    {
        public double sideA { set; get; }
        public double sideB { set; get; }
        public double sideC { set; get; }

        public Triangle(string shapeName, string shapeType,double sideA, double sideB, double sideC):base(shapeName,shapeType)
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                   base.Equals(obj) &&
                   sideA == triangle.sideA &&
                   sideB == triangle.sideB &&
                   sideC == triangle.sideC;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), sideA, sideB, sideC);
        }

        public Boolean getEquilateralTraingle(double ab, double bc, double ca)
        {


            if (ab == bc & bc == ca & ca == ab)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean getIsoTraingle(double ab, double bc, double ca)
        {


            if (ab == bc)
            {
                return true;
            }
            else if (bc == ca)
            {
                return true;
            }
            else if (ca == ab)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean getScaleneTriangle(double ab, double bc, double ca)
        {
            if (ab != bc && bc != ca)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        public override string ToString()
        {
            return "["+shapeName+","+shapeType+","+sideA+"," +sideB+", " +sideC +"]";
        }

        
    }
    class Quad:Shapes
    {
        private double length { set; get; }
        private double width { set; get; }

        public Quad(string shapeName,string shapeType, double length, double width):base(shapeName,shapeType )
        {
            this.length = length;
            this.width = width;
        }

        public override bool Equals(object obj)
        {
            return obj is Quad quad &&
                   length == quad.length &&
                   width == quad.width;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(length, width);
        }

        

        public Boolean getSquare(double l, double w)
        {
            if (l == w)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean getRectangle (double l, double w)
        {
            if (l != w)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public override string ToString()
        {
           
            return "["+shapeName+", "+shapeType+"," +length+", " + width+"]";
        }
    }
   
    
        

       
        
    

 
    
    
}
