using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quartz;

namespace CronMakerUI
{
    public partial class CronMaker : UserControl
    {
        public CronMaker()
        {
            InitializeComponent();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            var trigger = TriggerBuilder.Create()
                            .WithIdentity("your-trigger", "your-group")
                            .WithSimpleSchedule(x => x
                                .WithIntervalInMinutes(70)
                                .RepeatForever())
                            .Build();
            
            var cronExpression = GetCronFormat();
            cronExpression = "0 20/59 9/1 ? * *"; //1시반 2시반 3시반 9시부 시작해서 매 두시간씩
            //cronExpression = "0 0/30 8-9 5,20 * ?";
            //cronExpression = "0 0/14 * 1/1 * ? *";
            //cronExpression = "0 0/30 8-9 5,20 * ?”;
            //*매월 5일, 20일 오전 8시부터 오전 10시 사이에 30분 간격으로 실행. 이 트리거는 10:00 am에는 실행이 되지 않고, 8:00, 8:30, 9:00, 9:30 에만 실행 된다.
            Quartz.CronExpression exp = new CronExpression(cronExpression);

            var nextTime = new DateTimeOffset(DateTime.Now);

            for (var i = 0; i<10; i++)
            {
                nextTime = exp.GetNextValidTimeAfter(nextTime).Value;
                listBox1.Items.Add(nextTime.LocalDateTime);
            }

            listBox1.Items.Add(GetCronFormat());
        }

        public string GetCronFormat()
        {
            // http://www.cronmaker.com/
            var idx = cyclesTab.SelectedIndex;
            if (idx == 0) //every minutes
            {
                return $"0 0/{minutesTextBox.Text} * 1/1 * ? *";
            }
            else if (idx == 1) //every hours
            {
                if (hourlyAsEveryRadiobutton.Checked)
                {
                    var hh = int.Parse(hourlyTextBox.Text);
                    return $"0 0 0/{hourlyTextBox.Text} 1/1 * ? *";
                }
                else
                {
                    var hh = int.Parse(hourlyStartHHCombo.Text);
                    var mm = int.Parse(hourlyStartMMCombo.Text);
                    return $"0 {mm} {hh} 1/1 * ? *";
                }
            }
            else if (idx == 2) //every daily
            {
                var hh = int.Parse(dailyStartHHCombo.Text);
                var mm = int.Parse(dailyStartMMCombo.Text);
                if (dailyAsEveryAllRadiobutton.Checked)
                {
                    var dd = int.Parse(dailyTextBox.Text);
                    return $"0 {mm} {hh} 1/{dd} * ? *";
                }
                else
                {
                    return $"0 {mm} {hh} ? * MON-FRI *";
                }
            }
            else if (idx == 3) //every weekly
            {
                List<string> selectedDays = new List<string>();
                if (weeklyMonCheckBox.Checked) selectedDays.Add("MON");
                if (weeklyTueCheckBox.Checked) selectedDays.Add("TUE");
                if (weeklyWedCheckBox.Checked) selectedDays.Add("WED");
                if (weeklyThuCheckBox.Checked) selectedDays.Add("THU");
                if (weeklyFriCheckBox.Checked) selectedDays.Add("FRI");
                if (weeklySatCheckBox.Checked) selectedDays.Add("SAT");
                if (weeklySunCheckBox.Checked) selectedDays.Add("SUN");

                var hh = int.Parse(weeklyStartHHCombo.Text);
                var mm = int.Parse(weeklyStartMMCombo.Text);
                return $"0 {mm} {hh} ? * {string.Join(",", selectedDays)} *";
            }
            else if (idx == 4) //every monthly
            {
                var hh = int.Parse(monthlyStartHHCombo.Text);
                var mm = int.Parse(monthlyStartMMCombo.Text);
                if (monthlyAsEveryDayRadiobutton.Checked)
                {
                    var monthlyDayOfOne =  int.Parse(monthlyDayTextBox.Text); // 1~31
                    var monthlyMonthOfOne = int.Parse(monthlyDayMonthTextBox.Text); //1~12 유효성 체크할 것.
                    return $"0 {mm} {hh} {monthlyDayOfOne} 1/{monthlyMonthOfOne} ? *";
                }
                else
                {
                    var monthlyPeriodOfTwo = monthlyPeriodCombobox.SelectedIndex + 1;
                    var monthlyWeekOfTwo = WeekNameShorten(monthlyWeekCombobox.Text);
                    var monthlyMonthOfTwo = int.Parse(monthlyWeekMonthTextBox.Text); //1~12 유효성 체크할 것.
                    return $"0 {mm} {hh} ? 1/{monthlyMonthOfTwo} {monthlyWeekOfTwo}#{monthlyPeriodOfTwo} * ";
                }
            }
            else //yearly
            {
                var hh = int.Parse(yearlyStartHHCombo.Text);
                var mm = int.Parse(yearlyStartMMCombo.Text);

                if (yearlyAsEveryDayRadiobutton.Checked)
                {
                    var yearlyMonthOfOne = yearlyAsEveryDayMonthCombo.SelectedIndex + 1;
                    var yearlyDayOfOne = int.Parse(yearlyAsEveryDayTextbox.Text); //1~31 유효성 체크할 것.                   
                    return $"0 {mm} {hh} {yearlyDayOfOne} {yearlyMonthOfOne} ? *";
                }
                else
                {
                    var yearlyPeriodOfTwo = yearlyPeriodCombobox.SelectedIndex + 1;
                    var yearlyWeekOfTwo = WeekNameShorten(yearlyWeekCombobox.Text);
                    var yearlyMonthOfTwo = yearlyMonthCombobox.SelectedIndex + 1; //1~12 유효성 체크할 것.
                    return $"0 {mm} {hh} ? {yearlyMonthOfTwo} {yearlyWeekOfTwo}#{yearlyPeriodOfTwo} *";
                }
            }
        }

