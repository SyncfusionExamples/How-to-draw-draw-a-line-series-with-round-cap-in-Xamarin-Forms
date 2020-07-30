using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSample
{
    public class Model
    {
        public DateTime Date { get; set; }
        public double YValue1 { get; set; }
        public double YValue2 { get; set; }
        public double YValue3 { get; set; }
        public double YValue4 { get; set; }

        public Model(DateTime date, double yValue1, double yValue2, double yValue3, double yValue4)
        {
            Date = date;
            YValue1 = yValue1;
            YValue2 = yValue2;
            YValue3 = yValue3;
            YValue4 = yValue4;
        }
    }
}
