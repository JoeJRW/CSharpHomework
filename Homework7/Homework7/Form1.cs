using System;
using System.Drawing;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1;
        double th2;
        double per1;
        double per2;
        Color color = Color.Black;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (graphics == null)
                graphics = this.panel1.CreateGraphics();
            else
                graphics.Clear(panel1.BackColor);

            try
            {
                th1 = double.Parse(textBox2.Text) * Math.PI / 180;
                th2 = double.Parse(textBox1.Text) * Math.PI / 180;
                per1 = double.Parse(textBox4.Text);
                per2 = double.Parse(textBox3.Text);
                int n = int.Parse(comboBox1.Text);
                DrawCayleyTree(n, (panel1.Right - panel1.Left) / 2,
                    (panel1.Bottom - 20), hScrollBar1.Value, -Math.PI / 2);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            DrawLine(x0, y0, x1, y1);

            DrawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            DrawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void DrawLine(double x0, double y0, double x1, double y1)
        {
            Pen p = new Pen(color);
            graphics.DrawLine(p, (int)x0, (int)y0, (int)x1, (int)y1);      
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDia = new ColorDialog();
            if (colorDia.ShowDialog() == DialogResult.OK)
            {
                color = colorDia.Color;
            }
        }

        private void HScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "主干长度：" + hScrollBar1.Value;
        }
    }
}
