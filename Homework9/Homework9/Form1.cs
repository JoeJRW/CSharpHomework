using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleCrawler;

namespace Homework9
{
    public partial class Form1 : Form
    {
        Crawler crawler = new Crawler();
        public Form1()
        {
            InitializeComponent();
            crawler.PageDownloaded += Crawler_PageDownloaded;
        }

        private void Crawler_PageDownloaded(string obj)
        {
            if (this.listBox1.InvokeRequired)
            {
                Action<string> action = this.AddUrl;
                this.Invoke(action, new object[] { obj });
            }
            else
                listBox1.Items.Add("爬行" + obj + "页面！");
        }

        private void AddUrl(string url)
        {
            listBox1.Items.Add("爬行" + url + "页面！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crawler.StartURL = textBox1.Text;
            listBox1.Items.Clear();
            listBox1.Items.Add("开始爬行");
            new Thread(crawler.Crawl).Start();
        }
    }
}
