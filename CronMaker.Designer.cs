namespace CronMakerUI
{
    partial class CronMaker
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cyclesTab = new System.Windows.Forms.TabControl();
            this.minutesTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.hourlyTabPage = new System.Windows.Forms.TabPage();
            this.hourlyStartMMCombo = new System.Windows.Forms.ComboBox();
            this.hourlyStartHHCombo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hourlyTextBox = new System.Windows.Forms.TextBox();
            this.hourlyAsStartsRadiobutton = new System.Windows.Forms.RadioButton();
            this.hourlyAsEveryRadiobutton = new System.Windows.Forms.RadioButton();
            this.dailyTabPage = new System.Windows.Forms.TabPage();
            this.dailyStartMMCombo = new System.Windows.Forms.ComboBox();
            this.dailyStartHHCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dailyTextBox = new System.Windows.Forms.TextBox();
            this.dailyAsEveryWeekRadiobutton = new System.Windows.Forms.RadioButton();
            this.dailyAsEveryAllRadiobutton = new System.Windows.Forms.RadioButton();
            this.weeklyTabPage = new System.Windows.Forms.TabPage();
            this.weeklyStartMMCombo = new System.Windows.Forms.ComboBox();
            this.weeklyStartHHCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.weeklySunCheckBox = new System.Windows.Forms.CheckBox();
            this.weeklySatCheckBox = new System.Windows.Forms.CheckBox();
            this.weeklyFriCheckBox = new System.Windows.Forms.CheckBox();
            this.weeklyThuCheckBox = new System.Windows.Forms.CheckBox();
            this.weeklyWedCheckBox = new System.Windows.Forms.CheckBox();
            this.weeklyTueCheckBox = new System.Windows.Forms.CheckBox();
            this.weeklyMonCheckBox = new System.Windows.Forms.CheckBox();
            this.monthlyTabPage = new System.Windows.Forms.TabPage();
            this.monthlyStartMMCombo = new System.Windows.Forms.ComboBox();
            this.monthlyStartHHCombo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.monthlyWeekMonthTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.monthlyWeekCombobox = new System.Windows.Forms.ComboBox();
            this.monthlyPeriodCombobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.monthlyDayMonthTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.monthlyDayTextBox = new System.Windows.Forms.TextBox();
            this.monthlyAsEveryWeekRadiobutton = new System.Windows.Forms.RadioButton();
            this.monthlyAsEveryDayRadiobutton = new System.Windows.Forms.RadioButton();
            this.yearlyTabPage = new System.Windows.Forms.TabPage();
            this.yearlyStartMMCombo = new System.Windows.Forms.ComboBox();
            this.yearlyStartHHCombo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.yearlyMonthCombobox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.yearlyWeekCombobox = new System.Windows.Forms.ComboBox();
            this.yearlyPeriodCombobox = new System.Windows.Forms.ComboBox();
            this.yearlyAsEveryDayTextbox = new System.Windows.Forms.TextBox();
            this.yearlyAsEveryDayMonthCombo = new System.Windows.Forms.ComboBox();
            this.yearlyAsEveryWeekRadiobutton = new System.Windows.Forms.RadioButton();
            this.yearlyAsEveryDayRadiobutton = new System.Windows.Forms.RadioButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.previewButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cyclesTab.SuspendLayout();
            this.minutesTabPage.SuspendLayout();
            this.hourlyTabPage.SuspendLayout();
            this.dailyTabPage.SuspendLayout();
            this.weeklyTabPage.SuspendLayout();
            this.monthlyTabPage.SuspendLayout();
            this.yearlyTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cyclesTab
            // 
            this.cyclesTab.Controls.Add(this.minutesTabPage);
            this.cyclesTab.Controls.Add(this.hourlyTabPage);
            this.cyclesTab.Controls.Add(this.dailyTabPage);
            this.cyclesTab.Controls.Add(this.weeklyTabPage);
            this.cyclesTab.Controls.Add(this.monthlyTabPage);
            this.cyclesTab.Controls.Add(this.yearlyTabPage);
            this.cyclesTab.Dock = System.Windows.Forms.DockStyle.Top;
            this.cyclesTab.Location = new System.Drawing.Point(0, 0);
            this.cyclesTab.Name = "cyclesTab";
            this.cyclesTab.SelectedIndex = 0;
            this.cyclesTab.Size = new System.Drawing.Size(506, 214);
            this.cyclesTab.TabIndex = 0;
            // 
            // minutesTabPage
            // 
            this.minutesTabPage.Controls.Add(this.label2);
            this.minutesTabPage.Controls.Add(this.minutesTextBox);
            this.minutesTabPage.Controls.Add(this.label1);
            this.minutesTabPage.Location = new System.Drawing.Point(4, 22);
            this.minutesTabPage.Name = "minutesTabPage";
            this.minutesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.minutesTabPage.Size = new System.Drawing.Size(498, 188);
            this.minutesTabPage.TabIndex = 0;
            this.minutesTabPage.Text = "Minutes";
            this.minutesTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "minute(s)";
            // 
            // minutesTextBox
            // 
            this.minutesTextBox.Location = new System.Drawing.Point(71, 32);
            this.minutesTextBox.Name = "minutesTextBox";
            this.minutesTextBox.Size = new System.Drawing.Size(52, 21);
            this.minutesTextBox.TabIndex = 1;
            this.minutesTextBox.Text = "1";
            this.minutesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Every";
            // 
            // hourlyTabPage
            // 
            this.hourlyTabPage.Controls.Add(this.hourlyStartMMCombo);
            this.hourlyTabPage.Controls.Add(this.hourlyStartHHCombo);
            this.hourlyTabPage.Controls.Add(this.label3);
            this.hourlyTabPage.Controls.Add(this.hourlyTextBox);
            this.hourlyTabPage.Controls.Add(this.hourlyAsStartsRadiobutton);
            this.hourlyTabPage.Controls.Add(this.hourlyAsEveryRadiobutton);
            this.hourlyTabPage.Location = new System.Drawing.Point(4, 22);
            this.hourlyTabPage.Name = "hourlyTabPage";
            this.hourlyTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.hourlyTabPage.Size = new System.Drawing.Size(498, 188);
            this.hourlyTabPage.TabIndex = 1;
            this.hourlyTabPage.Text = "Hourly";
            this.hourlyTabPage.UseVisualStyleBackColor = true;
            // 
            // hourlyStartMMCombo
            // 
            this.hourlyStartMMCombo.FormattingEnabled = true;
            this.hourlyStartMMCombo.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.hourlyStartMMCombo.Location = new System.Drawing.Point(178, 68);
            this.hourlyStartMMCombo.Name = "hourlyStartMMCombo";
            this.hourlyStartMMCombo.Size = new System.Drawing.Size(54, 20);
            this.hourlyStartMMCombo.TabIndex = 5;
            this.hourlyStartMMCombo.Text = "00";
            // 
            // hourlyStartHHCombo
            // 
            this.hourlyStartHHCombo.FormattingEnabled = true;
            this.hourlyStartHHCombo.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.hourlyStartHHCombo.Location = new System.Drawing.Point(118, 68);
            this.hourlyStartHHCombo.Name = "hourlyStartHHCombo";
            this.hourlyStartHHCombo.Size = new System.Drawing.Size(54, 20);
            this.hourlyStartHHCombo.TabIndex = 4;
            this.hourlyStartHHCombo.Text = "12";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(185, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "hour(s)";
            // 
            // hourlyTextBox
            // 
            this.hourlyTextBox.Location = new System.Drawing.Point(104, 29);
            this.hourlyTextBox.Name = "hourlyTextBox";
            this.hourlyTextBox.Size = new System.Drawing.Size(68, 21);
            this.hourlyTextBox.TabIndex = 2;
            this.hourlyTextBox.Text = "1";
            this.hourlyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hourlyAsStartsRadiobutton
            // 
            this.hourlyAsStartsRadiobutton.AutoSize = true;
            this.hourlyAsStartsRadiobutton.Location = new System.Drawing.Point(43, 72);
            this.hourlyAsStartsRadiobutton.Name = "hourlyAsStartsRadiobutton";
            this.hourlyAsStartsRadiobutton.Size = new System.Drawing.Size(69, 16);
            this.hourlyAsStartsRadiobutton.TabIndex = 1;
            this.hourlyAsStartsRadiobutton.Text = "Starts at";
            this.hourlyAsStartsRadiobutton.UseVisualStyleBackColor = true;
            // 
            // hourlyAsEveryRadiobutton
            // 
            this.hourlyAsEveryRadiobutton.AutoSize = true;
            this.hourlyAsEveryRadiobutton.Checked = true;
            this.hourlyAsEveryRadiobutton.Location = new System.Drawing.Point(43, 34);
            this.hourlyAsEveryRadiobutton.Name = "hourlyAsEveryRadiobutton";
            this.hourlyAsEveryRadiobutton.Size = new System.Drawing.Size(55, 16);
            this.hourlyAsEveryRadiobutton.TabIndex = 0;
            this.hourlyAsEveryRadiobutton.TabStop = true;
            this.hourlyAsEveryRadiobutton.Text = "Every";
            this.hourlyAsEveryRadiobutton.UseVisualStyleBackColor = true;
            // 
            // dailyTabPage
            // 
            this.dailyTabPage.Controls.Add(this.dailyStartMMCombo);
            this.dailyTabPage.Controls.Add(this.dailyStartHHCombo);
            this.dailyTabPage.Controls.Add(this.label5);
            this.dailyTabPage.Controls.Add(this.label4);
            this.dailyTabPage.Controls.Add(this.dailyTextBox);
            this.dailyTabPage.Controls.Add(this.dailyAsEveryWeekRadiobutton);
            this.dailyTabPage.Controls.Add(this.dailyAsEveryAllRadiobutton);
            this.dailyTabPage.Location = new System.Drawing.Point(4, 22);
            this.dailyTabPage.Name = "dailyTabPage";
            this.dailyTabPage.Size = new System.Drawing.Size(498, 188);
            this.dailyTabPage.TabIndex = 2;
            this.dailyTabPage.Text = "Daily";
            this.dailyTabPage.UseVisualStyleBackColor = true;
            // 
            // dailyStartMMCombo
            // 
            this.dailyStartMMCombo.FormattingEnabled = true;
            this.dailyStartMMCombo.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.dailyStartMMCombo.Location = new System.Drawing.Point(175, 114);
            this.dailyStartMMCombo.Name = "dailyStartMMCombo";
            this.dailyStartMMCombo.Size = new System.Drawing.Size(54, 20);
            this.dailyStartMMCombo.TabIndex = 8;
            this.dailyStartMMCombo.Text = "00";
            // 
            // dailyStartHHCombo
            // 
            this.dailyStartHHCombo.FormattingEnabled = true;
            this.dailyStartHHCombo.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.dailyStartHHCombo.Location = new System.Drawing.Point(112, 114);
            this.dailyStartHHCombo.Name = "dailyStartHHCombo";
            this.dailyStartHHCombo.Size = new System.Drawing.Size(54, 20);
            this.dailyStartHHCombo.TabIndex = 7;
            this.dailyStartHHCombo.Text = "12";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Start time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "day(s)";
            // 
            // dailyTextBox
            // 
            this.dailyTextBox.Location = new System.Drawing.Point(112, 36);
            this.dailyTextBox.Name = "dailyTextBox";
            this.dailyTextBox.Size = new System.Drawing.Size(68, 21);
            this.dailyTextBox.TabIndex = 4;
            this.dailyTextBox.Text = "1";
            this.dailyTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dailyAsEveryWeekRadiobutton
            // 
            this.dailyAsEveryWeekRadiobutton.AutoSize = true;
            this.dailyAsEveryWeekRadiobutton.Location = new System.Drawing.Point(51, 79);
            this.dailyAsEveryWeekRadiobutton.Name = "dailyAsEveryWeekRadiobutton";
            this.dailyAsEveryWeekRadiobutton.Size = new System.Drawing.Size(115, 16);
            this.dailyAsEveryWeekRadiobutton.TabIndex = 3;
            this.dailyAsEveryWeekRadiobutton.Text = "Every Week Day";
            this.dailyAsEveryWeekRadiobutton.UseVisualStyleBackColor = true;
            // 
            // dailyAsEveryAllRadiobutton
            // 
            this.dailyAsEveryAllRadiobutton.AutoSize = true;
            this.dailyAsEveryAllRadiobutton.Checked = true;
            this.dailyAsEveryAllRadiobutton.Location = new System.Drawing.Point(51, 41);
            this.dailyAsEveryAllRadiobutton.Name = "dailyAsEveryAllRadiobutton";
            this.dailyAsEveryAllRadiobutton.Size = new System.Drawing.Size(55, 16);
            this.dailyAsEveryAllRadiobutton.TabIndex = 2;
            this.dailyAsEveryAllRadiobutton.TabStop = true;
            this.dailyAsEveryAllRadiobutton.Text = "Every";
            this.dailyAsEveryAllRadiobutton.UseVisualStyleBackColor = true;
            // 
            // weeklyTabPage
            // 
            this.weeklyTabPage.Controls.Add(this.weeklyStartMMCombo);
            this.weeklyTabPage.Controls.Add(this.weeklyStartHHCombo);
            this.weeklyTabPage.Controls.Add(this.label6);
            this.weeklyTabPage.Controls.Add(this.weeklySunCheckBox);
            this.weeklyTabPage.Controls.Add(this.weeklySatCheckBox);
            this.weeklyTabPage.Controls.Add(this.weeklyFriCheckBox);
            this.weeklyTabPage.Controls.Add(this.weeklyThuCheckBox);
            this.weeklyTabPage.Controls.Add(this.weeklyWedCheckBox);
            this.weeklyTabPage.Controls.Add(this.weeklyTueCheckBox);
            this.weeklyTabPage.Controls.Add(this.weeklyMonCheckBox);
            this.weeklyTabPage.Location = new System.Drawing.Point(4, 22);
            this.weeklyTabPage.Name = "weeklyTabPage";
            this.weeklyTabPage.Size = new System.Drawing.Size(498, 188);
            this.weeklyTabPage.TabIndex = 3;
            this.weeklyTabPage.Text = "Weekly";
            this.weeklyTabPage.UseVisualStyleBackColor = true;
            // 
            // weeklyStartMMCombo
            // 
            this.weeklyStartMMCombo.FormattingEnabled = true;
            this.weeklyStartMMCombo.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.weeklyStartMMCombo.Location = new System.Drawing.Point(175, 142);
            this.weeklyStartMMCombo.Name = "weeklyStartMMCombo";
            this.weeklyStartMMCombo.Size = new System.Drawing.Size(54, 20);
            this.weeklyStartMMCombo.TabIndex = 11;
            this.weeklyStartMMCombo.Text = "00";
            // 
            // weeklyStartHHCombo
            // 
            this.weeklyStartHHCombo.FormattingEnabled = true;
            this.weeklyStartHHCombo.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.weeklyStartHHCombo.Location = new System.Drawing.Point(112, 142);
            this.weeklyStartHHCombo.Name = "weeklyStartHHCombo";
            this.weeklyStartHHCombo.Size = new System.Drawing.Size(54, 20);
            this.weeklyStartHHCombo.TabIndex = 10;
            this.weeklyStartHHCombo.Text = "12";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "Start time";
            // 
            // weeklySunCheckBox
            // 
            this.weeklySunCheckBox.AutoSize = true;
            this.weeklySunCheckBox.Location = new System.Drawing.Point(234, 95);
            this.weeklySunCheckBox.Name = "weeklySunCheckBox";
            this.weeklySunCheckBox.Size = new System.Drawing.Size(67, 16);
            this.weeklySunCheckBox.TabIndex = 6;
            this.weeklySunCheckBox.Text = "Sunday";
            this.weeklySunCheckBox.UseVisualStyleBackColor = true;
            // 
            // weeklySatCheckBox
            // 
            this.weeklySatCheckBox.AutoSize = true;
            this.weeklySatCheckBox.Location = new System.Drawing.Point(142, 95);
            this.weeklySatCheckBox.Name = "weeklySatCheckBox";
            this.weeklySatCheckBox.Size = new System.Drawing.Size(74, 16);
            this.weeklySatCheckBox.TabIndex = 5;
            this.weeklySatCheckBox.Text = "Saturday";
            this.weeklySatCheckBox.UseVisualStyleBackColor = true;
            // 
            // weeklyFriCheckBox
            // 
            this.weeklyFriCheckBox.AutoSize = true;
            this.weeklyFriCheckBox.Location = new System.Drawing.Point(50, 95);
            this.weeklyFriCheckBox.Name = "weeklyFriCheckBox";
            this.weeklyFriCheckBox.Size = new System.Drawing.Size(59, 16);
            this.weeklyFriCheckBox.TabIndex = 4;
            this.weeklyFriCheckBox.Text = "Friday";
            this.weeklyFriCheckBox.UseVisualStyleBackColor = true;
            // 
            // weeklyThuCheckBox
            // 
            this.weeklyThuCheckBox.AutoSize = true;
            this.weeklyThuCheckBox.Location = new System.Drawing.Point(326, 52);
            this.weeklyThuCheckBox.Name = "weeklyThuCheckBox";
            this.weeklyThuCheckBox.Size = new System.Drawing.Size(78, 16);
            this.weeklyThuCheckBox.TabIndex = 3;
            this.weeklyThuCheckBox.Text = "Thursday";
            this.weeklyThuCheckBox.UseVisualStyleBackColor = true;
            // 
            // weeklyWedCheckBox
            // 
            this.weeklyWedCheckBox.AutoSize = true;
            this.weeklyWedCheckBox.Location = new System.Drawing.Point(234, 52);
            this.weeklyWedCheckBox.Name = "weeklyWedCheckBox";
            this.weeklyWedCheckBox.Size = new System.Drawing.Size(90, 16);
            this.weeklyWedCheckBox.TabIndex = 2;
            this.weeklyWedCheckBox.Text = "Wednesday";
            this.weeklyWedCheckBox.UseVisualStyleBackColor = true;
            // 
            // weeklyTueCheckBox
            // 
            this.weeklyTueCheckBox.AutoSize = true;
            this.weeklyTueCheckBox.Location = new System.Drawing.Point(142, 52);
            this.weeklyTueCheckBox.Name = "weeklyTueCheckBox";
            this.weeklyTueCheckBox.Size = new System.Drawing.Size(74, 16);
            this.weeklyTueCheckBox.TabIndex = 1;
            this.weeklyTueCheckBox.Text = "Tuesday";
            this.weeklyTueCheckBox.UseVisualStyleBackColor = true;
            // 
            // weeklyMonCheckBox
            // 
            this.weeklyMonCheckBox.AutoSize = true;
            this.weeklyMonCheckBox.Location = new System.Drawing.Point(50, 52);
            this.weeklyMonCheckBox.Name = "weeklyMonCheckBox";
            this.weeklyMonCheckBox.Size = new System.Drawing.Size(70, 16);
            this.weeklyMonCheckBox.TabIndex = 0;
            this.weeklyMonCheckBox.Text = "Monday";
            this.weeklyMonCheckBox.UseVisualStyleBackColor = true;
            // 
            // monthlyTabPage
            // 
            this.monthlyTabPage.Controls.Add(this.monthlyStartMMCombo);
            this.monthlyTabPage.Controls.Add(this.monthlyStartHHCombo);
            this.monthlyTabPage.Controls.Add(this.label11);
            this.monthlyTabPage.Controls.Add(this.label10);
            this.monthlyTabPage.Controls.Add(this.monthlyWeekMonthTextBox);
            this.monthlyTabPage.Controls.Add(this.label9);
            this.monthlyTabPage.Controls.Add(this.monthlyWeekCombobox);
            this.monthlyTabPage.Controls.Add(this.monthlyPeriodCombobox);
            this.monthlyTabPage.Controls.Add(this.label8);
            this.monthlyTabPage.Controls.Add(this.monthlyDayMonthTextBox);
            this.monthlyTabPage.Controls.Add(this.label7);
            this.monthlyTabPage.Controls.Add(this.monthlyDayTextBox);
            this.monthlyTabPage.Controls.Add(this.monthlyAsEveryWeekRadiobutton);
            this.monthlyTabPage.Controls.Add(this.monthlyAsEveryDayRadiobutton);
            this.monthlyTabPage.Location = new System.Drawing.Point(4, 22);
            this.monthlyTabPage.Name = "monthlyTabPage";
            this.monthlyTabPage.Size = new System.Drawing.Size(498, 188);
            this.monthlyTabPage.TabIndex = 4;
            this.monthlyTabPage.Text = "Monthly";
            this.monthlyTabPage.UseVisualStyleBackColor = true;
            // 
            // monthlyStartMMCombo
            // 
            this.monthlyStartMMCombo.FormattingEnabled = true;
            this.monthlyStartMMCombo.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.monthlyStartMMCombo.Location = new System.Drawing.Point(188, 128);
            this.monthlyStartMMCombo.Name = "monthlyStartMMCombo";
            this.monthlyStartMMCombo.Size = new System.Drawing.Size(54, 20);
            this.monthlyStartMMCombo.TabIndex = 17;
            this.monthlyStartMMCombo.Text = "00";
            // 
            // monthlyStartHHCombo
            // 
            this.monthlyStartHHCombo.FormattingEnabled = true;
            this.monthlyStartHHCombo.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.monthlyStartHHCombo.Location = new System.Drawing.Point(125, 128);
            this.monthlyStartHHCombo.Name = "monthlyStartHHCombo";
            this.monthlyStartHHCombo.Size = new System.Drawing.Size(54, 20);
            this.monthlyStartHHCombo.TabIndex = 16;
            this.monthlyStartHHCombo.Text = "12";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "Start time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(376, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "month(s)";
            // 
            // monthlyWeekMonthTextBox
            // 
            this.monthlyWeekMonthTextBox.Location = new System.Drawing.Point(326, 88);
            this.monthlyWeekMonthTextBox.Name = "monthlyWeekMonthTextBox";
            this.monthlyWeekMonthTextBox.Size = new System.Drawing.Size(44, 21);
            this.monthlyWeekMonthTextBox.TabIndex = 13;
            this.monthlyWeekMonthTextBox.Text = "1";
            this.monthlyWeekMonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 12);
            this.label9.TabIndex = 12;
            this.label9.Text = "of every";
            // 
            // monthlyWeekCombobox
            // 
            this.monthlyWeekCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthlyWeekCombobox.FormattingEnabled = true;
            this.monthlyWeekCombobox.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.monthlyWeekCombobox.Location = new System.Drawing.Point(188, 88);
            this.monthlyWeekCombobox.Name = "monthlyWeekCombobox";
            this.monthlyWeekCombobox.Size = new System.Drawing.Size(76, 20);
            this.monthlyWeekCombobox.TabIndex = 11;
            // 
            // monthlyPeriodCombobox
            // 
            this.monthlyPeriodCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monthlyPeriodCombobox.FormattingEnabled = true;
            this.monthlyPeriodCombobox.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth"});
            this.monthlyPeriodCombobox.Location = new System.Drawing.Point(114, 88);
            this.monthlyPeriodCombobox.Name = "monthlyPeriodCombobox";
            this.monthlyPeriodCombobox.Size = new System.Drawing.Size(68, 20);
            this.monthlyPeriodCombobox.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "month(s)";
            // 
            // monthlyDayMonthTextBox
            // 
            this.monthlyDayMonthTextBox.Location = new System.Drawing.Point(220, 49);
            this.monthlyDayMonthTextBox.Name = "monthlyDayMonthTextBox";
            this.monthlyDayMonthTextBox.Size = new System.Drawing.Size(44, 21);
            this.monthlyDayMonthTextBox.TabIndex = 8;
            this.monthlyDayMonthTextBox.Text = "1";
            this.monthlyDayMonthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(164, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "of every";
            // 
            // monthlyDayTextBox
            // 
            this.monthlyDayTextBox.Location = new System.Drawing.Point(114, 49);
            this.monthlyDayTextBox.Name = "monthlyDayTextBox";
            this.monthlyDayTextBox.Size = new System.Drawing.Size(44, 21);
            this.monthlyDayTextBox.TabIndex = 6;
            this.monthlyDayTextBox.Text = "1";
            this.monthlyDayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // monthlyAsEveryWeekRadiobutton
            // 
            this.monthlyAsEveryWeekRadiobutton.AutoSize = true;
            this.monthlyAsEveryWeekRadiobutton.Location = new System.Drawing.Point(63, 92);
            this.monthlyAsEveryWeekRadiobutton.Name = "monthlyAsEveryWeekRadiobutton";
            this.monthlyAsEveryWeekRadiobutton.Size = new System.Drawing.Size(45, 16);
            this.monthlyAsEveryWeekRadiobutton.TabIndex = 5;
            this.monthlyAsEveryWeekRadiobutton.Text = "The";
            this.monthlyAsEveryWeekRadiobutton.UseVisualStyleBackColor = true;
            // 
            // monthlyAsEveryDayRadiobutton
            // 
            this.monthlyAsEveryDayRadiobutton.AutoSize = true;
            this.monthlyAsEveryDayRadiobutton.Checked = true;
            this.monthlyAsEveryDayRadiobutton.Location = new System.Drawing.Point(63, 54);
            this.monthlyAsEveryDayRadiobutton.Name = "monthlyAsEveryDayRadiobutton";
            this.monthlyAsEveryDayRadiobutton.Size = new System.Drawing.Size(45, 16);
            this.monthlyAsEveryDayRadiobutton.TabIndex = 4;
            this.monthlyAsEveryDayRadiobutton.TabStop = true;
            this.monthlyAsEveryDayRadiobutton.Text = "Day";
            this.monthlyAsEveryDayRadiobutton.UseVisualStyleBackColor = true;
            // 
            // yearlyTabPage
            // 
            this.yearlyTabPage.Controls.Add(this.yearlyStartMMCombo);
            this.yearlyTabPage.Controls.Add(this.yearlyStartHHCombo);
            this.yearlyTabPage.Controls.Add(this.label13);
            this.yearlyTabPage.Controls.Add(this.yearlyMonthCombobox);
            this.yearlyTabPage.Controls.Add(this.label12);
            this.yearlyTabPage.Controls.Add(this.yearlyWeekCombobox);
            this.yearlyTabPage.Controls.Add(this.yearlyPeriodCombobox);
            this.yearlyTabPage.Controls.Add(this.yearlyAsEveryDayTextbox);
            this.yearlyTabPage.Controls.Add(this.yearlyAsEveryDayMonthCombo);
            this.yearlyTabPage.Controls.Add(this.yearlyAsEveryWeekRadiobutton);
            this.yearlyTabPage.Controls.Add(this.yearlyAsEveryDayRadiobutton);
            this.yearlyTabPage.Location = new System.Drawing.Point(4, 22);
            this.yearlyTabPage.Name = "yearlyTabPage";
            this.yearlyTabPage.Size = new System.Drawing.Size(498, 188);
            this.yearlyTabPage.TabIndex = 5;
            this.yearlyTabPage.Text = "Yearly";
            this.yearlyTabPage.UseVisualStyleBackColor = true;
            // 
            // yearlyStartMMCombo
            // 
            this.yearlyStartMMCombo.FormattingEnabled = true;
            this.yearlyStartMMCombo.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.yearlyStartMMCombo.Location = new System.Drawing.Point(179, 131);
            this.yearlyStartMMCombo.Name = "yearlyStartMMCombo";
            this.yearlyStartMMCombo.Size = new System.Drawing.Size(54, 20);
            this.yearlyStartMMCombo.TabIndex = 20;
            this.yearlyStartMMCombo.Text = "00";
            // 
            // yearlyStartHHCombo
            // 
            this.yearlyStartHHCombo.FormattingEnabled = true;
            this.yearlyStartHHCombo.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.yearlyStartHHCombo.Location = new System.Drawing.Point(116, 131);
            this.yearlyStartHHCombo.Name = "yearlyStartHHCombo";
            this.yearlyStartHHCombo.Size = new System.Drawing.Size(54, 20);
            this.yearlyStartHHCombo.TabIndex = 19;
            this.yearlyStartHHCombo.Text = "12";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 134);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 12);
            this.label13.TabIndex = 18;
            this.label13.Text = "Start time";
            // 
            // yearlyMonthCombobox
            // 
            this.yearlyMonthCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearlyMonthCombobox.FormattingEnabled = true;
            this.yearlyMonthCombobox.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.yearlyMonthCombobox.Location = new System.Drawing.Point(282, 89);
            this.yearlyMonthCombobox.Name = "yearlyMonthCombobox";
            this.yearlyMonthCombobox.Size = new System.Drawing.Size(108, 20);
            this.yearlyMonthCombobox.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(261, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 12);
            this.label12.TabIndex = 15;
            this.label12.Text = "of";
            // 
            // yearlyWeekCombobox
            // 
            this.yearlyWeekCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearlyWeekCombobox.FormattingEnabled = true;
            this.yearlyWeekCombobox.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.yearlyWeekCombobox.Location = new System.Drawing.Point(179, 89);
            this.yearlyWeekCombobox.Name = "yearlyWeekCombobox";
            this.yearlyWeekCombobox.Size = new System.Drawing.Size(76, 20);
            this.yearlyWeekCombobox.TabIndex = 14;
            // 
            // yearlyPeriodCombobox
            // 
            this.yearlyPeriodCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearlyPeriodCombobox.FormattingEnabled = true;
            this.yearlyPeriodCombobox.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth"});
            this.yearlyPeriodCombobox.Location = new System.Drawing.Point(105, 89);
            this.yearlyPeriodCombobox.Name = "yearlyPeriodCombobox";
            this.yearlyPeriodCombobox.Size = new System.Drawing.Size(68, 20);
            this.yearlyPeriodCombobox.TabIndex = 13;
            // 
            // yearlyAsEveryDayTextbox
            // 
            this.yearlyAsEveryDayTextbox.Location = new System.Drawing.Point(229, 55);
            this.yearlyAsEveryDayTextbox.Name = "yearlyAsEveryDayTextbox";
            this.yearlyAsEveryDayTextbox.Size = new System.Drawing.Size(44, 21);
            this.yearlyAsEveryDayTextbox.TabIndex = 12;
            this.yearlyAsEveryDayTextbox.Text = "1";
            this.yearlyAsEveryDayTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // yearlyAsEveryDayMonthCombo
            // 
            this.yearlyAsEveryDayMonthCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearlyAsEveryDayMonthCombo.FormattingEnabled = true;
            this.yearlyAsEveryDayMonthCombo.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.yearlyAsEveryDayMonthCombo.Location = new System.Drawing.Point(115, 55);
            this.yearlyAsEveryDayMonthCombo.Name = "yearlyAsEveryDayMonthCombo";
            this.yearlyAsEveryDayMonthCombo.Size = new System.Drawing.Size(108, 20);
            this.yearlyAsEveryDayMonthCombo.TabIndex = 11;
            // 
            // yearlyAsEveryWeekRadiobutton
            // 
            this.yearlyAsEveryWeekRadiobutton.AutoSize = true;
            this.yearlyAsEveryWeekRadiobutton.Location = new System.Drawing.Point(54, 93);
            this.yearlyAsEveryWeekRadiobutton.Name = "yearlyAsEveryWeekRadiobutton";
            this.yearlyAsEveryWeekRadiobutton.Size = new System.Drawing.Size(45, 16);
            this.yearlyAsEveryWeekRadiobutton.TabIndex = 7;
            this.yearlyAsEveryWeekRadiobutton.Text = "The";
            this.yearlyAsEveryWeekRadiobutton.UseVisualStyleBackColor = true;
            // 
            // yearlyAsEveryDayRadiobutton
            // 
            this.yearlyAsEveryDayRadiobutton.AutoSize = true;
            this.yearlyAsEveryDayRadiobutton.Checked = true;
            this.yearlyAsEveryDayRadiobutton.Location = new System.Drawing.Point(54, 55);
            this.yearlyAsEveryDayRadiobutton.Name = "yearlyAsEveryDayRadiobutton";
            this.yearlyAsEveryDayRadiobutton.Size = new System.Drawing.Size(55, 16);
            this.yearlyAsEveryDayRadiobutton.TabIndex = 6;
            this.yearlyAsEveryDayRadiobutton.TabStop = true;
            this.yearlyAsEveryDayRadiobutton.Text = "Every";
            this.yearlyAsEveryDayRadiobutton.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 252);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(506, 110);
            this.listBox1.TabIndex = 1;
            // 
            // previewButton
            // 
            this.previewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewButton.Location = new System.Drawing.Point(0, 2);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(506, 34);
            this.previewButton.TabIndex = 2;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.previewButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 214);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.panel1.Size = new System.Drawing.Size(506, 38);
            this.panel1.TabIndex = 3;
            // 
            // CronMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cyclesTab);
            this.Name = "CronMaker";
            this.Size = new System.Drawing.Size(506, 362);
            this.cyclesTab.ResumeLayout(false);
            this.minutesTabPage.ResumeLayout(false);
            this.minutesTabPage.PerformLayout();
            this.hourlyTabPage.ResumeLayout(false);
            this.hourlyTabPage.PerformLayout();
            this.dailyTabPage.ResumeLayout(false);
            this.dailyTabPage.PerformLayout();
            this.weeklyTabPage.ResumeLayout(false);
            this.weeklyTabPage.PerformLayout();
            this.monthlyTabPage.ResumeLayout(false);
            this.monthlyTabPage.PerformLayout();
            this.yearlyTabPage.ResumeLayout(false);
            this.yearlyTabPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl cyclesTab;
        private System.Windows.Forms.TabPage minutesTabPage;
        private System.Windows.Forms.TabPage hourlyTabPage;
        private System.Windows.Forms.TabPage dailyTabPage;
        private System.Windows.Forms.TabPage weeklyTabPage;
        private System.Windows.Forms.TabPage monthlyTabPage;
        private System.Windows.Forms.TabPage yearlyTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox minutesTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hourlyTextBox;
        private System.Windows.Forms.RadioButton hourlyAsStartsRadiobutton;
        private System.Windows.Forms.RadioButton hourlyAsEveryRadiobutton;
        private System.Windows.Forms.ComboBox hourlyStartMMCombo;
        private System.Windows.Forms.ComboBox hourlyStartHHCombo;
        private System.Windows.Forms.RadioButton dailyAsEveryWeekRadiobutton;
        private System.Windows.Forms.RadioButton dailyAsEveryAllRadiobutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dailyTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dailyStartMMCombo;
        private System.Windows.Forms.ComboBox dailyStartHHCombo;
        private System.Windows.Forms.ComboBox weeklyStartMMCombo;
        private System.Windows.Forms.ComboBox weeklyStartHHCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox weeklySunCheckBox;
        private System.Windows.Forms.CheckBox weeklySatCheckBox;
        private System.Windows.Forms.CheckBox weeklyFriCheckBox;
        private System.Windows.Forms.CheckBox weeklyThuCheckBox;
        private System.Windows.Forms.CheckBox weeklyWedCheckBox;
        private System.Windows.Forms.CheckBox weeklyTueCheckBox;
        private System.Windows.Forms.CheckBox weeklyMonCheckBox;
        private System.Windows.Forms.TextBox monthlyDayMonthTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox monthlyDayTextBox;
        private System.Windows.Forms.RadioButton monthlyAsEveryWeekRadiobutton;
        private System.Windows.Forms.RadioButton monthlyAsEveryDayRadiobutton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox monthlyPeriodCombobox;
        private System.Windows.Forms.ComboBox monthlyWeekCombobox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox monthlyWeekMonthTextBox;
        private System.Windows.Forms.ComboBox monthlyStartMMCombo;
        private System.Windows.Forms.ComboBox monthlyStartHHCombo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton yearlyAsEveryWeekRadiobutton;
        private System.Windows.Forms.RadioButton yearlyAsEveryDayRadiobutton;
        private System.Windows.Forms.ComboBox yearlyAsEveryDayMonthCombo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox yearlyWeekCombobox;
        private System.Windows.Forms.ComboBox yearlyPeriodCombobox;
        private System.Windows.Forms.TextBox yearlyAsEveryDayTextbox;
        private System.Windows.Forms.ComboBox yearlyStartMMCombo;
        private System.Windows.Forms.ComboBox yearlyStartHHCombo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox yearlyMonthCombobox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Panel panel1;
    }
}
