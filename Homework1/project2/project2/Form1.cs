using System;
using System.Windows.Forms;

namespace project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Calculator
        {
            public static double MyCalculator(double num1, double num2, string op)
            {
                double answer = 0;
                switch (op)
                {
                    case "+":
                        answer = num1 + num2;
                        break;
                    case "-":
                        answer = num1 - num2;
                        break;
                    case "*":
                        answer = num1 * num2;
                        break;
                    case "/":
                        answer = num1 / num2;
                        break;
                    default:
                        break;
                }
                return answer;
            }
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            double firstNum = 0, secondNum = 0;
            double answer;
            string op;
            bool endCal = false;
            while (!endCal)
            {
                label1.Text = "";//将答案处提前清空

                string firstInput = textBox1.Text;
                if (!double.TryParse(firstInput, out firstNum))
                {
                    MessageBox.Show("请输入第一个操作数！");
                    break;
                }

                string secondInput = textBox2.Text;
                if (!double.TryParse(secondInput, out secondNum))
                {
                    MessageBox.Show("请输入第二个数字！");
                    break;
                }

                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择操作符！");
                    break;
                }
                op = comboBox1.Text;

                try
                {
                    answer = Calculator.MyCalculator(firstNum, secondNum, op);
                    if (double.IsNaN(answer) || double.IsInfinity(answer))
                    {
                        MessageBox.Show("计算遇到问题，检查是否存在例如除数为零的问题。");
                        break;
                    }
                    else
                    {
                        label1.Text = answer.ToString();
                        break;
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("存在问题:" + e1.Message);
                    break;
                }
            }
            
        }
    }
}
