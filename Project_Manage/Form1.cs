using MetroFramework.Forms;
using MetroFramework.Controls;
using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace Project_Manage
{
    public partial class Form1 : MetroForm
    {
        DataTable excelTable = new DataTable();
        DataTable pCodeTable = null;
        DataTable tempPcodeTable = new DataTable();

        List<string> procList;
        SortedSet<int> redDays = null;
        private string getHolidayUrl = "http://apis.data.go.kr/B090041/openapi/service/SpcdeInfoService/getHoliDeInfo";

        Thread th;
        ProgressBar pb;

        List<TextBox> tboxList;

        public Form1()
        {
            InitializeComponent();
            InitializeNotice();
            InitializeDataTable();
            lnitializeTooltip();

            // PROCESS EXCEL 받아오기
            Process[] proc = Process.GetProcessesByName("EXCEL");
            procList = new List<string>();

            foreach (var excel in proc)
            {
               procList.Add(excel.Id.ToString());
            }

            CheckForIllegalCrossThreadCalls = false;
        }

        #region DataTable, Notice, GridView 초기화
        private void lnitializeTooltip()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.AutoPopDelay = 5000;    //포인터가 고정되었을 때 도구 설명이 표시되는 시간
            toolTip.InitialDelay = 500;     //tooltip이 나타날 때까지 걸리는 시간
            toolTip.ReshowDelay = 500;      //다음 도구 설명 창이 나타날 때까지 걸리는 시간
            toolTip.ShowAlways = true;
            toolTip.IsBalloon = true;

            toolTip.SetToolTip(etcTbox, "병가, 특별휴가, 하계휴가 또는 기타사항 작성");
        }

        private void InitializeDataTable()
        {
            excelTable.Columns.Add("일자");
            excelTable.Columns.Add("주 프로젝트");
            excelTable.Columns.Add(" ");
            excelTable.Columns.Add("보조 프로젝트");
            excelTable.Columns.Add("  ");
            excelTable.Columns.Add("보조(PS) 프로젝트");
            excelTable.Columns.Add("   ");
            excelTable.Columns.Add("출장/외근시간");
            excelTable.Columns.Add("기타(출장Code번호명기)");

            //임시 프로젝트 코드 저장용 테이블
            tempPcodeTable.Columns.Add("코드");
            tempPcodeTable.Columns.Add("발주사");
            tempPcodeTable.Columns.Add("프로젝트");
            tempPcodeTable.Columns.Add("용역기간");
        }

        private void InitializeNotice()
        {
            string txt = "*작성요령  (작성대상 : 팀장이하까지)\r\n" +
                "1.부서명과 팀명, 작성자를 작성하고,\r\n   휴무일은 공란, 그 외의 일자에 PJ코드와 시간을 작성한다.\r\n" +
                "2. 주 프로젝트는 본 업무를 하고 있는 프로젝트를 말하며\r\n   별도의 프로젝트 코드파일에서 검색을 하여 코드를 작성한다.\r\n" +
                "3. 보조 프로젝트는 본 업무외에 타 업무를 겸업할 시를 말하며\r\n   별도의 프로젝트 코드 파일에서 검색하여 코드를 작성한다.\r\n" +
                "4. 'PS' 프로젝트는 영업 수주를 위해 지원하는 업무를 말하며\r\n   별도의 프로젝트 코드 파일에서 검색하여 코드를 작성한다. (추가요청사항)\r\n" +
                "5. 3개이상 PJ를 겸업할 경우 주, 보조를 작성한 후\r\n   추가분은 기타에 PJ코드와 시간을 작성한다. (예: P35 / 2)\r\n" +
                "6. 주 프로젝트, 보조프로젝트와 PS프로젝트의 합이 8시간을 초과할 수 없다.";

            notice.Text = txt;
        }

        //Form이 로드되면 combobox에서 임의적으로 이번달을 선택
        private void Form1_Load(object sender, EventArgs e)
        {
            int lastMonth = DateTime.Now.Month; //현재 년도 1 - 12까지임
            if (lastMonth != 1)
            {
                selectMonth.SelectedIndex = lastMonth - 2;
            }
            else
            {
                //1월에는 12월을 선택해야 함
                selectMonth.SelectedIndex = 11;
            }

            addPcodeBtn.Enabled = false;
            delPcodeBtn.Enabled = false;

            Call_API(getHolidayUrl);
        }

        private void SelectMonth(object sender, EventArgs e)
        {
            excelTable.Clear();

            excelTable.Rows.Add("", "PJ 코드", "업무시간", "PJ 코드", "업무시간", "PJ 코드", "업무시간", "", "");
            string month = selectMonth.SelectedItem.ToString();
            int lastday = DateTime.DaysInMonth(DateTime.Now.Year, Int32.Parse(month));

            for (int i = 0; i < lastday; i++)
            {
                excelTable.Rows.Add((i + 1).ToString());
            }
            gridView.DataSource = excelTable;

            ChangeColorOfWeekends(DateTime.Now.Year, Int32.Parse(month), lastday);
        }

        private void ChangeColorOfWeekends(int year, int month, int days)
        {
            redDays = new SortedSet<int>();
            for (int i = 1; i <= days; i++)
            {
                DateTime date = new DateTime(year, month, i);

                if (date.ToString("ddd") == "토" || date.ToString("ddd") == "일")
                {
                    redDays.Add(i);
                    gridView.Rows[i].Cells["일자"].Style.ForeColor = Color.Red;
                    gridView.Rows[i].ReadOnly = true;
                }
            }

            Call_API(getHolidayUrl);
        }

        //상단 Row 클릭시 클릭 해제 ==> 클릭 해제만 하면 value값은 그대로 들어감,,tqtq
        private void gridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            if(e.RowIndex == 0 || gridView.Rows[e.RowIndex].Cells["일자"].Style.ForeColor == Color.Red)
            {
                gridView.Rows[e.RowIndex].Selected = false;
            }
        }
        #endregion

        #region 공휴일 API 불러오기
        private void Call_API(string url)
        {
            //Request Parameter
            //1. 몇년 몇월인지 받기
            string year = DateTime.Now.Year.ToString();
            string month = (selectMonth.SelectedItem.ToString().Length != 2) ? string.Format("0{0}", selectMonth.SelectedItem.ToString()) : selectMonth.SelectedItem.ToString();
            string serviceKey = "6qnVW3HHL3W7zDsunzb86Fst%2B1M9Onmgyy53frboQehEq2s%2FrJq8pOCv9WSdNXWG8DFTf0j72bQBwAQqO5JQqA%3D%3D";

            string requestUrl = url + string.Format("?solYear={0}&solMonth={1}&ServiceKey={2}&_type=json", year, month, serviceKey);

            try
            {
                WebClient client = new WebClient();

                using (Stream data = client.OpenRead(requestUrl))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string s = reader.ReadToEnd();

                        dynamic stuff = JsonConvert.DeserializeObject(s);
                        dynamic items = stuff.response.body.items;
                        if (Convert.ToString(items) == "")
                        {
                            return;
                        }

                        if (items["item"].Count == null)
                        {
                            Console.WriteLine("이번달의 휴일 날짜는? : " + items.item.locdate);
                            string locdate = items.item.locdate;
                            string holDate = locdate.Substring(6, 2);

                            for (int j = 1; j <= gridView.Rows.Count - 1; j++)
                            {
                                string tempDate = (gridView.Rows[j].Cells["일자"].Value.ToString().Length != 2) ?
                                    string.Format("0{0}", gridView.Rows[j].Cells["일자"].Value.ToString()) : gridView.Rows[j].Cells["일자"].Value.ToString();
                                if (tempDate == holDate)
                                {
                                    redDays.Add(int.Parse(holDate));
                                    gridView.Rows[j].Cells["일자"].Style.ForeColor = Color.Red;
                                    gridView.Rows[j].ReadOnly = true;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < items["item"].Count; i++)
                            {
                                Console.WriteLine("이번달의 휴일 날짜는? : " + items["item"][i].locdate);
                                string locdate = items["item"][i].locdate;
                                string holDate = locdate.Substring(6, 2);

                                for (int j = 1; j <= gridView.Rows.Count - 1; j++)
                                {
                                    string tempDate = (gridView.Rows[j].Cells["일자"].Value.ToString().Length != 2) ?
                                        string.Format("0{0}", gridView.Rows[j].Cells["일자"].Value.ToString()) : gridView.Rows[j].Cells["일자"].Value.ToString();
                                    if (tempDate == holDate)
                                    {
                                        redDays.Add(int.Parse(holDate));
                                        gridView.Rows[j].Cells["일자"].Style.ForeColor = Color.Red;
                                        gridView.Rows[j].ReadOnly = true;
                                    }
                                }
                            }
                        }

                        reader.Close();
                        data.Close();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        #endregion

        #region 프로젝트코드 파일 import
        private void metroButton2_Click(object sender, EventArgs e)
        {
            //파일 Import
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls; *.xlsx; *.xlsm";
            OleDbConnection con = null;
            DataTable dt = null;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!ofd.FileName.EndsWith("xlsx") && !ofd.FileName.EndsWith("xls"))
                        return;

                    
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    con = new OleDbConnection(constr);
                    con.Open();

                    dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        throw new Exception("DataTable is null.");
                    }

                    // Sheet count 갯수
                    string[] excelSheets = new string[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[i] = row["TABLE_NAME"].ToString();
                    }

                    OleDbCommand ocmd = new OleDbCommand("Select [코드], [발주사], [프로젝트], [용역기간] From [" + excelSheets[0] + "]", con);
                    OleDbDataAdapter sda = new OleDbDataAdapter(ocmd);
                    pCodeTable = new DataTable();
                    sda.Fill(pCodeTable);

                    pCodeGridView.DataSource = pCodeTable;
                    pCodeGridView.AutoResizeColumns();

                    //임시 프로젝트 코드 관련 버튼 활성화
                    addPcodeBtn.Enabled = true;
                    delPcodeBtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    MessageBox.Show("프로젝트 코드 파일을 선택해주세요.");
                }
            }
        }
        #endregion

        #region 입력 버튼 클릭
        private void metroButton3_Click(object sender, EventArgs e)
        {
            if(pCodeTable == null)
            {
                return;
            }

            //날짜 셀이 선택되어 있는지 체크
            if (gridView.SelectedRows.Count == 0 && gridView.SelectedCells.Count == 0)
            {
                MessageBox.Show("날짜를 선택해주세요");
                return;
            }
            else
            {
                //날짜 셀이 선택되어 있다면 셀에 이미 데이터가 있는지 체크
                if (gridView.SelectedRows.Count != 0)
                {
                    bool isOverwrite = false;
                    foreach (DataGridViewRow r in gridView.SelectedRows)
                    {
                        for(int i=1; i<r.Cells.Count; i++)
                        {
                            if (r.Cells[i].Value.ToString() != "")
                            {
                                DialogResult result = MessageBox.Show("기존 데이터를 덮어쓰시겠습니까?", "", MessageBoxButtons.YesNo);

                                if (result == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    isOverwrite = true;
                                    break;
                                }
                            }
                        }
                        
                        if(isOverwrite == true)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    bool isOverwrite = false;
                    foreach (DataGridViewCell c in gridView.SelectedCells)
                    {
                        for (int i = 1; i < gridView.Rows[c.RowIndex].Cells.Count; i++)
                        {
                            if (gridView.Rows[c.RowIndex].Cells[i].Value.ToString() != "")
                            {
                                DialogResult result = MessageBox.Show("기존 데이터를 덮어쓰시겠습니까?", "", MessageBoxButtons.YesNo);

                                if (result == DialogResult.No)
                                {
                                    return;
                                }
                                else
                                {
                                    isOverwrite = true;
                                    break;
                                }
                            }
                        }

                        if (isOverwrite == true)
                        {
                            break;
                        }
                    }
                }
            }

            //연차 여부 확인
            if (pcodeTbox1.Enabled == false)
            {
                if (gridView.SelectedRows.Count != 0)
                {
                    foreach (DataGridViewRow r in gridView.SelectedRows)
                    {
                        for(int i=1; i<r.Cells.Count; i++)
                        {
                            r.Cells[i].Value = "";
                        }
                        r.Cells["기타(출장Code번호명기)"].Value = "연차";
                    }
                }
                else
                {
                    foreach (DataGridViewCell r in gridView.SelectedCells)
                    {
                        for (int i = 1; i < gridView.Rows[r.RowIndex].Cells.Count; i++)
                        {
                            gridView.Rows[r.RowIndex].Cells[i].Value = "";
                        }
                        gridView.Rows[r.RowIndex].Cells["기타(출장Code번호명기)"].Value = "연차";
                    }
                }

                allDay.Checked = false;
                return;
            }

            

            //입력된 프로젝트 코드와 시간을 받아온다.
            //주,보조,보조(PS),출장/외근 의 경우를 나눠서 입력한다.
            string mainP = pcodeTbox1 != null ? pcodeTbox1.Text.ToUpper() : string.Empty;
            if(!string.IsNullOrEmpty(mainP)) 
                if(checkAvailablePcode(mainP)==false) return;
            string assisP = pcodeTbox2 != null ? pcodeTbox2.Text.ToUpper() : string.Empty;
            if (!string.IsNullOrEmpty(assisP))
                if(checkAvailablePcode(assisP) == false) return;
            string psP = pcodeTbox3 != null ? pcodeTbox3.Text.ToUpper() : string.Empty;
            if (!string.IsNullOrEmpty(psP))
                if(checkAvailablePcode(psP) == false) return;
            string etcP = pcodeTbox4 != null ? pcodeTbox4.Text.ToUpper() : string.Empty;
            if (!string.IsNullOrEmpty(etcP))
                if(checkAvailablePcode(etcP) == false) return;
            string mainPtime = time1 != null ? time1.Text : string.Empty;
            string assisPtime = time2 != null ? time2.Text : string.Empty;
            string psPtime = time3 != null ? time3.Text : string.Empty;
            string etcPtime = time4 != null ? time4.Text : string.Empty;

            string etcP2 = etcTbox != null ? etcTbox.Text : string.Empty;


            //반차 여부 확인
            bool check_half = false;
            if(halfDay.Checked == true)
            {
                check_half = true;
            }

            //프로젝트 코드와 업무시간 두개가 동시에 입력되어 있어야 함 = 하나만 입력된 것은 안돼!
            if (((mainP != string.Empty) ? (mainPtime != string.Empty ? true : false) : (mainPtime == string.Empty ? true : false)) == true
                && ((assisP != string.Empty) ? (assisPtime != string.Empty ? true : false) : (assisPtime == string.Empty ? true : false)) == true
                && ((psP != string.Empty) ? (psPtime != string.Empty ? true : false) : (psPtime == string.Empty ? true : false)) == true
                && ((etcP != string.Empty) ? (etcPtime != string.Empty ? true : false) : (etcPtime == string.Empty ? true : false)) == true)
            {
                //두 짝이 동시에 채워져있어야 정상
                if (gridView.SelectedRows.Count != 0)
                {
                    foreach (DataGridViewRow r in gridView.SelectedRows)
                    {
                        r.Cells["주 프로젝트"].Value = mainP;
                        r.Cells[" "].Value = mainPtime;
                        r.Cells["보조 프로젝트"].Value = assisP;
                        r.Cells["  "].Value = assisPtime;
                        r.Cells["보조(PS) 프로젝트"].Value = psP;
                        r.Cells["   "].Value = psPtime;
                        r.Cells["출장/외근시간"].Value = etcP != "" ? etcP + "/" + etcPtime : "";
                        r.Cells["기타(출장Code번호명기)"].Value = check_half == true ? "반차" : etcP2;
                    }
                }
                else
                {
                    foreach (DataGridViewCell r in gridView.SelectedCells)
                    {
                        gridView.Rows[r.RowIndex].Cells["주 프로젝트"].Value = mainP;
                        gridView.Rows[r.RowIndex].Cells[" "].Value = mainPtime;
                        gridView.Rows[r.RowIndex].Cells["보조 프로젝트"].Value = assisP;
                        gridView.Rows[r.RowIndex].Cells["  "].Value = assisPtime;
                        gridView.Rows[r.RowIndex].Cells["보조(PS) 프로젝트"].Value = psP;
                        gridView.Rows[r.RowIndex].Cells["   "].Value = psPtime;
                        gridView.Rows[r.RowIndex].Cells["출장/외근시간"].Value = etcP != "" ? etcP + "/" + etcPtime : "";
                        gridView.Rows[r.RowIndex].Cells["기타(출장Code번호명기)"].Value = check_half == true ? "반차" : etcP2;
                    }
                }

                foreach (Control c in groupBox2.Controls)
                {
                    if (c is TextBox)
                    {
                        TextBox t = c as TextBox;
                        t.Text = string.Empty;
                    }
                }
                
                halfDay.Checked = false;
            }
            else
            {
                MessageBox.Show("프로젝트 코드와 시간을 모두 입력해야 합니다.");
                return;
            }
        }

        private bool checkAvailablePcode(string pcode)
        {
            DataRow[] foundPcode = pCodeTable.Select(string.Format("코드 = '{0}'", pcode));
            if (foundPcode.Length == 0)
            {
                MessageBox.Show("존재하지 않는 프로젝트 코드 : " + pcode);
                return false;
            }
            
            return true;

        }
        #endregion

        #region 프로젝트코드 검색 및 초기화 이벤트
        private void searchBtn_Click(object sender, EventArgs e)
        {
            if(pCodeTable == null)
                return;
            
            //검색 버튼 클릭 시
            string keyword = searchTextbox.Text.ToUpper();

            DataTable searchResult = new DataTable();
            searchResult.Columns.Add("코드");
            searchResult.Columns.Add("발주사");
            searchResult.Columns.Add("프로젝트");
            searchResult.Columns.Add("용역기간");

            for (int i=0; i< pCodeTable.Rows.Count; i++)
            {
                for(int j=0; j< pCodeTable.Rows[i].ItemArray.Length; j++)
                {
                    if (pCodeTable.Rows[i][j].ToString().Contains(keyword))
                    {
                        DataRow row = searchResult.NewRow();
                        row["코드"] = pCodeTable.Rows[i][0].ToString();
                        row["발주사"] = pCodeTable.Rows[i][1].ToString();
                        row["프로젝트"] = pCodeTable.Rows[i][2].ToString();
                        row["용역기간"] = pCodeTable.Rows[i][3].ToString();

                        searchResult.Rows.Add(row);
                    }
                }
            }

            pCodeGridView.DataSource = searchResult;
        }

        private void reset_Click(object sender, EventArgs e)
        {
            if(pCodeTable != null)
            {
                pCodeGridView.DataSource = pCodeTable;
            }
        }
        #endregion

        #region 선택한 프로젝트 코드 가져오기
        private void inputPcodeBtn_Click(object sender, EventArgs e)
        {
            //pCodeGridView에서 선택한 pcode를 옆쪽 엑셀그리드뷰에 옮기기
            string pcode;
            try
            {
                pcode = pCodeGridView.Rows[pCodeGridView.CurrentCell.RowIndex].Cells["코드"].Value.ToString();
                MetroButton btn = sender as MetroButton;
                switch(btn.Name)
                {
                    case "inputPcodeBtn1": pcodeTbox1.Text = pcode; break;
                    case "inputPcodeBtn2": pcodeTbox2.Text = pcode; break;
                    case "inputPcodeBtn3": pcodeTbox3.Text = pcode; break;
                    case "inputPcodeBtn4": pcodeTbox4.Text = pcode; break;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        #endregion

        #region 업무시간 입력 시 총 합계 계산(?)
        private void keyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void timeTboxTextChanged(object sender, EventArgs e)
        {
            double total = 0;
            foreach(Control c in groupBox2.Controls)
            {
                if(c is TextBox && (c.Name == "time1" || c.Name == "time2" || c.Name == "time3" || c.Name == "time4"))
                {
                    TextBox t = c as TextBox;
                    if(t.Text != string.Empty)
                    {
                        total += Double.Parse(t.Text);
                    }
                }
            }
            totalTime.Text = total.ToString();
            AfterChecked();
        }
        #endregion

        #region 연차/반차 체크박스 핸들링
        //체크박스 둘 중 하나만 체크되게 하기
        CheckBox lastChecked;
        private void chk_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;

            AfterChecked();
        }

        //연차 여부에 따른 텍스트박스 잠금
        private void AfterChecked()
        {
            if (lastChecked != null)
            {
                if (lastChecked.Text == "연차")
                {
                    foreach (Control control in groupBox2.Controls)
                    {
                        if(control is TextBox)
                        {
                            ((TextBox)control).Enabled = false;
                        }

                    }
                    totalTime.Text = 8.ToString();
                }
                else
                {
                    foreach (Control control in groupBox2.Controls)
                    {
                        if (control.Name == "etcTbox")
                        {
                            ((TextBox)control).Enabled = false;
                        }

                    }
                    totalTime.Text = (Int32.Parse(totalTime.Text) + 4).ToString();
                }
            }
            else
            {
                foreach (Control control in groupBox2.Controls)
                {
                    if (control is TextBox)
                    {
                        ((TextBox)control).Enabled = true;
                    }
                }

                int total = 0;
                foreach (Control c in groupBox2.Controls)
                {
                    if (c is TextBox && (c.Name == "time1" || c.Name == "time2" || c.Name == "time3" || c.Name == "time4"))
                    {
                        TextBox t = c as TextBox;
                        if (t.Text != string.Empty)
                        {
                            total += Int32.Parse(t.Text);
                        }
                    }
                }
                totalTime.Text = total.ToString();
            }
        }
        #endregion

        #region 임시 프로젝트 코드 관련 기능
        private void TempPcodeClicked (object sender, EventArgs e)
        {
            MetroButton btn = sender as MetroButton;

            if(btn.Text == "추가")
            {
                //임시 프로젝트코드 추가
                AddTempPcode addForm = new AddTempPcode(this);
                addForm.ShowDialog();

                if (flag.Text != "true")
                    return;

                pCodeTable.Rows.Add("P" + (pCodeTable.Rows.Count + 1).ToString(), textBox1.Text, textBox2.Text, "");

                //임시 프로젝트 코드는 따로 테이블에 보관
                tempPcodeTable.Rows.Add("P" + pCodeTable.Rows.Count.ToString(), textBox1.Text, textBox2.Text, "");

                //pCodeGridView.Rows.Add("P" + pCodeTable.Rows.Count.ToString(), textBox1.Text, textBox2.Text, "");
                pCodeGridView.DataSource = pCodeTable;

                flag.Text = "false";
            }
            else
            {
                //임시 프로젝트코드 삭제
                DeleteTempPcode delForm = new DeleteTempPcode(this);
                delForm.tempPcodeTable = tempPcodeTable;
                delForm.ShowDialog();

                if (flag.Text != "true")
                    return;

                //먼저 pcodeTable에서 temp를 다 지운다음
                for (int i = pCodeTable.Rows.Count - 1; i >= 0; i--)
                {
                    for(int j= tempPcodeTable.Rows.Count - 1; j >= 0; j--)
                    {
                        if(pCodeTable.Rows[i]["코드"].ToString() == tempPcodeTable.Rows[j]["코드"].ToString())
                        {
                            pCodeTable.Rows[i].Delete();
                            pCodeTable.AcceptChanges();
                            break;
                        }
                    }
                }
                
                //deletedCode를 temp에서 지운다
                string[] deletedCode = textBox1.Text.Split(',');
                for(int i = 0; i<deletedCode.Length; i++)
                {
                    for(int k = tempPcodeTable.Rows.Count - 1; k >= 0; k--)
                    {
                        if(tempPcodeTable.Rows[k]["코드"].ToString() == deletedCode[i])
                        {
                            tempPcodeTable.Rows[k].Delete();
                            tempPcodeTable.AcceptChanges();
                        }   
                    }
                }

                //임시코드 테이블 재정렬
                int lastNumberOfPcodeTable = pCodeTable.Rows.Count;
                for(int a = 0; a < tempPcodeTable.Rows.Count; a++)
                {
                    lastNumberOfPcodeTable++;
                    tempPcodeTable.Rows[a]["코드"] = "P" + lastNumberOfPcodeTable;
                }

                //재정렬 된 temp를 pcodeTable에 합친다
                pCodeTable.Merge(tempPcodeTable);
                pCodeGridView.DataSource = pCodeTable;

                flag.Text = "false";
            }
        }
        #endregion

        #region 엑셀 추출 기능
        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                th = new Thread(new ThreadStart(progressFunc));
                th.Start();
                
                //입력된 시간의 합이 하루에 8시간인지 체크
                for (int i = 1; i <= gridView.Rows.Count - 1; i++)
                {
                    gridView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                
                bool isCorrect = true;
                for(int i=1; i<=gridView.Rows.Count-1; i++)
                {
                    string holiday = string.IsNullOrEmpty(gridView.Rows[i].Cells["기타(출장Code번호명기)"].Value.ToString()) ?
                        "" : gridView.Rows[i].Cells["기타(출장Code번호명기)"].Value.ToString();
                    if (gridView.Rows[i].Cells["일자"].Style.ForeColor != Color.Red)
                    {
                        if(holiday != "연차" && holiday != "병가")
                        {
                            double c1 = (string.IsNullOrEmpty(gridView.Rows[i].Cells[" "].Value.ToString())) ? 0 : Double.Parse(gridView.Rows[i].Cells[" "].Value.ToString());
                            double c2 = string.IsNullOrEmpty(gridView.Rows[i].Cells["  "].Value.ToString()) ? 0 : Double.Parse(gridView.Rows[i].Cells["  "].Value.ToString());
                            double c3 = string.IsNullOrEmpty(gridView.Rows[i].Cells["   "].Value.ToString()) ? 0 : Double.Parse(gridView.Rows[i].Cells["   "].Value.ToString());
                            //출장/외근시간 다른 방법으로 해야지!
                            double c4 = string.IsNullOrEmpty(gridView.Rows[i].Cells["출장/외근시간"].Value.ToString()) ? 
                                0 :
                                Double.Parse(gridView.Rows[i].Cells["출장/외근시간"].Value.ToString().Substring(gridView.Rows[i].Cells["출장/외근시간"].Value.ToString().IndexOf("/")+1));
                            int halfHol = holiday == "반차" ? 4 : 0;
                            if((c1+c2+c3+c4+halfHol) != 8)
                            {
                                gridView.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                                isCorrect = false;
                            }
                            
                        }
                    }
                }
                if(isCorrect == false)
                {
                    MessageBox.Show("하루 업무시간의 합은 8시간이 되어야 합니다.");
                    pb.Close();
                    th.Abort(); 
                    return;
                }

                Excel.Application excel = new Excel.Application();
                Excel.Workbook wb = null;
                Excel.Worksheet ws = null;

                try
                {
                    //기존 양식을 불러 올 경로 ==> 나중에 바꿔야됨!!!
                    string formatPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\format.xlsx";
                    wb = excel.Workbooks.Open(formatPath);
                    ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;


                    //============== 탑뷰 ==============
                    ws.Range["B2"].Value = string.Format("{0}월 프로젝트 인력 투입 현황 (개인별)", selectMonth.SelectedItem.ToString());
                    int ld = DateTime.DaysInMonth(DateTime.Now.Year, Int32.Parse(selectMonth.SelectedItem.ToString()));
                    ws.Range["B3"].Value = string.Format("기준일 : {0}.{1}.{2} ~ {1}.{3}", 
                        DateTime.Now.Year.ToString(), selectMonth.SelectedItem.ToString(), 01, ld);
                    ws.Range["C5"].Value = string.Format("{0}사업부", departTbox.Text);   //부서명
                    ws.Range["I5"].Value = string.Format("{0}팀", teamTbox.Text);    //팀명
                    ws.Range["C6"].Value = writerTbox.Text;    //작성자
                    ws.Range["I6"].Value = jobTbox.Text;    //직위


                    //============== 가운데뷰 ==============
                    Excel.Range colRange = ws.Range["B10:B40"];
                    if (ld != 31)
                    {
                        int search = ld;

                        int rownum = 0;
                        for (int i=1; i<=colRange.Count; i++)
                        {
                            Excel.Range cell = (Excel.Range)colRange.Item[i];
                            if(cell.Value2.ToString() == (search + 1).ToString())
                            {
                                rownum = cell.Row;

                            }

                            if(redDays.Contains(int.Parse(cell.Value2.ToString())))
                            {
                               cell.Font.Color = Color.Red;
                            }
                        }

                        for (int i = 40; i >= rownum; i--)
                        {
                            ws.Rows[i].Delete();
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= colRange.Count; i++)
                        {
                            Excel.Range cell = (Excel.Range)colRange.Item[i];

                            if (redDays.Contains(int.Parse(cell.Value2.ToString())))
                            {
                                cell.Font.Color = Color.Red;
                            }
                        }

                    }

                    //3. PJ 코드 및 업무시간 입력하기
                    //gridView에 value가 있다면 -> 엑셀에서 해당 일자의 row를 찾아 입력하기
                    Dictionary<string, string> valueD = null;
                        
                    Dictionary<string, object> keyD
                        = new Dictionary<string, object>();

                    foreach (DataGridViewRow r in gridView.Rows)
                    {
                        for (int i = 1; i < r.Cells.Count; i++)
                        {
                            if (r.Cells[i].Value.ToString() != "")
                            {
                                if(r.Cells["일자"].Value.ToString() == "")
                                {
                                    break;
                                }
                                valueD = new Dictionary<string, string>();

                                valueD.Add("주", (r.Cells["주 프로젝트"].Value + "/" + r.Cells[" "].Value).ToString());
                                valueD.Add("보조", (r.Cells["보조 프로젝트"].Value + "/" + r.Cells["  "].Value).ToString());
                                valueD.Add("보조(PS)", (r.Cells["보조(PS) 프로젝트"].Value + "/" + r.Cells["   "].Value).ToString());
                                valueD.Add("출장/외근", r.Cells["출장/외근시간"].Value.ToString());
                                valueD.Add("기타", r.Cells["기타(출장Code번호명기)"].Value.ToString());

                                keyD.Add(r.Cells["일자"].Value.ToString(), valueD);
                                break;
                            }
                        }

                    }

                    foreach(KeyValuePair<string, object> item in keyD)
                    {
                        for (int j = 1; j <= colRange.Count; j++)
                        {
                            Excel.Range cell = (Excel.Range)colRange.Item[j];
                            if (cell.Value2.ToString() == item.Key)
                            {
                                Dictionary<string, string> val = (Dictionary<string, string>)item.Value;
                                int rowIndex = cell.Row;
                                ws.Cells[rowIndex, 3] = val["주"].Substring(0,val["주"].IndexOf('/'));  //주 프로젝트의 PJ코드
                                ws.Cells[rowIndex, 4] = val["주"].Substring(val["주"].IndexOf('/')+1);  //주 프로젝트의 업무시간
                                ws.Cells[rowIndex, 5] = val["보조"].Substring(0, val["보조"].IndexOf('/'));  //보조 프로젝트의 PJ코드
                                ws.Cells[rowIndex, 6] = val["보조"].Substring(val["보조"].IndexOf('/') + 1);  //보조 프로젝트의 업무시간
                                ws.Cells[rowIndex, 7] = val["보조(PS)"].Substring(0, val["보조(PS)"].IndexOf('/'));  //보조(PS) 프로젝트의 PJ코드
                                ws.Cells[rowIndex, 8] = val["보조(PS)"].Substring(val["보조(PS)"].IndexOf('/') + 1);  //보조(PS) 프로젝트의 업무시간
                                ws.Cells[rowIndex, 9] = val["출장/외근"];  //출장외근
                                ws.Cells[rowIndex, 10] = val["기타"];  //기타

                            }
                        }
                    }

                    //4. 각 업무시간의 합계를 계산하여 입력하기
                    Excel.Range totalRange = ws.Range["A36:K42"];
                    string searchStr = "합계";
                    Excel.Range resultRange = totalRange.Find(
                        What: searchStr,
                        LookIn: Excel.XlFindLookIn.xlValues,
                        LookAt: Excel.XlLookAt.xlPart,
                        SearchOrder: Excel.XlSearchOrder.xlByRows,
                        SearchDirection: Excel.XlSearchDirection.xlNext
                        );
                    int row = 0;
                    if(resultRange != null)
                    {
                        row = resultRange.Row;
                    }
                    ws.Cells[row, 4].Formula = "=Sum(" + ws.Cells[10, 4].Address + ":" + ws.Cells[row-1, 4].Address + ")";    //주 프로젝트 합계
                    ws.Cells[row, 6].Formula = "=Sum(" + ws.Cells[10, 6].Address + ":" + ws.Cells[row - 1, 6].Address + ")";    //보조 프로젝트 합계
                    ws.Cells[row, 8].Formula = "=Sum(" + ws.Cells[10, 8].Address + ":" + ws.Cells[row - 1, 8].Address + ")";    //보조(PS) 프로젝트 합계
                    //출장/외근시간 합계
                    int result = 0;
                    for(int i=10; i<=row-1; i++)
                    {
                        if(!string.IsNullOrEmpty((string)(ws.Cells[i, 9] as Excel.Range).Value))
                        {
                            string val = (string)(ws.Cells[i, 9] as Excel.Range).Value;
                            string time = val.Substring(val.IndexOf("/")+1);
                            result += int.Parse(time);
                        }
                    }
                    if(result != 0)
                    {
                        ws.Cells[row, 9] = result;
                    }
                    else
                    {
                        ws.Cells[row, 9] = "";
                    }


                    //==============  임시코드란 ==============
                    //1. 임시코드가 있는지 여부부터 판단
                    if(tempPcodeTable != null)
                    {
                        Excel.Range findRange = ws.Range["B8:J41"];
                        int tempCodeIndex = 9;

                        for (int i=0; i<tempPcodeTable.Rows.Count; i++)
                        {
                            string tempPcode = tempPcodeTable.Rows[i]["코드"].ToString();
                            Excel.Range isExist = findRange.Find(
                                            What: tempPcode,
                                            LookIn: Excel.XlFindLookIn.xlValues,
                                            LookAt: Excel.XlLookAt.xlPart,
                                            SearchOrder: Excel.XlSearchOrder.xlByRows,
                                            SearchDirection: Excel.XlSearchDirection.xlNext
                                        );
                            if(isExist != null)
                            {
                                if(tempCodeIndex == 9)
                                {
                                    ws.Cells[tempCodeIndex, 12] = "* 프로젝트 코드 리스트 부재로 인한 임시 추가";
                                    
                                    ws.Cells[tempCodeIndex+1, 12] = "코드";
                                    ws.Cells[tempCodeIndex+1, 13] = "발주사";
                                    ws.Cells[tempCodeIndex+1, 14] = "프로젝트";

                                    Excel.Range c1 = ws.Cells[tempCodeIndex + 1, 12];
                                    Excel.Range c2 = ws.Cells[tempCodeIndex + 1, 14];
                                    Excel.Range rg = ws.get_Range(c1, c2);
                                    rg.Font.Color = Color.Black;
                                    rg.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                                }

                                ws.Cells[tempCodeIndex+2, 12] = tempPcode;
                                ws.Cells[tempCodeIndex+2, 13] = tempPcodeTable.Rows[i]["발주사"].ToString();
                                ws.Cells[tempCodeIndex + 2, 14] = tempPcodeTable.Rows[i]["프로젝트"].ToString();

                                Excel.Range c3 = ws.Cells[tempCodeIndex + 2, 12];
                                Excel.Range c4 = ws.Cells[tempCodeIndex + 2, 14];
                                Excel.Range rg2 = ws.get_Range(c3, c4);
                                rg2.Font.Color = Color.Black;
                                rg2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                                tempCodeIndex++;

                            }
                        }

                    }

                    //엑셀 CSS 정리
                    ws.get_Range("C10", "J40").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    ws.get_Range("C10", "J41").Font.Color = Color.Black;

                    wb.SaveAs(sfd.FileName);
                    pb.Close();
                    th.Abort();
                    MessageBox.Show(sfd.FileName.ToString() + "에 저장되었습니다.");

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    pb.Close();
                    th.Abort();
                    MessageBox.Show("파일 저장에 실패하였습니다.");
                }
                finally
                {
                    if(wb != null)
                    {
                        wb.Close(0);
                    }
                    if(excel != null)
                    {
                        excel.Quit();
                    }

                    ReleaseExcelObject(ws);
                    ReleaseExcelObject(wb);
                    ReleaseExcelObject(excel);

                    bool state = false;
                    Process[] process = Process.GetProcessesByName("EXCEL");

                    // 전부 Excel 다죽어.
                    for (int i = 0; i < process.Length; i++)
                    {
                        state = false;
                        for (int j = 0; j < procList.Count; j++)
                        {
                            if (procList[j].Equals(process[i].Id.ToString()))
                            {
                                state = true;
                                break;
                            }

                            if ((j == procList.Count - 1) && !state)
                                process[i].Kill();
                        }
                    }
                }
            }
        }

        static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception e)
            {
                obj = null;
                throw e;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        private void pCodeGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void gridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView.SelectedCells.Count == 0)
                {
                    return;
                }
                else
                {
                    
                    DialogResult result = MessageBox.Show("선택된 행의 데이터를 삭제하시겠습니까?", "", MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        //선택된 셀의 행 데이터 삭제
                        foreach (DataGridViewCell c in gridView.SelectedCells)
                        {
                            for(int i=1; i<gridView.Rows[c.RowIndex].Cells.Count; i++)
                            {
                                gridView.Rows[c.RowIndex].Cells[i].Value = null;
                            }
                        }
                    }
                }
            }
        }

        private void gridView_SelectionChanged(object sender, EventArgs e)
        {
            //DataGridView dgv = sender as DataGridView;
            if(gridView != null && gridView.SelectedCells.Count > 0)
            {
              foreach(DataGridViewCell c in gridView.SelectedCells)
                {
                    if (gridView.Rows[c.RowIndex].Cells["일자"].Value.ToString() == "" || gridView.Rows[c.RowIndex].Cells["일자"].Style.ForeColor == Color.Red)
                    {
                        gridView.Rows[c.RowIndex].Selected = false;
                    }
                }
            }
        }

        private void startSearch(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //searchBtn이 눌러지도록
                searchBtn_Click(null, null);
            }
        }

        private void progressFunc()
        {
            pb = new ProgressBar();
            pb.ShowDialog();
        }

        private void pCodeGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tboxList = new List<TextBox>
            {
                pcodeTbox1,
                pcodeTbox2,
                pcodeTbox3,
                pcodeTbox4
            };

            string pcode = pCodeGridView.Rows[e.RowIndex].Cells["코드"].Value.ToString();

            for(int i=0; i<tboxList.Count; i++)
            {
                if(tboxList[i].Text == string.Empty)
                {
                    tboxList[i].Text = pcode;
                    break;
                }
            }
        }

    }
}
