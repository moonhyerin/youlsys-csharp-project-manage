
namespace Project_Manage
{
    partial class DeleteTempPcode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pcodeList = new System.Windows.Forms.CheckedListBox();
            this.delBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // pcodeList
            // 
            this.pcodeList.FormattingEnabled = true;
            this.pcodeList.Location = new System.Drawing.Point(23, 63);
            this.pcodeList.Name = "pcodeList";
            this.pcodeList.Size = new System.Drawing.Size(362, 148);
            this.pcodeList.TabIndex = 0;
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(155, 220);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(104, 34);
            this.delBtn.TabIndex = 1;
            this.delBtn.Text = "삭제";
            this.delBtn.Click += new System.EventHandler(this.delBtn_Clicked);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 32);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(202, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "임시 프로젝트코드 삭제";
            // 
            // DeleteTempPcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 290);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.delBtn);
            this.Controls.Add(this.pcodeList);
            this.Name = "DeleteTempPcode";
            this.Load += new System.EventHandler(this.DeleteTempPcode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox pcodeList;
        private MetroFramework.Controls.MetroButton delBtn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}