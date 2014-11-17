using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2_WPF.Interfaces
{
    public interface IValidator
    {
        bool Validate(double value1, double value2);
        bool Validate(double value1);
    }
}
