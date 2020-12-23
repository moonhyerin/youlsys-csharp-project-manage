using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Project_Manage
{
    public partial class AddTempPcode : MetroForm
    {
        Form1 form;

        public AddTempPcode()
        {
            InitializeComponent();
        }
        public AddTempPcode(Form1 form1)
        {
            InitializeComponent(); 
            form = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            /*Console.WriteLine(company.Text);
            Console.WriteLine(pName.Text);

            if(company.Text != "" && pName.Text != "")
            {
                form.textBox1.Text = company.Text;
                form.textBox2.Text = pName.Text;
                form.flag.Text = "true";
            }
            this.Close();*/

            sendValueToForm1();
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                sendValueToForm1();
            }

        }

        private void sendValueToForm1()
        {
            Console.WriteLine(company.Text);
            Console.WriteLine(pName.Text);

            if (company.Text != "" && pName.Text != "")
            {
                form.textBox1.Text = company.Text;
                form.textBox2.Text = pName.Text;
                form.flag.Text = "true";
            }

            this.Close();
        }
    }
}
