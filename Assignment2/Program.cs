using System;

namespace MyApplication
{
    class Basic
    {
        //o_x, o_y are origin coordinates
        //p_x, p_y are coordinates of test point
        public double o_x = 0, o_y = 0, p_x = 2, p_y = 2;

        //T_x, T_y are translation of region in x and y respectively
        public double T_x = 2, T_y = 2;

        // theta is angle rotated by region about origin
        public double theta = 30;

        public virtual void InObject()
        {
            Console.WriteLine("Error");
        }
    }

    class Circle : Basic // defining class for circle
    {
        // radius is radius of circle
        // center of circle is origin
        public double radius = 5;
        public override void InObject()  //Method to check point lies InObject
        {
            if (((p_x - o_x) * (p_x - o_x) + (p_y - o_y) * (p_y - o_y)) <= (radius * radius))
                Console.WriteLine("Given Point lies Inside the circle");
            else
                Console.WriteLine("Given Point lies Outside the circle");
        }

    }

    class Triangle : Basic //defining class for triangle
    {
        // Triangle with coordinates origin, B, C
        public double B_x = 10, B_y = 30, C_x = 20, C_y = 0;
        public override void InObject()   //Method to check point lies InObject
        {
            static double Area(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
            {
                return Math.Abs((Ax * (By - Cy) + Bx * (Cy - Ay) + Cx * (Ay - By)) / 2);
            }
            double A = Area(o_x, o_y, B_x, B_y, C_x, C_y);
            double A1 = Area(p_x, p_y, o_x, o_y, B_x, B_y);
            double A2 = Area(p_x, p_y, B_x, B_y, C_x, C_y);
            double A3 = Area(p_x, p_y, C_x, C_y, o_x, o_y);
            if (A == A1 + A2 + A3)
                Console.WriteLine("Given Point lies Inside the triangle");
            else
                Console.WriteLine("Given Point lies Outside the triangle");
        }
    }

    class Rectangle : Basic // defining class for Rectangle
    {
        // defining rectangle with coordinates origin,B,C,D
        public double B_x = 0, B_y = 3, C_x = 5, C_y = 3, D_x = 5, D_y = 0;
        public override void InObject()     //Method to check point lies InObject
        {
            static double Area(double Ax, double Ay, double Bx, double By, double Cx, double Cy)
            {
                return Math.Abs((Ax * (By - Cy) + Bx * (Cy - Ay) + Cx * (Ay - By)) / 2);
            }
            double A01 = Area(o_x, o_y, B_x, B_y, C_x, C_y);
            double A02 = Area(o_x, o_y, C_x, C_y, D_x, D_y);
            double A1 = Area(p_x, p_y, o_x, o_y, B_x, B_y);
            double A2 = Area(p_x, p_y, B_x, B_y, C_x, C_y);
            double A3 = Area(p_x, p_y, C_x, C_y, D_x, D_y);
            double A4 = Area(p_x, p_y, D_x, D_y, o_x, o_y);
            if ((A01 + A02) == (A1 + A2 + A3 + A4))
                Console.WriteLine("Given Point lies Inside the rectangle");
            else
                Console.WriteLine("Given Point lies Outside the rectangle");
        }
    }

    class CircleTranslation : Circle  // defining class for translated circle
    {
        public void InTObject()   //Method to check point lies InTranslatedObject
        {
            o_x = o_x + T_x;
            o_y = o_y + T_y;
            Circle TCircle = new CircleTranslation();
            Console.WriteLine("For translated Circle");
            TCircle.InObject();
        }

    }

    class TriangleTranslation : Triangle // defining class for rotated Triangle
    {
        public void InTObject()    //Method to check point lies InTranslatedObject
        {
            o_x = o_x + T_x;
            o_y = o_y + T_y;
            B_x = B_x + T_x;
            B_y = B_y + T_y;
            C_x = C_x + T_x;
            C_y = C_y + T_y;
            Triangle TTriangle = new TriangleTranslation();
            Console.WriteLine("For translated Triangle");
            TTriangle.InObject();
        }

    }

