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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            { 
                int n = int.Parse(textBox1.Text); 
                GraphData.GraphInit(n);
                GraphData.SendReRenderingMessage();
                Close();
            } 
            catch 
            {
                MessageBox.Show("Неправильный формат входных данных", "Input data error");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
