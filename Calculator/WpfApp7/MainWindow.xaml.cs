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

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string FirstNumberString;
        string SecondNumberString;
        double Result = 0;
        string MathOperator = "";
        string lastInputType = "";
        bool decimalAllow = true;
        bool zeroAllow = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ZeroButton_Click(object sender, RoutedEventArgs e)
        {

            Button selectedBtn = sender as Button;

            //Append
            lblExpression.Content = lblExpression.Content + selectedBtn.Content.ToString();

            if (lastInputType == "")

            {
                //First Number
                FirstNumberString = FirstNumberString + selectedBtn.Content.ToString();

            }
            else if (lastInputType == "Operator")
            {
                //Second Number
                SecondNumberString = SecondNumberString + selectedBtn.Content.ToString();
            }
            zeroAllow = false;
        }
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button selectedBtn = sender as Button;
            //MessageBox.Show(selectedBtn.Content.ToString());
            lblExpression.Content = lblExpression.Content + selectedBtn.Content.ToString();

            if (lastInputType == "")

            {
                //First Number
                FirstNumberString = FirstNumberString + selectedBtn.Content.ToString();

            }
            else if (lastInputType == "Operator")
            {
                //Second Number
                SecondNumberString = SecondNumberString + selectedBtn.Content.ToString();

            }

            lastInputType = "";
        }
        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button selectedBtn = sender as Button;

            //Checking
            if (lastInputType == "Operator")
            {
                //Replace lblExpression last character with current operator key

                //Substring
                lblExpression.Content = lblExpression.Content.ToString().Substring(0, lblExpression.Content.ToString().Length - 1);

                //Append
                lblExpression.Content = lblExpression.Content + selectedBtn.Content.ToString();
            }
            else
            {
                //Append
                lblExpression.Content = lblExpression.Content + selectedBtn.Content.ToString();
            }

            MathOperator = selectedBtn.Content.ToString();
            lastInputType = "Operator";
            decimalAllow = true;

        }
        private void DecimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimalAllow)
            {
                return;
            }

            Button selectedBtn = sender as Button;

            if (lastInputType == "")

            {
                //First Number
                FirstNumberString = FirstNumberString + selectedBtn.Content.ToString();
            }
            else if (lastInputType == "Operator")
            {
                //Second Number
                SecondNumberString = SecondNumberString + selectedBtn.Content.ToString();

            }


            //Append
            lblExpression.Content = lblExpression.Content + selectedBtn.Content.ToString();

            decimalAllow = false;
        }
        private void EvaluateExp_Click(object sender, RoutedEventArgs e)
        {
            switch (MathOperator)
            {
                case "+":
                    Result = Convert.ToDouble(FirstNumberString) + Convert.ToDouble(SecondNumberString);
                    break;
                case "-":
                    Result = Convert.ToDouble(FirstNumberString) - Convert.ToDouble(SecondNumberString);
                    break;
                case "*":
                    Result = Convert.ToDouble(FirstNumberString) * Convert.ToDouble(SecondNumberString);
                    break;
                case "/":
                    Result = Convert.ToDouble(FirstNumberString) / Convert.ToDouble(SecondNumberString);
                    break;
                default:
                    break;
            }
            lblResult.Content = Result;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (lblExpression.Content.ToString().Length > 0)
            {
                lblExpression.Content = lblExpression.Content.ToString().Substring(0, lblExpression.Content.ToString().Length - 1);
            }
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (lblExpression.Content.ToString().Length > 0)
            {
                lblExpression.Content = "";   
            }
            else
            {
                lblResult.Content = 0;
            }
            
            Result = 0;
        }

    }
}


