using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_2_WPF.Interfaces;
using HW_2_WPF.Sourse_Code;

namespace HW_2_WPF.Implements
{
    public class Calculator : ICalculator
    {
        private IValidator validator;
        private delegate double OperationDelegateTwoValue(double x, double y);
        private delegate double OperationDelegateOneValue(double x);

        private Dictionary<string, OperationDelegateOneValue> _operationsOneValue;
        private Dictionary<string, OperationDelegateTwoValue> _operationsTwoValue;

        public Calculator()
        {
            validator = new Validator(-7.0, 36);
            _operationsTwoValue =
                new Dictionary<string, OperationDelegateTwoValue>
                {
                    { "Addition", this.DoAddition },
                    { "Subtraction", this.DoSubtraction },
                    { "Multiplication", this.DoMultiplication },
                    { "Division", this.DoDivision },
                };
            _operationsOneValue = new Dictionary<string, OperationDelegateOneValue>{
                {"SQR", this.DoSQR}, 
                {"SQRT", this.DoSQRT}
            };
        }

        public double Calculate(string operation, double value1, double value2)
        {
            if (!_operationsTwoValue.ContainsKey(operation))
                throw new OperationNotFoundException("Операция не найденна!!!");
            return _operationsTwoValue[operation](value1, value2);
        }

        public double Calculate(string operation, double value)
        {
            if (!_operationsOneValue.ContainsKey(operation))
                throw new OperationNotFoundException("Операция не найденна!!!");
            return _operationsOneValue[operation](value);
        }



        #region OperationsTwoValue
        private double DoDivision(double value1, double value2)
        {
            double rezult = 0.0;
            if (validator.Validate(value1, value2))
            {
                if (value2 == 0.0) { throw new DivideByZeroException("Деление на ноль!!!"); }
                try
                {
                    rezult = value1 / value2;
                }
                catch (Exception err) { throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения"); }
                if (validator.Validate(rezult))
                {
                    return rezult;
                }
                else throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения");
            }
            else throw new InputParametersRangeOutException("Входящие параменты выходят за допустимый диаппазон значений");
        }

        private double DoMultiplication(double value1, double value2)
        {
            double rezult = 0.0;
            if (validator.Validate(value1, value2))
            {
                try
                {
                    rezult = value1 * value2;
                }
                catch (Exception err) { throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения"); }
                if (validator.Validate(rezult))
                {
                    return rezult;
                }
                else throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения");
            }
            else throw new InputParametersRangeOutException("Входящие параменты выходят за допустимый диаппазон значений");
        }
        private double DoSubtraction(double value1, double value2)
        {
            double rezult = 0.0;
            if (validator.Validate(value1, value2))
            {
                try
                {
                    rezult = value1 - value2;
                }
                catch (Exception err) { throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения"); }
                if (validator.Validate(rezult))
                {
                    return rezult;
                }
                else throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения");
            }
            else throw new InputParametersRangeOutException("Входящие параменты выходят за допустимый диаппазон значений");
        }
        private double DoAddition(double value1, double value2)
        {
            double rezult = 0.0;
            if (validator.Validate(value1, value2))
            {
                try
                {
                    rezult = value1 + value2;
                }
                catch (Exception err) { throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения"); }
                if (validator.Validate(rezult))
                {
                    return rezult;
                }
                else throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения");
            }
            else throw new InputParametersRangeOutException("Входящие параменты выходят за допустимый диаппазон значений");
        }
        #endregion

        #region

        private double DoSQR(double value)
        {
            double rezult = 0.0;
            if (validator.Validate(value))
            {
                try
                {
                    rezult = value * value;
                }
                catch (Exception err) { throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения"); }
                if (validator.Validate(rezult))
                {
                    return rezult;
                }
                else throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения");
            }
            else throw new InputParametersRangeOutException("Входящие параменты выходят за допустимый диаппазон значений");
        }
        private double DoSQRT(double value)
        {
            double rezult = 0.0;
            if (validator.Validate(value))
            {
                try
                {
                    rezult = Math.Sqrt(value);
                }
                catch (Exception err) { throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения"); }
                if (validator.Validate(rezult))
                {
                    return rezult;
                }
                else throw new ResultRangeOutException("Результат операции выходит за пределы допустимого значения");
            }
            else throw new InputParametersRangeOutException("Входящие параменты выходят за допустимый диаппазон значений");
        }
        #endregion
    }
}