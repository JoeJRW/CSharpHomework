using Homework5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework8
{
    public partial class Form2 : Form
    {
        public string CusName { get; set; }
        public string ItemName { get; set; }
        public int ItemNum { get; set; }
        public double ItemPrice { get; set; }

        private List<OrderItem> orderItem = new List<OrderItem>();
        private int ItemSum;

        OrderService myservice2;

        public Form2(OrderService service)
        {
            InitializeComponent();

            this.myservice2 = service;

            ItemSum = 1;
            textBox1.DataBindings.Add("Text", this, "CusName");
            textBox2.DataBindings.Add("Text", this, "ItemName");
            textBox3.DataBindings.Add("Text", this, "ItemNum");
            textBox4.DataBindings.Add("Text", this, "ItemPrice"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            orderItem.Add(new OrderItem(ItemSum, ItemName, ItemNum, ItemPrice));
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            ItemSum += 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myservice2.AddOrder(new Order(myservice2.Orders.Count + 1,
                CusName, orderItem));
            Close();
        }
    }
}
