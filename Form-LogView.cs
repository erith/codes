using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridView
{
    public partial class Form1 : Form
    {
        BindingList<LogInfo> logs = new BindingList<LogInfo>();

        public Form1()
        {
            InitializeComponent();

            
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(GetImageColumn(nameof(LogInfo.LEVEL), 25));
            dataGridView1.Columns.Add(GetTextColumn(nameof(LogInfo.DATE), 140));
            dataGridView1.Columns.Add(GetTextColumn(nameof(LogInfo.MESSAGE), isFill: true));
            dataGridView1.Columns.Add(GetTextColumn(nameof(LogInfo.TAG)));
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.DataSource = logs;
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == nameof(LogInfo.LEVEL))
            {
                if (e.Value != null)
                {
                    if ((int)e.Value == 0)
                        e.Value = GridView.Properties.Resources._001_05;
                    else
                        e.Value = GridView.Properties.Resources._001_11;
                }
            }
        }

        private DataGridViewColumn GetImageColumn(string columnName, int width = 100)
        {

            var cell = new DataGridViewImageCell();
            cell.ImageLayout = DataGridViewImageCellLayout.Stretch;
            
            var column = new DataGridViewColumn(new DataGridViewImageCell());
            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.Name = columnName;
            column.DataPropertyName = columnName;
            column.Width = width;
            return column;
        }


        private DataGridViewColumn GetTextColumn(string columnName, int width=100, bool isFill = false)
        {
            var column = new DataGridViewColumn(new DataGridViewTextBoxCell());
            column.Name = columnName;
            column.DataPropertyName = columnName;
            column.Width = width;
            if (isFill) column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.FillWeight = 100;
            return column;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateData();

            logs.RemoveAt(0);
        }

        void GenerateData()
        {
            for(var i = 0; i<100;i++)
            {
                logs.Add(new LogInfo() { LEVEL = 0, DATE = DateTime.Now, MESSAGE = "테스트 메시지 입니다."+ 1, TAG = "RCV2" });
                logs.Add(new LogInfo() { LEVEL = 1, DATE = DateTime.Now, MESSAGE = "테스트 메시지 입니다." + 2, TAG = "RCV2" });
                logs.Add(new LogInfo() { LEVEL = 2, DATE = DateTime.Now, MESSAGE = "테스트 메시지 입니다.", TAG = "RCV2" });
                logs.Add(new LogInfo() { LEVEL = 3, DATE = DateTime.Now, MESSAGE = "테스트 메시지 입니다.", TAG = "RCV2" });
                logs.Add(new LogInfo() { LEVEL = 4, DATE = DateTime.Now, MESSAGE = "테스트 메시지 입니다.", TAG = "RCV2" });
                logs.Add(new LogInfo() { LEVEL = 5, DATE = DateTime.Now, MESSAGE = "테스트 메시지 입니다.", TAG = "RCV2" });
                logs.Add(new LogInfo() { LEVEL = 0, DATE = DateTime.Now, MESSAGE = "테스트 메시지 입니다.", TAG = "RCV2" });
            }
            
        }

    }

    public class LogInfo
    {
        public int LEVEL { get; set; }
        public string TAG { get; set; }
        public string MESSAGE { get; set; }
        public DateTime DATE { get; set; }
    }
}
