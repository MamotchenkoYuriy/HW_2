using HW_2_WPF.Implements;
using HW_2_WPF.Interfaces;
using HW_2_WPF.Sourse_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_2_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Текущее значение выполненых операций калькулятором
        private double curentValue = 0.0;
        
        private ICalculator calk;
        // вверху текст бокса есть label в который записывается последвательность всех операций
        // собственно в этой переменной и храниться эта последовательность операций
        private string lastOperation = string.Empty;
        // Нужна для того, что бы понять ввели ли мы какой либо текст уже после выполнения какой либо операции
        // Получается что мы скачала вводим какое то значения в текстбокс, после выполняем какие то вычисления
        // и результат записываем снова в этот же текст бокс. Ну и для того что бы знать что там находиться результат уже, 
        // а не то что мы вводим и нужна эта переменная
        private bool inputText = false;
        private Validator validator;
        
        public MainWindow()
        {
            InitializeComponent();
            calk = new Calculator();
            //tb_Result.IsReadOnly = true;
            tb_Result.AppendText("0");
            validator = new Validator(-7.0, 36.0);
        }

        private void btnValueClick(object sender, RoutedEventArgs e)
        {
            var clickedBtn = (Button)sender;
            if (lastOperation != "")
            {
                if(!inputText)
                {
                    tb_Result.Clear();
                    tb_Result.AppendText("0");
                    inputText = true;
                }

                var inputBtnName = clickedBtn.Name.Replace("_", "");
                if (tb_Result.Text == "0")
                {
                    if (inputBtnName != "0")
                    {
                        if (inputBtnName.Length > 1) { tb_Result.AppendText("."); }
                        else { tb_Result.Clear(); tb_Result.AppendText(inputBtnName); }
                    }
                    else
                    {
                        if (inputBtnName.Length > 1)
                        {
                            if (!tb_Result.Text.Contains(".")) { tb_Result.AppendText("."); }
                        }
                        else { tb_Result.AppendText(inputBtnName); }
                    }
                }
                else
                {
                    if (inputBtnName.Length > 1)
                    {
                        if (!tb_Result.Text.Contains(".")) { tb_Result.AppendText("."); }
                    }
                    else 
                    {
                        tb_Result.AppendText(inputBtnName); 
                    }
                }
            }
            else
            {
                var inputBtnName = clickedBtn.Name.Replace("_", "");
                if (tb_Result.Text == "0")
                {
                    if (inputBtnName != "0")
                    {
                        if (inputBtnName.Length > 1) { tb_Result.AppendText("."); }
                        else { tb_Result.Clear(); tb_Result.AppendText(inputBtnName); }
                    }
                    else
                    {
                        if (inputBtnName.Length > 1)
                        {
                            if (!tb_Result.Text.Contains(".")) { tb_Result.AppendText("."); }
                        }
                        else { tb_Result.AppendText(inputBtnName); }
                    }
                }
                else
                {
                    if (inputBtnName.Length > 1)
                    {
                        if (!tb_Result.Text.Contains(".")) { tb_Result.AppendText("."); }
                    }
                    else { tb_Result.AppendText(inputBtnName); }
                }
            }
        }



        // Можно было бы все это поток красиво причисать с помощью Dictionary и delegate, 
        // но уже пускай остается все это как есть. Если появиться время то обязательно причешу все
        private void btnActionClick(object sender, RoutedEventArgs e)
        {
            inputText = false;
            var clickedBtn = (Button)sender;
            if(clickedBtn.Name == "CE")
            {
                tb_Result.Clear();
                tb_Result.AppendText("0");
                return;
            }
            else if(clickedBtn.Name == "C")
            {
                tb_Result.Clear();
                tb_Result.AppendText("0");
                lastOperation = string.Empty;
                return;
            }
            // нажали на = клавишу
            if(!validator.Validate(Convert.ToInt32(tb_Result.Text))){
                MessageBox.Show("Вы ввели значение превышающее диапазон возиожных значений!!!");
                tb_Result.Clear();
                tb_Result.AppendText("0");
                return;
            }
            if (clickedBtn.Name == "Equils")
            {
                if (lastOperation!="")
                {
                    double returnValue = 0.0;
                    try
                    {
                        returnValue = calk.Calculate(lastOperation, curentValue, Convert.ToDouble(tb_Result.Text));
                        lblOperations.Content += returnValue + "" + GetShortName(lastOperation);
                        tb_Result.Clear();
                        tb_Result.AppendText(returnValue.ToString());
                    }
                    catch (InputParametersRangeOutException err) { MessageBox.Show(err.Message); StartNewCalculate(); }
                    catch (ResultRangeOutException err) { MessageBox.Show(err.Message); StartNewCalculate(); }
                    catch (OperationNotFoundException err) { MessageBox.Show(err.Message); StartNewCalculate(); }
                    catch (DivideByZeroException err) { MessageBox.Show(err.Message); StartNewCalculate(); }
                    finally
                    {
                        tb_Result.Clear();
                        tb_Result.AppendText("0");
                        curentValue = 0.0;
                        lblOperations.Content += returnValue + "" + GetShortName(lastOperation);
                    }
                }
                else
                {
                    curentValue = 0.0;
                    lastOperation = "";
                    lblOperations.Content = "";
                    tb_Result.Clear();
                }
                lblOperations.Content = "";
                lastOperation = "";
            }
            // нажали на любую другую кнопку кроме =
            else 
            {
                if (lastOperation == "")
                {
                    curentValue = Convert.ToDouble(tb_Result.Text);
                    lastOperation = clickedBtn.Name;
                    lblOperations.Content = curentValue + "" + GetShortName(lastOperation);
                    tb_Result.Clear();
                }
                else
                {
                    double returnValue = 0.0;
                    try
                    {
                        returnValue = calk.Calculate(lastOperation, curentValue, Convert.ToDouble(tb_Result.Text));
                        curentValue = Convert.ToDouble(returnValue);
                        lblOperations.Content += tb_Result.Text + "" + GetShortName(clickedBtn.Name);
                        tb_Result.Clear();
                        tb_Result.AppendText(returnValue.ToString());
                        lastOperation = clickedBtn.Name;
                        Convert.ToDouble(returnValue);
                    }
                    catch (InputParametersRangeOutException err) { MessageBox.Show(err.Message); StartNewCalculate();}
                    catch (ResultRangeOutException err) { MessageBox.Show(err.Message);StartNewCalculate() ;}
                    catch (OperationNotFoundException err) { MessageBox.Show(err.Message);StartNewCalculate(); }
                    catch (DivideByZeroException err) { MessageBox.Show(err.Message); StartNewCalculate(); }
                    catch (Exception err)
                    {
                        tb_Result.Clear();
                        tb_Result.AppendText(returnValue.ToString());
                        curentValue = 0.0;
                        lblOperations.Content = "";
                    }
                }
            }
        }

        public void StartNewCalculate()
        {
            tb_Result.Clear();
            tb_Result.AppendText("0");
            curentValue = 0.0;
            lblOperations.Content = "";
        }

        private bool IsTwoValueOperation(string operationName)
        {
            if ((operationName != OperationType.SQR.ToString()) && (operationName != OperationType.SQRT.ToString())) 
            { 
                return true; 
            }
            else return false;
        }

        private string GetShortName(string operationName)
        {
            if (operationName == OperationType.Addition.ToString()) { return "+"; }
            else if (operationName == OperationType.Division.ToString()) { return "/"; }
            else if (operationName == OperationType.Multiplication.ToString()) { return "*"; }
            else if (operationName == OperationType.Subtraction.ToString()) { return "-"; }
            else return "";
        }

    }
}
