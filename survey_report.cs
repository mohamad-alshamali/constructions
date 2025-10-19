using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructions
{
    public delegate void Notify(string message);//*delegate declaration*/
    internal class survey_report :consultant, quantity//*derived class from abstract class consultant and interface quantity*/
    {
        
        protected int request_no;/*field*/
        protected string request_statue;/*field*/
        protected string build_name;/*field*/
        protected int drawing_number;/*field*/
        protected string surveyor_name;/* field*/
        protected string measurement_points;/*field*/
        protected double asbuilt_level;//field
        public double area;//field
        protected double measure_distant;//field
        public event Notify onstatuechange;//*event declaration*/



        public virtual void check (string statue) //method to check request statue and trigger event if not accepted
        {
            if (request_statue != "accepted")

                onstatuechange?.Invoke("request survey report statue : not accepted  ");
                }
               

               

        public double volume;//field

        public override string Datetime//override property

        {
            get { return datetime; }
            set { datetime = value; }
        }
        public override string Consultant_name//override property
        { 
            set { consultant_name = value; } 
            get { return consultant_name; }

        }

        public string Surveyor_name // property
        {
            set { surveyor_name = value; }
            get { return surveyor_name; }
            
        }
        public override string Approved_benchmarks //override property
        {
            get { return approved_benchmarks; }

            set { approved_benchmarks = value; }
        }
        public int Request_no //  property
        {
            set { request_no = value; }
            get { return request_no; }
        }
        public string Build_name /* property*/
        {
            set { build_name = value; }
            get { return build_name; }
        }


        public int Drawing_number /* property*/

        {
            set { drawing_number = value; }
            get { return drawing_number; }
        }
        public string Request_statue // property
        {
            get { return request_statue; }
            set { request_statue = value; }

           
        }
    

   
        public override double Approved_Level /*override property*/
        {
            get { return approved_Level; }
            set { approved_Level = value; }
        }

        public double Asbuilt_level // property
        {
            get { return asbuilt_level; }
            set { asbuilt_level = value; }
        }

        public override string Approved_points //override property
        {
            get { return approved_points; }
            set { approved_points = value; }

        }
        public string Measurement_points // property
        {
            get { return measurement_points; }
            set { measurement_points = value; }
        }

        public double Measure_distant(double x1, double y1, double x2, double y2)//inherant method from enterface conseltat1
        {
            double x = Math.Pow(x1 - x2, 2);
            double y = Math.Pow(y1 - y2, 2);
            measure_distant =Math.Sqrt(x + y);
            return  Math.Sqrt(x + y);
        }
        public double Area(double x, double y, double z)//override method from interface quantity
        {
            double s = (x + y + z) / 2;
            return Math.Sqrt(s * (s - x) * (s - y) * (s - z));
        }
        public double Area(double x, double y) //override method from interface quantity
        {
            return x * y;

        }
        public override double Deference(double index1, double index2)//override method from abstract class consultant
        {
            return index1 - index2;

        }
        public double Volume(double area, double Approved_Level, double asbuilt_level)//method from interface quantity
        { return area * (Approved_Level - asbuilt_level); 
           
        }


        public survey_report()//default constructor
        {

            Surveyor_name = "mohamad alshamali";
            Request_no =0;
            Consultant_name = "name";

            Datetime = "2025";

            Build_name = "school";


            Request_statue = "null";

            Approved_benchmarks = " X1=100,Y1=100,X2=0,Y2=0";
            Approved_points = " X1=,Y1=";
            Approved_Level = 5;
            Measurement_points = " X1=,Y1=";
            Drawing_number = 333;
          
            

        }
        public survey_report(int x)//overloading constructor take one parameter

        {
            POINT.GetValue(0,0);   
            request_no = x;
            
            
        }

           



        
        public survey_report(double x1, double y1, double x2, double y2)//overloading constructor take four parameter
        {

            measure_distant = Measure_distant(x1, y1, x2, y2);


        }

        public survey_report(double x, double y, double z)//overloading constructor take three parameter
        {

            area = Area(x, y, z);



        }
        public survey_report(double area, double Approved_Level, double asbuilt_level, string build_name)//overloading constructor take four parameter

        {

            volume = Volume(area, Approved_Level, asbuilt_level);
            Build_name = build_name;
        }

        public survey_report( int n ,double x1, double y1, double x2, double y2, double A, double B, double m1)//overloading constructor take seven parameter
        { 
            new_point_measure(n,x1, y1, x2, y2, A, B, m1);


        }

    }
}
