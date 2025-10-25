using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace constructions
{
    internal  class data 
    {
        public  Dictionary<string, (double X, double Y)> points = new Dictionary<string, (double X, double Y)>();// create dictionary to store points
        public  string[,] POINT=new string [100,4];// create array to store points
        public static string surveyors_list;// create static field to store surveyors list
        public static string  building_list;// create static field to store building list
        public static string approve_drawings_list;// create static field to store approve drawings list
        public static string survey_requests;// create static field to store survey requests list
                                             //   public static double DEGREE = 0.01745329251994329576;
        public const double RADIAN = 57.2957795130823208768;
        public const double PI = 3.14159265358979323846;
        public const double DEGREE = 0.01745329251994329576;
        public  string X(int ROW ) 
        {

                return POINT[ROW,2];
            }
        public  string Y(int ROW)
        { 

            
           
            return POINT[ROW,3];
        }
        public  string NAME(int ROW)
        {return POINT[ROW,1]; }


        
        public  double A(double B, double c) { return Math.Sqrt(B * B + c * c); }// method to calculate hypotenuse of right triangle   
        public  void STORE_POINT( int row,string name,double X,double Y)// method to store point in array
        {
            int r=1;
            for (int i = 0; i < 100; i++)
            {
                if (POINT[i, 0] == null)
                {
                    r = i;
                    break;
                }

            }


            POINT[r, 0] = row.ToString();
            POINT[r,1] = name;
            POINT[r,2] = X.ToString();
            POINT[r,3] = Y.ToString();

            
            Console.WriteLine("Point stored  row={0},name={1},X={2},Y={3}  ", POINT.GetValue(r,0 ), POINT.GetValue(r, 1) ,POINT.GetValue(r,2), POINT.GetValue(r,3)  );
           
        }
        public double angel (double A,double B,double C)// method to calculate angle from lengths of triangle sides

        {
           
           double Z= (Math.Pow(C, 2) + Math.Pow(B, 2) - Math.Pow(A, 2)) / (2 * B * C);

           return (Math.Acos(Z)); 
        }
        public static double Measure_distance(double x1, double y1, double x2, double y2)// method to calculate distance between two points
        {
            double x = Math.Pow(x1 - x2, 2);
            double y = Math.Pow(y1 - y2, 2);

            return Math.Sqrt(x + y);
        }
        

        public void new_point_measure(   string name, double x1, double y1, double x2, double y2, double A, double B,  int row=1, bool R = true)//a:  بعكس اتجاه عقارب الساعة 
        {


            
            double C = Measure_distance(x1, y1, x2, y2);
            if (((A + B) < C) || ((x1 == x2) && (y1 == y2)))
            {
                Console.WriteLine("ERROR: INVALID  INTERSECTION");
                return;
            }

            double a = angel_A(A, B, C);
            if (R == false) { a = -a; };
            
            double m0 = (y2 - y1) / (x2 - x1);// ميل المستقيم ab
            double m1 = Math.Tan(Math.Atan(m0) + a);  //ميل المستقيم ac
            double x;// احداثي x للنقطة الجديدة
            double y;// احداثي y للنقطة الجديدة
            


            double z = (Math.Pow(B, 2) - Math.Pow(A, 2) + Math.Pow(x2, 2) - Math.Pow(x1, 2) + Math.Pow(y2, 2) - Math.Pow(y1, 2));// حساب z
            x = (z / 2 + m1 * x1 * (y2 - y1) - y1 * (y2 - y1)) / ((x2 - x1) + m1 * (y2 - y1));// حساب احداثي x للنقطة الجديدة
            y = m1 * (x - x1) + y1;// حساب احداثي y للنقطة الجديدة





            int n = points.Count + 1;// موقع النقطة الجديدة في القاموس

            String ne = name + row.ToString();// انشاء اسم للنقطة الجديدة
            points.Add(ne, (x, y));// تخزين النقطة في القاموس
            Console.WriteLine("point stored in dictionary points:{0} ,{1}", ne, points[ne]);// اظهار النقطة المخزنة


            STORE_POINT(row, name, x, y); // تخزين النقطة


        }

              public static double angel_A(double A, double B, double C)// method to calculate angle from lengths of triangle sides

        {

            double Z = (Math.Pow(C, 2) + Math.Pow(B, 2) - Math.Pow(A, 2)) / (2 * B * C);
            double a=Math.Acos(Z);
            return a / DEGREE;
           
        }







       
    }
}
