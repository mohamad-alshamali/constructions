using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace constructions 
{
    internal interface quantity
    {
        double Area(double x, double y, double z);
        double Area(double x, double y);

        double Volume(double area, double Approved_Level, double asbuilt_level);


    }
}
