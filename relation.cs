using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructions
{
    internal static  class relation
    {
        public static Dictionary<string, (double X, double Y)> points = new Dictionary<string, (double X, double Y)>();// create dictionary to store points
        public static double DEGREE = 0.01745329251994329576;
        public static double RADIAN = 57.2957795130823208768;
        public static double PI = 3.14159265358979323846;   
        public static double[,] POINT = new double[100, 100];
        //المثلث القائم
        public static double A(double B, double c) {return  Math.Sqrt(B * B + c * c); }// method to calculate hypotenuse of right triangle
        
        public static double angelA(double b,double c,double angel) { return Math.Sqrt(b * b + c * c -2*b*c* Math.Cos(angel)); }// قانون جيب التمام لاستنتاج طول الضلع المجهول في المثلث من طول ضلعين والزاوية المحصورة بينهما
       
        public static double angel_A(double D1, double D2, double D3)// method to calculate angle from lengths of triangle sides

        {

            return (Math.Pow(D1, 2) + Math.Pow(D3, 2) - Math.Pow(D2, 2)) / (2 * D1 * D3);

        }
        public static void new_point_measure(string name, double x1, double y1, double x2, double y2, double D1, double D2, double a)//
        {


            double m0 = (y2 - y1) / (x2 - x1);// ميل المستقيم ab
            double m1; //ميل المستقيم ac
            double x;// احداثي x للنقطة الجديدة
            double y;// احداثي y للنقطة الجديدة


            m1 = (m0 + Math.Tan(a)) / (1 - m0 * Math.Tan(a));

              
            double z = (Math.Pow(D1, 2) - Math.Pow(D2, 2) + Math.Pow(x2, 2) - Math.Pow(x1, 2) + Math.Pow(y2, 2) - Math.Pow(y1, 2)) / 2;// حساب z
            x = (z + m1 * x1 * (y2 - y1) - y2 * (y2 - y1)) / (x2 - x1) + m1 * (y2 - y1);// حساب احداثي x للنقطة الجديدة
            y = m1 * (x - x1) + y1;// حساب احداثي y للنقطة الجديدة


            int n= points.Count + 1;// get point number
            points.Add(name+n.ToString(), (x, y));// add new point to dictionary
            name = name + n.ToString();// update point name with number
            Console.WriteLine(" {0}, stored in points:{1},", name, points[name]);// show stored point


        }

        public static void STORE_POINT(string name, double X, double Y)// method to store point in dictionary
        {
            int n = points.Count + 1;
            points.Add(name + n.ToString(), (X, Y));   
          name= name + n.ToString();
            Console.WriteLine("{0} stored in points:{1}", name , points[name]);

        }
        
        public static double Measure_distant(double x1, double y1, double x2, double y2)// method to calculate distance between two points
        {
            double x = Math.Pow(x1 - x2, 2);
            double y = Math.Pow(y1 - y2, 2);
         
            return Math.Sqrt(x + y);
        }
    }
    }
