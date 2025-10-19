using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructions
{
    internal class document_control 
    {
        static void Main()
        {
           
            relation.new_point_measure("benchmarke", 0, 100, 100, 100, 50, 50, 0);// add benchmark point to relation points
            relation.new_point_measure("as builte", 100, 80, 30, 40, 50, 50, 1.5707963267948966);// add as builte point to relation points
            relation.Measure_distant(24, 34, 56, 77);
            //overloading constructor take one parameter 
            survey_report request1 = new survey_report( 1);
           Console.WriteLine(  " distant ",request1.Measure_distant(500, 350, 200, 250));
           Console.WriteLine(" angel a {0}" ,request1.angel_from_ab_to_ac_turn_left(150, 200, 316.227));
            request1.new_point_measure(50,20 ,10, 100, 10, 50, 50,0);
            request1.Measure_distant(500, 350, 200, 250);
            request1.angel_from_ab_to_ac_turn_left(150, 200, 316.227);
            request1.new_point_measure(51, 500, 350, 200, 250, 300, 200, 0.869623356312607);//  put angel as it must be if it measured in site for give right result

            request1.STORE_POINT(3, 54.5, 32.44);// store new point in request1 points

            Console.WriteLine("surveyor name: {0} ,\n" + // 
                " request no:{1},\n benchmarks: {2},\n" +
                " point:{3}, \n level={4},\n date:{5},\n " +
                "aproved level:{6},\n" +
                " measure:{7},\n" +
                " consltant name:{8},\n" +
                " DRAWING NUMBER:{9},\n" +//show request1 fields certained in constructor (one parameter)//
                " REQUEST STATUE:{10} ", request1.Surveyor_name, request1.Request_no, request1.Approved_benchmarks, request1.Approved_points, request1.Asbuilt_level, request1.Datetime, request1.Approved_Level, request1.Measurement_points, request1.Consultant_name, request1.Drawing_number, request1.Request_statue,request1.X(1),request1.Y(1),request1.X(2),request1.Y(2) ,request1.X(3),request1.Y(3));
            survey_report request2 = new survey_report(10, 20, 20, 30); // new object request2
            Console.WriteLine(" distant 1={0} ", request2.Measure_distant(20,30,40,50));//request2 SET field  measure_distant and return that value
            //MEASURE POINT IN REQUEST4 by constructor overloading take 7 parameter//
            survey_report REQUEST4 = new survey_report(70,30,40,50,30,20,20,1);// calculate new point coordinate  and add it to request4 points
            //Give value to request3 by constructor overloading take 4 parameter
            survey_report request3 = new survey_report(10, 20, 30, "school");
         
            // chang request3 statue
            request3.Request_statue = "rejected";
          //  add new POINTs to request3//
          
            Console.WriteLine(" X0={0},Y0={1},X1={2},Y1={3},X2={4},Y2={5},X3={6},Y3={7},", request3. X(0), request3.Y(0) ,request3.X(1), request3.Y(1),request3.X(2), request3.Y(2),request3.X(3), request3.Y(3));// show request3 points



            Console.WriteLine(" build name :{0}, volume:{1} ", request3.Build_name, request3.volume,request3.Request_no);// show request3 fields certained in constructor (four parameter)//

            request3.onstatuechange += Request3_onstatuechange;// subscribe event handler to event

            request3.check(" null");



         }

        private static void Request3_onstatuechange(string message)// event handler
        {
           Console.WriteLine("alert request survey report statue  not accepted  ");
        }

       
    }
}
