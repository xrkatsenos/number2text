using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

    number2textlib.num2text ConvClass = new number2textlib.num2text();


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textTextBox.Text = ConvClass.convert2text(numberTextBox.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
