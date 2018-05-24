using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects.PL
{
    public partial class AddForm : Form
    {
        public string ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }
        public string ReturnValue3 { get; set; }
        public string ReturnValue4 { get; set; }
        public string ReturnValue5 { get; set; }
        public string ReturnValue6 { get; set; }

        public AddForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="" && textBox3.Text != "" && textBox4.Text != "")
            {
                this.ReturnValue1 = textBox1.Text;
                this.ReturnValue2 = textBox2.Text;
                this.ReturnValue3 = textBox4.Text;
                this.ReturnValue4 = textBox3.Text;
                this.ReturnValue5 = dateTimePicker1.Text;
                this.ReturnValue6 = dateTimePicker2.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
