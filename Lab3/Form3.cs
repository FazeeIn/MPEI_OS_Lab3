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

namespace Lab3
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ThreadFindPath();
                Close();
            }
            catch
            {
                MessageBox.Show("Неверно введены данные ", "Error");
            }
        }

        private void ThreadFindPath()
        {     
                GraphData.startV = int.Parse(textBox1.Text);
                GraphData.endV = int.Parse(textBox2.Text);
                Thread secondThread = new Thread((GraphData.FindPaths));
                secondThread.Name = "SecondThread";
                secondThread.Start();       
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