        // Number(5).IsRanged(1, 4)

        private string WeekNameShorten(string weekName)
        {
            if (weekName == "Monday") return "MON";
            else if (weekName == "Tuesday") return "TUE";
            else if (weekName == "Wednesday") return "WED";
            else if (weekName == "Thursday") return "THU";
            else if (weekName == "Friday") return "FRI";
            else if (weekName == "Saturday") return "SAT";
            else return "SUN";
        }
    }

    /// <summary>
    /// Form Data structure that binding for windows form.
    /// </summary>
    public class CronFormData
    {
        public int TabIndex { get; set; }
        public int Tab0_Minutes { get; set; }

        public int Tab1_SelectedIndex { get; set; }
        public int Tab1_Hours { get; set; }
        public string Tab1_StartHH { get; set; }
        public string Tab1_StartMM { get; set; }

        public int Tab2_SelectedIndex { get; set; }
        public int Tab2_Days { get; set; }
        public string Tab2_StartHH { get; set; }
        public string Tab2_StartMM { get; set; }

        public int Tab3_SelectedIndex { get; set; }
        public bool Tab3_Monday { get; set; }
        public bool Tab3_Tuesday { get; set; }
        public bool Tab3_Wednesday { get; set; }
        public bool Tab3_Thursday { get; set; }
        public bool Tab3_Fridday { get; set; }
        public bool Tab3_Saturday { get; set; }
        public bool Tab3_Sunday { get; set; }
        public string Tab3_StartHH { get; set; }
        public string Tab3_StartMM { get; set; }
        public int Tab4_SelectedIndex { get; set; }
        public int Tab4_Value1_1 { get; set; }
        public int Tab4_Value1_2 { get; set; }
        public int Tab4_Value2_1 { get; set; }
        public int Tab4_Value2_2 { get; set; }
        public int Tab4_Value2_3 { get; set; }
        public string Tab4_StartHH { get; set; }
        public string Tab4_StartMM { get; set; }
        public int Tab5_SelectedIndex { get; set; }
        public int Tab5_Value1_1 { get; set; }
        public int Tab5_Value1_2 { get; set; }
        public int Tab5_Value2_1 { get; set; }
        public int Tab5_Value2_2 { get; set; }
        public int Tab5_Value2_3 { get; set; }
        public string Tab5_StartHH { get; set; }
        public string Tab5_StartMM { get; set; }
    }
}
