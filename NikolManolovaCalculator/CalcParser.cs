using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NikolManolovaCalculator
{
    class CalcParser
    {       
        public enum DisplayMode
        {
            CLEAR, APPEND
        }

        public enum Operator
        {
            PLUS, MINUS, DIVIDE, TIMES, EQUAL
        }

        private DisplayMode displayMode = DisplayMode.CLEAR;
        private Operator op = Operator.EQUAL;
        private TextBox tbDisplay;
        private double total; // Our current calculated number
        private double mem;

        public CalcParser(TextBox tbDisplay)
        {
            this.tbDisplay = tbDisplay;
        }

        public void MS()
        {
            mem = GetCurrentValue();
            displayMode = DisplayMode.CLEAR;
        }

        public void MPLUS()
        {            
            mem += GetCurrentValue();
            displayMode = DisplayMode.CLEAR;
        }

        public void MMINUS()
        {
            mem -= GetCurrentValue();
            displayMode = DisplayMode.CLEAR;
        }

        public void MR()
        {
            tbDisplay.Text = "" + mem;
            displayMode = DisplayMode.CLEAR;
        }

        public void MC()
        {
            mem = 0;
            displayMode = DisplayMode.CLEAR;
        }

        public void CE()
        {
            tbDisplay.Text = "0";
            displayMode = DisplayMode.CLEAR;
        }

        public void C()
        {
            CE();
            total = 0;
            op = Operator.EQUAL;
        }

        public void PutDot()
        {
            if (!tbDisplay.Text.Contains(","))
            {
                tbDisplay.Text += ",";
            }
        }

        public void Backspace()
        {
            string disp = tbDisplay.Text;

            if (disp.Length == 1)
            {
                tbDisplay.Text = "0";
                displayMode = DisplayMode.CLEAR;
            }
            else
            {
                disp = disp.Substring(0, disp.Length - 1);
                tbDisplay.Text = disp;
            }
        }

        public double GetCurrentValue()
        {
            return double.Parse(tbDisplay.Text);
        }

        public void oneOverX()
        {
            double result = 1 / GetCurrentValue();
            tbDisplay.Text = "" + result;
            displayMode = DisplayMode.CLEAR;
        }

        public void Percent()
        {
            if (op == Operator.TIMES)
            {
                double result = GetCurrentValue() / 100;
                tbDisplay.Text = "" + result;
                displayMode = DisplayMode.CLEAR;
            }
            else
            {
                tbDisplay.Text = "" + 0;
                displayMode = DisplayMode.CLEAR;
            }
        }

        public void Sqrt()
        {
            double result = Math.Sqrt(GetCurrentValue());
            tbDisplay.Text = "" + result;
            displayMode = DisplayMode.CLEAR;
        }

        public void AddSymbol()
        {
            if (GetCurrentValue() == 0)
                return;

            if (!tbDisplay.Text.StartsWith("-"))
            {
                tbDisplay.Text = "-" + tbDisplay.Text;
            }
            else
            {
                tbDisplay.Text = tbDisplay.Text.Substring(1);
            }
        }

        public void Calculate(Operator newOperator)
        {
            Operator oldOperator = this.op;
            this.op = newOperator;
            double curValue = GetCurrentValue();
            displayMode = DisplayMode.CLEAR;

            switch (oldOperator)
            {
                default:
                    total = curValue;
                    return;
                case Operator.PLUS:
                    total += curValue;
                    break;
                case Operator.MINUS:
                    total -= curValue;
                    break;
                case Operator.DIVIDE:
                    total /= curValue;
                    break;
                case Operator.TIMES:
                    total *= curValue;
                    break;
            }

            tbDisplay.Text = "" + total;
        }

        public void AddDigit(char digit)
        {
            double curValue = GetCurrentValue();

            if (curValue == 0 && tbDisplay.Text.Contains(","))
            {
                tbDisplay.Text += digit;
                displayMode = DisplayMode.APPEND;
            }
            else
            {
                if (curValue == 0 && digit == '0')
                    return;

                if (displayMode == DisplayMode.CLEAR)
                {
                    tbDisplay.Text = "" + digit;
                    displayMode = DisplayMode.APPEND;
                }
                else
                {
                    tbDisplay.Text += digit;
                }
            }
        }
    }
}
