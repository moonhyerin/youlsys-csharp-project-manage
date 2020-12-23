
namespace Project_Manage
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectMonth = new MetroFramework.Controls.MetroComboBox();
            this.title = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.departTbox = new MetroFramework.Controls.MetroTextBox();
            this.writerTbox = new MetroFramework.Controls.MetroTextBox();
            this.teamTbox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.jobTbox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.searchBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.searchTextbox = new MetroFramework.Controls.MetroTextBox();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.pCodeGridView = new System.Windows.Forms.DataGridView();
            this.reset = new MetroFramework.Controls.MetroButton();
            this.inputPcodeBtn1 = new MetroFramework.Controls.MetroButton();
            this.inputPcodeBtn2 = new MetroFramework.Controls.MetroButton();
            this.inputPcodeBtn3 = new MetroFramework.Controls.MetroButton();
            this.inputPcodeBtn4 = new MetroFramework.Controls.MetroButton();
            this.totalTime = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.time1 = new System.Windows.Forms.TextBox();
            this.time2 = new System.Windows.Forms.TextBox();
            this.time3 = new System.Windows.Forms.TextBox();
            this.time4 = new System.Windows.Forms.TextBox();
            this.notice = new MetroFramework.Controls.MetroTextBox();
            this.allDay = new System.Windows.Forms.CheckBox();
            this.halfDay = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pcodeTbox1 = new System.Windows.Forms.TextBox();
            this.pcodeTbox2 = new System.Windows.Forms.TextBox();
            this.pcodeTbox3 = new System.Windows.Forms.TextBox();
            this.pcodeTbox4 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.etcTbox = new System.Windows.Forms.TextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.addPcodeBtn = new MetroFramework.Controls.MetroButton();
            this.delPcodeBtn = new MetroFramework.Controls.MetroButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flag = new System.Windows.Forms.TextBox();
            this.exportBtn = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCodeGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectMonth
            // 
            this.selectMonth.FormattingEnabled = true;
            this.selectMonth.ItemHeight = 23;
            this.selectMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.selectMonth.Location = new System.Drawing.Point(52, 35);
            this.selectMonth.Name = "selectMonth";
            this.selectMonth.Size = new System.Drawing.Size(72, 29);
            this.selectMonth.TabIndex = 0;
            this.selectMonth.SelectedValueChanged += new System.EventHandler(this.SelectMonth);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.title.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.title.Location = new System.Drawing.Point(130, 39);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(298, 25);
            this.title.TabIndex = 1;
            this.title.Text = "월 프로젝트 인력 투입 현황(개인별)";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(52, 99);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 19);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "부서명";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(52, 136);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(51, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "작성자";
            // 
            // departTbox
            // 
            this.departTbox.Location = new System.Drawing.Point(109, 97);
            this.departTbox.Name = "departTbox";
            this.departTbox.Size = new System.Drawing.Size(84, 25);
            this.departTbox.TabIndex = 4;
            // 
            // writerTbox
            // 
            this.writerTbox.Location = new System.Drawing.Point(109, 133);
            this.writerTbox.Name = "writerTbox";
            this.writerTbox.Size = new System.Drawing.Size(84, 25);
            this.writerTbox.TabIndex = 5;
            // 
            // teamTbox
            // 
            this.teamTbox.Location = new System.Drawing.Point(375, 97);
            this.teamTbox.Name = "teamTbox";
            this.teamTbox.Size = new System.Drawing.Size(84, 25);
            this.teamTbox.TabIndex = 7;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(332, 101);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(37, 19);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "팀명";
            // 
            // jobTbox
            // 
            this.jobTbox.Location = new System.Drawing.Point(375, 133);
            this.jobTbox.Name = "jobTbox";
            this.jobTbox.Size = new System.Drawing.Size(84, 25);
            this.jobTbox.TabIndex = 9;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(332, 137);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(37, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "직위";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(194, 101);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(51, 19);
            this.metroLabel5.TabIndex = 10;
            this.metroLabel5.Text = "사업부";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(461, 101);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(23, 19);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "팀";
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(396, 196);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(36, 23);
            this.searchBtn.TabIndex = 12;
            this.searchBtn.Text = "검색";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(53, 200);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(97, 19);
            this.metroLabel7.TabIndex = 14;
            this.metroLabel7.Text = "프로젝트 코드";
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            this.gridView.AllowUserToResizeColumns = false;
            this.gridView.AllowUserToResizeRows = false;
            this.gridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridView.Location = new System.Drawing.Point(0, 0);
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.RowHeadersVisible = false;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.Size = new System.Drawing.Size(586, 527);
            this.gridView.TabIndex = 15;
            this.gridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellClick);
            this.gridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.gridView_ColumnAdded);
            this.gridView.SelectionChanged += new System.EventHandler(this.gridView_SelectionChanged);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(156, 196);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 20;
            this.metroButton2.Text = "file import";
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // searchTextbox
            // 
            this.searchTextbox.Location = new System.Drawing.Point(284, 196);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(106, 23);
            this.searchTextbox.TabIndex = 26;
            this.searchTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.startSearch);
            // 
            // metroButton3
            // 
            this.metroButton3.Location = new System.Drawing.Point(568, 603);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(73, 26);
            this.metroButton3.TabIndex = 27;
            this.metroButton3.Text = "입력";
            this.metroButton3.Click += new System.EventHandler(this.metroButton3_Click);
            // 
            // pCodeGridView
            // 
            this.pCodeGridView.AllowUserToAddRows = false;
            this.pCodeGridView.AllowUserToDeleteRows = false;
            this.pCodeGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pCodeGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.pCodeGridView.Location = new System.Drawing.Point(53, 223);
            this.pCodeGridView.MultiSelect = false;
            this.pCodeGridView.Name = "pCodeGridView";
            this.pCodeGridView.ReadOnly = true;
            this.pCodeGridView.RowHeadersVisible = false;
            this.pCodeGridView.RowTemplate.Height = 23;
            this.pCodeGridView.Size = new System.Drawing.Size(432, 527);
            this.pCodeGridView.TabIndex = 28;
            this.pCodeGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.pCodeGridView_CellDoubleClick);
            this.pCodeGridView.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.pCodeGridView_ColumnAdded);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(438, 196);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(47, 23);
            this.reset.TabIndex = 33;
            this.reset.Text = "초기화";
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // inputPcodeBtn1
            // 
            this.inputPcodeBtn1.Location = new System.Drawing.Point(4, 23);
            this.inputPcodeBtn1.Name = "inputPcodeBtn1";
            this.inputPcodeBtn1.Size = new System.Drawing.Size(61, 23);
            this.inputPcodeBtn1.TabIndex = 34;
            this.inputPcodeBtn1.Text = "주";
            this.inputPcodeBtn1.Click += new System.EventHandler(this.inputPcodeBtn_Click);
            // 
            // inputPcodeBtn2
            // 
            this.inputPcodeBtn2.Location = new System.Drawing.Point(4, 55);
            this.inputPcodeBtn2.Name = "inputPcodeBtn2";
            this.inputPcodeBtn2.Size = new System.Drawing.Size(61, 23);
            this.inputPcodeBtn2.TabIndex = 35;
            this.inputPcodeBtn2.Text = "보조";
            this.inputPcodeBtn2.Click += new System.EventHandler(this.inputPcodeBtn_Click);
            // 
            // inputPcodeBtn3
            // 
            this.inputPcodeBtn3.Location = new System.Drawing.Point(4, 87);
            this.inputPcodeBtn3.Name = "inputPcodeBtn3";
            this.inputPcodeBtn3.Size = new System.Drawing.Size(61, 23);
            this.inputPcodeBtn3.TabIndex = 36;
            this.inputPcodeBtn3.Text = "보조(PS)";
            this.inputPcodeBtn3.Click += new System.EventHandler(this.inputPcodeBtn_Click);
            // 
            // inputPcodeBtn4
            // 
            this.inputPcodeBtn4.Location = new System.Drawing.Point(4, 119);
            this.inputPcodeBtn4.Name = "inputPcodeBtn4";
            this.inputPcodeBtn4.Size = new System.Drawing.Size(61, 23);
            this.inputPcodeBtn4.TabIndex = 37;
            this.inputPcodeBtn4.Text = "출장/외근";
            this.inputPcodeBtn4.Click += new System.EventHandler(this.inputPcodeBtn_Click);
            // 
            // totalTime
            // 
            this.totalTime.AutoSize = true;
            this.totalTime.Location = new System.Drawing.Point(584, 581);
            this.totalTime.Name = "totalTime";
            this.totalTime.Size = new System.Drawing.Size(23, 19);
            this.totalTime.TabIndex = 38;
            this.totalTime.Text = "00";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(563, 581);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(23, 19);
            this.metroLabel8.TabIndex = 39;
            this.metroLabel8.Text = "총";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(605, 581);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(37, 19);
            this.metroLabel9.TabIndex = 40;
            this.metroLabel9.Text = "시간";
            // 
            // time1
            // 
            this.time1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.time1.Location = new System.Drawing.Point(111, 23);
            this.time1.Name = "time1";
            this.time1.Size = new System.Drawing.Size(40, 23);
            this.time1.TabIndex = 41;
            this.time1.TextChanged += new System.EventHandler(this.timeTboxTextChanged);
            this.time1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            // 
            // time2
            // 
            this.time2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.time2.Location = new System.Drawing.Point(111, 55);
            this.time2.Name = "time2";
            this.time2.Size = new System.Drawing.Size(40, 23);
            this.time2.TabIndex = 42;
            this.time2.TextChanged += new System.EventHandler(this.timeTboxTextChanged);
            this.time2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            // 
            // time3
            // 
            this.time3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.time3.Location = new System.Drawing.Point(111, 87);
            this.time3.Name = "time3";
            this.time3.Size = new System.Drawing.Size(40, 23);
            this.time3.TabIndex = 43;
            this.time3.TextChanged += new System.EventHandler(this.timeTboxTextChanged);
            this.time3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            // 
            // time4
            // 
            this.time4.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.time4.Location = new System.Drawing.Point(111, 119);
            this.time4.Name = "time4";
            this.time4.Size = new System.Drawing.Size(40, 23);
            this.time4.TabIndex = 44;
            this.time4.TextChanged += new System.EventHandler(this.timeTboxTextChanged);
            this.time4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPress);
            // 
            // notice
            // 
            this.notice.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.notice.Location = new System.Drawing.Point(652, 76);
            this.notice.Multiline = true;
            this.notice.Name = "notice";
            this.notice.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.notice.Size = new System.Drawing.Size(586, 141);
            this.notice.TabIndex = 45;
            // 
            // allDay
            // 
            this.allDay.AutoSize = true;
            this.allDay.Location = new System.Drawing.Point(24, 16);
            this.allDay.Name = "allDay";
            this.allDay.Size = new System.Drawing.Size(48, 16);
            this.allDay.TabIndex = 0;
            this.allDay.Text = "연차";
            this.allDay.UseVisualStyleBackColor = true;
            this.allDay.CheckedChanged += new System.EventHandler(this.chk_Click);
            // 
            // halfDay
            // 
            this.halfDay.AutoSize = true;
            this.halfDay.Location = new System.Drawing.Point(87, 16);
            this.halfDay.Name = "halfDay";
            this.halfDay.Size = new System.Drawing.Size(48, 16);
            this.halfDay.TabIndex = 1;
            this.halfDay.Text = "반차";
            this.halfDay.UseVisualStyleBackColor = true;
            this.halfDay.CheckedChanged += new System.EventHandler(this.chk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.halfDay);
            this.groupBox1.Controls.Add(this.allDay);
            this.groupBox1.Location = new System.Drawing.Point(492, 539);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(154, 39);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "휴무";
            // 
            // pcodeTbox1
            // 
            this.pcodeTbox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pcodeTbox1.Location = new System.Drawing.Point(72, 23);
            this.pcodeTbox1.Name = "pcodeTbox1";
            this.pcodeTbox1.Size = new System.Drawing.Size(40, 23);
            this.pcodeTbox1.TabIndex = 45;
            // 
            // pcodeTbox2
            // 
            this.pcodeTbox2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.pcodeTbox2.Location = new System.Drawing.Point(72, 55);
            this.pcodeTbox2.Name = "pcodeTbox2";
            this.pcodeTbox2.Size = new System.Drawing.Size(40, 23);
            this.pcodeTbox2.TabIndex = 49;
            // 
            // pcodeTbox3
            // 
            this.pcodeTbox3.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.pcodeTbox3.Location = new System.Drawing.Point(72, 87);
            this.pcodeTbox3.Name = "pcodeTbox3";
            this.pcodeTbox3.Size = new System.Drawing.Size(40, 23);
            this.pcodeTbox3.TabIndex = 50;
            // 
            // pcodeTbox4
            // 
            this.pcodeTbox4.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.pcodeTbox4.Location = new System.Drawing.Point(72, 119);
            this.pcodeTbox4.Name = "pcodeTbox4";
            this.pcodeTbox4.Size = new System.Drawing.Size(40, 23);
            this.pcodeTbox4.TabIndex = 51;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.metroButton1);
            this.groupBox2.Controls.Add(this.etcTbox);
            this.groupBox2.Controls.Add(this.pcodeTbox1);
            this.groupBox2.Controls.Add(this.time3);
            this.groupBox2.Controls.Add(this.time4);
            this.groupBox2.Controls.Add(this.time1);
            this.groupBox2.Controls.Add(this.pcodeTbox4);
            this.groupBox2.Controls.Add(this.pcodeTbox3);
            this.groupBox2.Controls.Add(this.inputPcodeBtn4);
            this.groupBox2.Controls.Add(this.inputPcodeBtn3);
            this.groupBox2.Controls.Add(this.pcodeTbox2);
            this.groupBox2.Controls.Add(this.inputPcodeBtn2);
            this.groupBox2.Controls.Add(this.time2);
            this.groupBox2.Controls.Add(this.inputPcodeBtn1);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(491, 353);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 180);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "업무";
            // 
            // etcTbox
            // 
            this.etcTbox.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.etcTbox.Location = new System.Drawing.Point(72, 150);
            this.etcTbox.Name = "etcTbox";
            this.etcTbox.Size = new System.Drawing.Size(78, 23);
            this.etcTbox.TabIndex = 53;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(4, 150);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(61, 23);
            this.metroButton1.TabIndex = 52;
            this.metroButton1.Text = "기타";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridView);
            this.panel1.Location = new System.Drawing.Point(652, 223);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 527);
            this.panel1.TabIndex = 50;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(491, 223);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(65, 21);
            this.textBox1.TabIndex = 51;
            this.textBox1.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(491, 250);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(65, 21);
            this.textBox2.TabIndex = 52;
            this.textBox2.Visible = false;
            // 
            // addPcodeBtn
            // 
            this.addPcodeBtn.Location = new System.Drawing.Point(30, 18);
            this.addPcodeBtn.Name = "addPcodeBtn";
            this.addPcodeBtn.Size = new System.Drawing.Size(40, 23);
            this.addPcodeBtn.TabIndex = 53;
            this.addPcodeBtn.Text = "추가";
            this.addPcodeBtn.Click += new System.EventHandler(this.TempPcodeClicked);
            // 
            // delPcodeBtn
            // 
            this.delPcodeBtn.Location = new System.Drawing.Point(85, 18);
            this.delPcodeBtn.Name = "delPcodeBtn";
            this.delPcodeBtn.Size = new System.Drawing.Size(40, 23);
            this.delPcodeBtn.TabIndex = 54;
            this.delPcodeBtn.Text = "삭제";
            this.delPcodeBtn.Click += new System.EventHandler(this.TempPcodeClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.addPcodeBtn);
            this.groupBox3.Controls.Add(this.delPcodeBtn);
            this.groupBox3.Location = new System.Drawing.Point(491, 701);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 49);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "임시 프로젝트 코드";
            // 
            // flag
            // 
            this.flag.Location = new System.Drawing.Point(492, 277);
            this.flag.Name = "flag";
            this.flag.Size = new System.Drawing.Size(65, 21);
            this.flag.TabIndex = 56;
            this.flag.Visible = false;
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(1246, 701);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(92, 49);
            this.exportBtn.TabIndex = 57;
            this.exportBtn.Text = "Save File";
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 790);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.flag);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.notice);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.totalTime);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.pCodeGridView);
            this.Controls.Add(this.metroButton3);
            this.Controls.Add(this.searchTextbox);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.jobTbox);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.teamTbox);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.writerTbox);
            this.Controls.Add(this.departTbox);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.title);
            this.Controls.Add(this.selectMonth);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCodeGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox selectMonth;
        private MetroFramework.Controls.MetroLabel title;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox departTbox;
        private MetroFramework.Controls.MetroTextBox writerTbox;
        private MetroFramework.Controls.MetroTextBox teamTbox;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox jobTbox;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton searchBtn;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.DataGridView gridView;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroTextBox searchTextbox;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroButton reset;
        private MetroFramework.Controls.MetroButton inputPcodeBtn1;
        private MetroFramework.Controls.MetroButton inputPcodeBtn2;
        private MetroFramework.Controls.MetroButton inputPcodeBtn3;
        private MetroFramework.Controls.MetroButton inputPcodeBtn4;
        private MetroFramework.Controls.MetroLabel totalTime;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private System.Windows.Forms.TextBox time1;
        private System.Windows.Forms.TextBox time2;
        private System.Windows.Forms.TextBox time3;
        private System.Windows.Forms.TextBox time4;
        private MetroFramework.Controls.MetroTextBox notice;
        private System.Windows.Forms.CheckBox allDay;
        private System.Windows.Forms.CheckBox halfDay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox pcodeTbox1;
        private System.Windows.Forms.TextBox pcodeTbox2;
        private System.Windows.Forms.TextBox pcodeTbox3;
        private System.Windows.Forms.TextBox pcodeTbox4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView pCodeGridView;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        private MetroFramework.Controls.MetroButton addPcodeBtn;
        private MetroFramework.Controls.MetroButton delPcodeBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox etcTbox;
        private MetroFramework.Controls.MetroButton metroButton1;
        public System.Windows.Forms.TextBox flag;
        private MetroFramework.Controls.MetroButton exportBtn;
    }
}

