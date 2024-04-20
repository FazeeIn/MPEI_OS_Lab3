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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                GetInputData();
                Close();
            }
            catch
            {
                MessageBox.Show("Неправильный формат входных данных","Input data error");
            }
        }

        private void GetInputData()
        {
            GraphData.v1 = int.Parse(textBox1.Text);
            GraphData.v2 = int.Parse(textBox2.Text);
            GraphData.e11 = int.Parse(textBox3.Text);
            GraphData.e12 = int.Parse(textBox4.Text);
            GraphData.e21 = int.Parse(textBox5.Text);
            GraphData.e22 = int.Parse(textBox6.Text);
        }
    }
}
