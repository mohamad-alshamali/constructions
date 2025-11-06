using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace constructions
{
    internal static  class relation
    {
        static int counter = 0;
        private const int NameFieldLength = 10;
       
        public struct record
        { public int num; public string name; public double X; public double y; }
        static string path = "C:\\IPG203.txt";
        public static void Write(int num, string name, double X, double Y )
        {
            var nameBytes = new byte[NameFieldLength];
            var ascii = Encoding.ASCII.GetBytes(name);
            Array.Copy(ascii, nameBytes, Math.Min(ascii.Length, NameFieldLength));
            using (var fw = new FileStream(path, FileMode.Append, FileAccess.Write))
            using (var bw = new BinaryWriter(fw))
               
             {
              //  fw.Position =pos;
               bw.Write(num);
               bw.Write(nameBytes);
               bw.Write(X);
               bw.Write(Y);
             }
          
        }
     
        public static record Read( int num, string name, double X, double Y)
        {
            record req;
           
            
            if (!File.Exists(path))
            {req.num = 0; req.name= name; req.X= X;req.y = Y;
                Console.WriteLine("File not found  new file created.");
              
              return req;
            }
            int recordSize = sizeof(int) + NameFieldLength+  sizeof(double) * 2;


            using (FileStream fr = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            using (BinaryReader br = new BinaryReader(fr, Encoding.UTF8))
            {
                if (fr.Length < recordSize)
                {
                    req.num = 0;
                    req.name = name;
                    req.X = X;
                    req.y = Y;
                    return req;
                }
                   
               
                    // position at the start of the *last* full record
                    fr.Seek(fr.Length- recordSize, SeekOrigin.Begin);
                int n = (int)fr.Length / recordSize;
                num = br.ReadInt32();
                var nameBytes = br.ReadBytes(NameFieldLength);
                name = Encoding.ASCII.GetString(nameBytes).TrimStart('\0');
                X = br.ReadDouble();
                Y = br.ReadDouble();



                req.num = num; req.name = name; req.X = X; req.y = Y;
                return req;
            }
      }
        public static void STORE_POINT(string name, double X, double Y)// method to store point in dictionary
        {
            int num = counter;
            if (counter == 0)
            {
                record r = Read(counter, name, X, Y);

                counter = r.num+1;
            }

           else { counter++; }

           
            points.Add(num, (name, X, Y));
            Console.WriteLine("{0 }", num);

            Console.WriteLine("new point stored in {2} Num:{0} {1}", num, points[num], path);

            Write(num, name, X, Y);
           
        }





        public static Dictionary<int, (string  name,double X, double Y)> points = new Dictionary<int, (string name ,double X, double Y)>();// create dictionary to store points
        public static double DEGREE = 0.01745329251994329576;
        public static double RADIAN = 57.2957795130823208768;
        public static double PI = 3.14159265358979323846;   
        public static double[,] POINT = new double[100, 100];
        private static object bw;

        //المثلث القائم
        public static double A(double B, double c) {return  Math.Sqrt(B * B + c * c); }// method to calculate hypotenuse of right triangle
        
        public static double angelA(double b,double c,double angel) { return Math.Sqrt(b * b + c * c -2*b*c* Math.Cos(angel)); }// قانون جيب التمام لاستنتاج طول الضلع المجهول في المثلث من طول ضلعين والزاوية المحصورة بينهما
       
        public static double angel_A(double A, double B, double C)// method to calculate angle from lengths of triangle sides

        {

            double Z = (Math.Pow(C, 2) + Math.Pow(B, 2) - Math.Pow(A, 2)) / (2 * B * C);
            double a=Math.Acos(Z);
            return  a/ DEGREE;
           
        }
        
        public static void new_point_measure(string name, double x1, double y1, double x2, double y2, double A, double B,  bool  R=true  )//RIGHT OR LEFT:  بعكس اتجاه عقارب الساعة
        {
            double C = Measure_distance(x1, y1, x2, y2);


          double  a = DEGREE*angel_A(A, B, C);
            if (((A+B)<C)||((x1==x2)&&( y1==y2)))
            {
                Console.WriteLine("ERROR: INVALID  INTERSECTION");
                return;
            }


            if (R==false) {a=-a; }

            double m0 = (y2 - y1) / (x2 - x1);// ميل المستقيم ab
            double g= Math.Atan(m0);
            double m1=Math.Tan( a+g); //ميل المستقيم ac
            double x;// احداثي x للنقطة الجديدة   
            double y;// احداثي y للنقطة الجديدة
                     
             


            double z = (Math.Pow(B, 2) - Math.Pow(A, 2) + Math.Pow(x2, 2) - Math.Pow(x1, 2) + Math.Pow(y2, 2) - Math.Pow(y1, 2)) ;// حساب z
            x = (z/2 + m1 * x1 * (y2 - y1) - y1 * (y2 - y1)) / ((x2 - x1) + m1 * (y2 - y1));// حساب احداثي x للنقطة الجديدة
            y = m1 * (x - x1) + y1;// حساب احداثي y للنقطة الجديدة

         STORE_POINT( name, x, y );
          
        }

       
        
        public static double Measure_distance(double x1, double y1, double x2, double y2)// method to calculate distance between two points
        {
            double x = Math.Pow((x1 - x2), 2);
            double y = Math.Pow((y1 - y2), 2);
          
            return  Math.Round(Math.Sqrt (x + y));
        }
    }
    }
