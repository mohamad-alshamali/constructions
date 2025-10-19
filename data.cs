using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructions
{
    internal  class data 
    {
        public  Dictionary<string, (double X, double Y)> points = new Dictionary<string, (double X, double Y)>();// create dictionary to store points
        public  double[,] POINT=new double [100,100];// create array to store points
        public static string surveyors_list;// create static field to store surveyors list
        public static string  building_list;// create static field to store building list
        public static string approve_drawings_list;// create static field to store approve drawings list
        public static string survey_requests;// create static field to store survey requests list   
        public  double X(int ROW) 
        {

            
            
                return POINT[ROW,0];
            }
        public  double Y(int ROW)
        { 

            
           
            return POINT[ROW,1];
        }
        
        public  double DEGREE = 0.01745329251994329576;
        public  double A(double B, double c) { return Math.Sqrt(B * B + c * c); }// method to calculate hypotenuse of right triangle   
        public  void STORE_POINT( int row,double X,double Y)// method to store point in dictionary and array
        {
            int n = points.Count + 1;
            n = row + n;
            string name= "point " + n.ToString();
      
            points.Add(name, (X, Y));
            POINT[row, 0] = X; POINT[row, 1] =Y;
          
           
            Console.WriteLine("{0} stored in points:{1}",name, points[ name]);
            Console.WriteLine("new point stored X={1},Y={2} ,name:p({0})",row,POINT.GetValue(row,0 ), POINT.GetValue(row, 1));
           
        }
        public double angel_from_ab_to_ac_turn_left (double D1,double D2,double D3)// method to calculate angle from lengths of triangle sides

        {

           return (Math.Pow(D1, 2) + Math.Pow(D3, 2) - Math.Pow(D2, 2)) / (2 * D1 * D3);// return angle in radian
        }
        
        public  void  new_point_measure (int name, double x1, double y1 ,double x2,double y2,double D1,double D2 ,double a)// (a=b^2+c^2-a^2)/2ab // method to calculate new point coordinates and store it
        {


            double m0 = (y2 - y1) / (x2 - x1);// ميل المستقيم ab
            double m1; //ميل المستقيم ac
            double  x;// احداثي x للنقطة الجديدة
            double y;// احداثي y للنقطة الجديدة
                 

            m1 = (m0 + Math.Tan(a)) / (1 - m0 * Math.Tan(a));// حساب ميل المستقيم ac

          
            double z = (Math.Pow(D1, 2) - Math.Pow(D2, 2) + Math.Pow(x2, 2) - Math.Pow(x1, 2) + Math.Pow(y2, 2) - Math.Pow(y1, 2))/2;// حساب z

            x = (z + m1 * x1 * (y2 - y1) - y2 * (y2 - y1)) / (x2 - x1) + m1 * (y2 - y1);// حساب احداثي x للنقطة الجديدة
            y = m1 * (x - x1) + y1;// حساب احداثي y للنقطة الجديدة

            
            
            int n = points.Count + 1;// موقع النقطة الجديدة في القاموس
            String ne = "point " + name.ToString();// انشاء اسم للنقطة الجديدة
            points.Add(ne, (x, y));// تخزين النقطة في القاموس
            Console.WriteLine("{0} stored in points:{1}",ne, points[ne]);// اظهار النقطة المخزنة
            if (name > 100)
               Console.WriteLine("enter  name <100");// التحقق من صحة اسم النقطة
            else
                
            STORE_POINT(name, x, y); // تخزين النقطة
            Console.WriteLine(" measured point have stored in array :x={0},y={1} p({2})",X(name), Y(name),name);// اظهار النقطة المخزنة
            

            







        }
    }
}
