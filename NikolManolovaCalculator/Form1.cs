using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NikolManolovaCalculator
{
    public partial class Form1 : Form
    {
        private CalcParser calcParser;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void TryAddDigit(object sender)
        {
            Button btn = (Button)sender;
            calcParser.AddDigit(btn.Text[0]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calcParser = new CalcParser(this.tbDisplay);
            MaximizeBox = false;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            TryAddDigit(sender);
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            calcParser.Backspace();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            calcParser.CE();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            calcParser.C();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            calcParser.PutDot();
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            btnM.Text = "";
            calcParser.MC();
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            calcParser.MR();
        }

        private void btnMS_Click(object sender, EventArgs e)
        {
            btnM.Text = "M";
            calcParser.MS();
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            btnM.Text = "M";
            calcParser.MPLUS();
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            btnM.Text = "M";
            calcParser.MMINUS();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            calcParser.Calculate(CalcParser.Operator.DIVIDE);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            calcParser.Calculate(CalcParser.Operator.PLUS);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            calcParser.Calculate(CalcParser.Operator.MINUS);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            calcParser.Calculate(CalcParser.Operator.TIMES);
        }

        private void btnAddSymbol_Click(object sender, EventArgs e)
        {
            calcParser.AddSymbol();
        }

        private void btnFraction_Click(object sender, EventArgs e)
        {
            calcParser.oneOverX();
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            calcParser.Sqrt();
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            calcParser.Calculate(CalcParser.Operator.EQUAL);
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            calcParser.Percent();
        }
    }
}
