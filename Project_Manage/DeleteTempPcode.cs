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
    public partial class DeleteTempPcode : MetroForm
    {
        Form1 form;

        public DataTable tempPcodeTable { get; set; }

        public DeleteTempPcode()
        {
            InitializeComponent();
        }

        public DeleteTempPcode(Form1 form1)
        {
            InitializeComponent(); 
            form = form1;
        }

        private void DeleteTempPcode_Load(object sender, EventArgs e)
        {
            //테이블에 tempPcodeTable을 표시
            for(int i=0; i<tempPcodeTable.Rows.Count; i++)
            {
                pcodeList.Items.Add(tempPcodeTable.Rows[i]["코드"].ToString() + " / " + tempPcodeTable.Rows[i]["발주사"].ToString() + " / " + tempPcodeTable.Rows[i]["프로젝트"].ToString());
            }

        }

        private void delBtn_Clicked(object sender, EventArgs e)
        {
            //체크된 아이템 확인
            string[] deletedCode = new string[pcodeList.CheckedItems.Count];
            for(int j=0; j< pcodeList.CheckedItems.Count; j++)
            {
                string[] item = pcodeList.CheckedItems[j].ToString().Split('/');
                string pcode = item[0].Trim();

                deletedCode[j] = pcode;
            }

            string array = "";
            for(int i=0; i<deletedCode.Length; i++)
            {
                if(i != 0 || i == deletedCode.Length - 1)
                {
                    array += "," + deletedCode[i].ToString();
                }
                else
                {
                    array += deletedCode[i].ToString();
                }
            }

            form.textBox1.Text = array;
            form.flag.Text = "true";
            this.Close();

        }

    }
}
