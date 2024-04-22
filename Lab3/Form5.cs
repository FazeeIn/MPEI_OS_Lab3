using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int first = int.Parse(textBox1.Text);
                int second = int.Parse(textBox2.Text);
                GraphData.graph[first, second] = 1;
                GraphData.graph[second, first] = 1;
                GraphData.SendReRenderingMessage();
                Close();
            }
            catch 
            {
                MessageBox.Show("Неправильный формат входных данных", "Input data error");
            }
        }
    }
}
