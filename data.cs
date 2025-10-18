using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructions
{
    internal  class data 
    {
        
        public  double[,] POINT=new double [100,100];
        public static string surveyors_list;
        public static string  building_list;
        public static string approve_drawings_list;
        public static string survey_requests;
        public  double X(int ROW) 
        {

            
            
                return POINT[ROW,0];
            }
        public  double Y(int ROW)
        { 

            

            return POINT[ROW,1];
        }
       public  void STORE_POINT( int row,double X,double Y)
        {
            
            POINT[row, 0] = X; POINT[row, 1] =Y;
            Console.WriteLine("new point stored X={1},Y={2} ,name:p({0})",row,POINT.GetValue(row,0 ), POINT.GetValue(row, 1));
           
        }
        public double angel_A (double D1,double D2,double D3)

        {

           return (Math.Pow(D1, 2) + Math.Pow(D3, 2) - Math.Pow(D2, 2)) / (2 * D1 * D3);
                }
        /*pointa,pointb,distant_to_a,distant_to_b,angel_(bac)(c is new point)*/
        public  void  new_point_measure (int name, double x1, double y1 ,double x2,double y2,double D1,double D2 ,double a)// (a=b^2+c^2-a^2)/2ab 
        {
            
             
            double m0 = (y2 - y1) / (x2 - x1);// ميل المستقيم ab
            double m1; //ميل المستقيم ac
            double  x;
            double y;
            //m1 :ميل المستقيم ac,m0: ميل المستقيم ab,a: الزاوية cab,x1,y1 : احداثيات البينشمرك الاول,x2,y2 احداثيات البينشمرك الثاني
            //m1=(m0+tan(a))/(1-m0tan(a))
            m1 = (m0 + Math.Tan(a)) / (1 - m0 * Math.Tan(a));

            // d1,d2ونصف قطرهما  a,b  يستنتج من معادلتي الدائرتين التي مركزهما   
            double z = (Math.Pow(D1, 2) - Math.Pow(D2, 2) + Math.Pow(x2, 2) - Math.Pow(x1, 2) + Math.Pow(y2, 2) - Math.Pow(y1, 2))/2;
           
                x = (z + m1 * x1 * (y2 - y1) - y2 * (y2 - y1)) / (x2 - x1) + m1 * (y2 - y1);
                y = m1 * (x - x1) + y1;
           
                //في حال الرفع المساحي

               if (name > 100)
               Console.WriteLine("renter  name <100") ;
            else
                STORE_POINT(name, x, y); // تخزين النقطة
            
            Console.WriteLine(" measured point have stored:x={0},y={1} p({2})",X(name), Y(name),name);// اظهار النقطة المخزنة
            ;
            







        
        }
    }
}
