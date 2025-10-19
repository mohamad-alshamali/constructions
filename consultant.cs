using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructions
{
    internal  abstract class consultant :data
    {
        /*fields*/
        protected string datetime;//Field
        protected string consultant_name;//Field

        protected string approved_benchmarks;//Field
        protected string approved_points;//Field

        protected double approved_Level;//Field
        /*propert */
        public abstract string Datetime { get; set; }//abstract Property

        public abstract string Consultant_name { set; get; }//abstract Property

        public abstract string Approved_benchmarks { set; get; }//abstract Property
        public abstract string Approved_points { set; get; }//abstract Property

        public abstract double Approved_Level { set; get; }//abstract Property
        /*method*/

        public abstract double Deference(double index1, double index2);//abstract method

    }
}
