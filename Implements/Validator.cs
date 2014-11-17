using HW_2_WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_2_WPF.Implements
{
    public class Validator:IValidator
    {
        private double MinValue { get; set; }
        private double MaxValue { get; set; }
        public Validator(double minValue, double maxValue)
        {
            MinValue = minValue; MaxValue = maxValue;
        }

        public bool Validate(double value1, double value2)
        {
            if (Validate(value1) && Validate(value2))
            { return true; }
            else { return false; }
        }

        public bool Validate(double value)
        {
            if ((value >= MinValue) && (value <= MaxValue)) { return true; }
            else { return false; }
        }
    }
}
