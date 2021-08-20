using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.source.SQLite;
using MeterTest.Source.Config;
using MeterTest.Source.Dlt645;
using Newtonsoft.Json;

namespace MeterTest.Source.WinowsForm
{
    public partial class FormMain : Form
    {
        private FormLogger formLogger = new FormLogger();
        private SerialPort serialPort;
        private Transport transport;
        private ConsoleLogger consoleLogger;
        private Client client;
        static public DataIdDbContext DataIdDb = new DataIdDbContext();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Options opt = null;
            if(File.Exists("Options.txt"))
            {
                opt = JsonConvert.DeserializeObject<Options>(File.ReadAllText("Options.txt"));
            }
            else
            {
                opt = new Options();
            }
            serialPort = new SerialPort(opt.PortName, opt.BaudRate, opt.Parity, opt.DataBits, opt.StopBits);
            serialPort.ReadTimeout = opt.ReadTimeout;
            consoleLogger = new ConsoleLogger(formLogger);
            transport = new Transport(serialPort, consoleLogger);
            client = new Client(transport);
             //为dgv增加复选框列
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            //列显示名称
            checkbox.HeaderText = "选择";
            checkbox.Name = "IsChecked";
            checkbox.TrueValue = true;
            checkbox.FalseValue = false;
            checkbox.DataPropertyName = "IsChecked";
            //列宽
            checkbox.Width = 50;
            //列大小不改变
            checkbox.Resizable = DataGridViewTriState.False;
            //添加的checkbox在dgv第一列
            this.dataGridViewDataIdList.Columns.Insert(0, checkbox);
            dataGridViewDataIdList.Columns.Add("No", "编号");
            dataGridViewDataIdList.Columns.Add("Id", "数据标识");
            dataGridViewDataIdList.Columns.Add("Name", "数据项名称");
            dataGridViewDataIdList.Columns.Add("Format", "数据格式");
            dataGridViewDataIdList.Columns.Add("DataBytes", "数据长度（字节）");
            dataGridViewDataIdList.Columns.Add("Unit", "单位");
            dataGridViewDataIdList.Columns.Add("Rst", "读取值");
            // dataGridViewDataIdList.AutoResizeColumns();
            DataIdListDisplayAll();
        }

        private void 关于MeterTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVersion form = new FormVersion();

            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions form = new FormOptions();

            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void 日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formLogger.Visible)
            {
                formLogger.Show();
            }
            else
            {
                formLogger.StartPosition = FormStartPosition.CenterParent;
                formLogger.Show();
            }
        }

        private void 管理数据标识表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new DataIdListForm();
            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void DataIdListDisplayAll()
        {
            DataId[] dataIdArray = DataIdDb.DataIds.ToArray();
            for (int i = 0; i < dataIdArray.Length; i++)
            {
                if(dataIdArray[i].IsReadable)
                {
                    int index = dataGridViewDataIdList.Rows.Add();
                    dataGridViewDataIdList.Rows[index].Cells[1].Value = i;
                    dataGridViewDataIdList.Rows[index].Cells[2].Value = dataIdArray[i].Id.ToString("X8");
                    dataGridViewDataIdList.Rows[index].Cells[3].Value = dataIdArray[i].Name;
                    dataGridViewDataIdList.Rows[index].Cells[4].Value = dataIdArray[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
                    dataGridViewDataIdList.Rows[index].Cells[5].Value = dataIdArray[i].DataBytes;
                    dataGridViewDataIdList.Rows[index].Cells[6].Value = dataIdArray[i].Unit;
                }
                dataGridViewDataIdList.AutoResizeColumns();
            }
        }

        private void dataGridViewDataIdList_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    ////若行已是选中状态就不再进行设置
                    //if (dataGridView1.Rows[e.RowIndex].Selected == false)
                    //{
                    //    dataGridView1.ClearSelection();
                    //    dataGridView1.Rows[e.RowIndex].Selected = true;
                    //}
                    ////只选中一行时设置活动单元格
                    //if (dataGridView1.SelectedRows.Count == 1)
                    //{
                    //    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    //}
                    ////弹出操作菜单
                    //contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void buttonReadOne_Click(object sender, EventArgs e)
        {
            // List<DataId> selectList = new List<DataId>();
            DataId dataId = null;
            for (int i = 0; i < dataGridViewDataIdList.Rows.Count; i++)
            {
                if((dataGridViewDataIdList.Rows[i].Cells[0].Value != null) 
                && (bool)dataGridViewDataIdList.Rows[i].Cells[0].Value == true)
                {
                    dataId = DataIdDb.DataIds.ToArray()[Convert.ToInt32(dataGridViewDataIdList.Rows[i].Cells[1].Value)];                    
                    dataGridViewDataIdList.Rows[i].Cells[7].Value = client.Read(new MeterAddress(0xAAAAAAAAAAAA), dataId).ToString();
                }
            }
        }
    }
}
