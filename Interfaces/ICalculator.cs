using HW_2_WPF.Sourse_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_WPF.Interfaces
{
    public interface ICalculator
    {
        double Calculate(string operation, double value1, double value2);
        double Calculate(string operation, double value1);
    }
}
