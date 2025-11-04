using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace constructions
{
    internal class data
    {


        protected string build_name;
        protected int request_no;


        public static void write(string build, int req, string number/*,ref string build_name, ref int request_no*/)
        {
            string path = string.Format("C:\\{0}{1}.txt", build, req);


            FileStream fsw = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsw);

            sw.WriteLine(number);
            sw.Close();
            fsw.Close();
        }

 
    
       
       public  void show_point(string file_name,  string point_name="all",int num = 0)
       {
           
            string path = string.Format("C:\\{0}.txt", file_name);
            if (File.Exists(path))
            {
             
                string[] line = File.ReadLines(path).ToArray();


                if (num == 0)
                {
                    for (int i = 0; i < line.Length; i++)
                    { 
                        if (line[i].Substring(6, 10) == string.Format("{0,10}", point_name))

                            Console.WriteLine("{0}", line[i]);
                        else if (point_name=="all")
                            Console.WriteLine("{0}", line[i]);


                        }
                }

            






                else if (num != 0)
                {
                    if ((num < line.Length) || (num < 0))

                        Console.WriteLine("{0}", line[num - 1]);

                    else Console.WriteLine("point not exist");

                }
                

            }
            else
            {
                Console.WriteLine("file not exist"); 
            }

       }

        
        public  void write_counter(string build, int req, int row)
        {
           
            string counter1 = string.Format("C:\\{0}{1}{2}.txt",build,req,"counter");
        FileStream fsw = new FileStream(counter1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fsw);

            sw.Write(row);
            sw.Close();
            fsw.Close() ;

        }
        public  int read_counter(string build, int req)
        {
            string counter1 = string.Format("C:\\{0}{1}{2}.txt", build, req,"counter");
            FileStream fsr = new FileStream(counter1, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fsr);
           string C=sr.ReadLine();
            sr.Close();
            fsr.Close();
            if (string.IsNullOrEmpty(C))
                return 0;
            else

            return int.Parse(C);
            
        }



        private Dictionary<string, (double X, double Y)> points = new Dictionary<string, (double X, double Y)>();// create dictionary to store points
        public  string[,] POINT=new string [100,4];// create array to store points
       
        
       

       private static string surveyors_list;// create static field to store surveyors list
        private static string  building_list;// create static field to store building list
        private static string approve_drawings_list;// create static field to store approve drawings list
        private static string survey_requests;// create static field to store survey requests list
                                             //   public static double DEGREE = 0.01745329251994329576;
        private const double RADIAN = 57.2957795130823208768;
        private const double PI = 3.14159265358979323846;
        private const double DEGREE = 0.01745329251994329576;

        public  string X(int ROW ) 
        {

                return POINT[ROW,2];
            }
        public  string Y(int ROW)
        { 

            
           
            return POINT[ROW,3];
        }
        private  string NAME(int ROW)
        {return POINT[ROW,1]; }

       
        public  double A(double B, double c) { return Math.Sqrt(B * B + c * c); }// method to calculate hypotenuse of right triangle   
        public  void STORE_POINT(string point_name,double X,double Y)// method to store point in array
        {
         
          int  C=read_counter(build_name,request_no);

            for (int i = C+1; i < 100; i++)
            {
                if (POINT[i, 0] == null)
                {

                    C= i;
                    break;
                }

            }
            
            POINT[C, 0] = C.ToString();
            POINT[C,1] = point_name;
            POINT[C,2] = X.ToString();
            POINT[C,3] = Y.ToString();
            
            write(build_name,request_no ,string.Format("{0,5} {1,10} {2,10:F3} {3,10:F3}", C, point_name, X,Y));
            
            write_counter(build_name, request_no, C);

            Console.WriteLine("Point stored  row={0},name={1},X={2},Y={3} , ", POINT.GetValue(C,0 ), POINT.GetValue(C, 1) ,POINT.GetValue(C,2), POINT.GetValue(C,3)  );
           
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

        int row = 1;
        public void new_point_measure(   string name, double x1, double y1, double x2, double y2, double A, double B,   bool R = true)//a:  بعكس اتجاه عقارب الساعة 
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


            STORE_POINT( name, x, y); // تخزين النقطة
            row++;
            

        }

              public static double angel_A(double A, double B, double C)// method to calculate angle from lengths of triangle sides

        {

            double Z = (Math.Pow(C, 2) + Math.Pow(B, 2) - Math.Pow(A, 2)) / (2 * B * C);
            double a=Math.Acos(Z);
            return a / DEGREE;
           
        }







       
    }
}