    class RectangleTranslation : Rectangle // defining class for translated Rectangle
    {
        public void InTObject()   //Method to check point lies InTranslatedObject
        {
            o_x = o_x + T_x;
            o_y = o_y + T_y;
            B_x = B_x + T_x;
            B_y = B_y + T_y;
            C_x = C_x + T_x;
            C_y = C_y + T_y;
            D_x = D_x + T_x;
            D_y = D_y + T_y;
            Rectangle TRectangle = new RectangleTranslation();
            Console.WriteLine("For translated Rectangle");
            TRectangle.InObject();
        }

    }
    // rotation of circle about center has no change in region
    class TriangleRotation : Triangle // class for rotated triangle
    {
        public void InRObject()    //Method to check point lies InRotatedObject 
        {
            //double o_x_n = o_x * Math.Cos(theta) - o_y * Math.Sin(theta);
            //double o_y_n = o_x * Math.Sin(theta) + o_y * Math.Cos(theta);
            double B_x_n = B_x * Math.Cos(theta) - B_y * Math.Sin(theta);
            double B_y_n = B_x * Math.Sin(theta) + B_y * Math.Cos(theta);
            double C_x_n = C_x * Math.Cos(theta) - C_y * Math.Sin(theta);
            double C_y_n = C_x * Math.Sin(theta) + C_y * Math.Cos(theta);
            //o_x = o_x_n;
            //o_y = o_y_n;
            B_x = B_x_n;
            B_y = B_y_n;
            C_x = C_x_n;
            C_y = C_y_n;
            Triangle RTriangle = new TriangleRotation();
            Console.WriteLine("For Rotated Triangle");
            RTriangle.InObject();
        }

    }

    class RectangleRotation : Rectangle  //class for rotated Rectangle
    {
        public void InRObject()      //Method to check point lies InRotatedObject
        {
            //double o_x_n = o_x * Math.Cos(theta) - o_y * Math.Sin(theta);
            //double o_y_n = o_x * Math.Sin(theta) + o_y * Math.Cos(theta);
            double B_x_n = B_x * Math.Cos(theta) - B_y * Math.Sin(theta);
            double B_y_n = B_x * Math.Sin(theta) + B_y * Math.Cos(theta);
            double C_x_n = C_x * Math.Cos(theta) - C_y * Math.Sin(theta);
            double C_y_n = C_x * Math.Sin(theta) + C_y * Math.Cos(theta);
            double D_x_n = D_x * Math.Cos(theta) - D_y * Math.Sin(theta);
            double D_y_n = D_x * Math.Sin(theta) + D_y * Math.Cos(theta);
            //o_x = o_x_n;
            //o_y = o_y_n;
            B_x = B_x_n;
            B_y = B_y_n;
            C_x = C_x_n;
            C_y = C_y_n;
            D_x = D_x_n;
            D_y = D_y_n;
            Rectangle RRectangle = new RectangleRotation();
            Console.WriteLine("For Rotated Rectangle");
            RRectangle.InObject();
        }

    }
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("For Circle");
            Basic circle = new Circle();
            circle.InObject();
            CircleTranslation TransCircle = new CircleTranslation();
            TransCircle.InTObject();
            

            Console.WriteLine("For Triangle");
            Basic triangle = new Triangle();
            triangle.InObject();
            TriangleTranslation TransTriangle = new TriangleTranslation();
            TransTriangle.InTObject();
            TriangleRotation RotTriangle = new TriangleRotation();
            RotTriangle.InRObject();

            Console.WriteLine("For Rectangle");
            Basic rectangle = new Rectangle();
            rectangle.InObject();
            RectangleTranslation TransRectangle = new RectangleTranslation();
            TransRectangle.InTObject();
            RectangleRotation RotRectangle = new RectangleRotation();
            RotRectangle.InRObject();
        }
    }

}
