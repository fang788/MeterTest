using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.Source.Config;
using MeterTest.Source.Dlt645;
using MeterTest.Source.SQLite;
using MeterTest.Source.Freeze;
using MeterTest.Source.Emu;
using MeterTest.Source.WindowsForm;
using Newtonsoft.Json;
using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;
using MeterTest.Source.Read;
using MeterTest.Source.SQLite.ParaConfig;
using Microsoft.EntityFrameworkCore;
using MeterTest.Source.Write;
using MeterTest.Source.Device;

namespace MeterTest.Source.WindowsForm
{
    public partial class FormMain : Form, IAdjMeterLogger, IFreezeLog, IReadLog, IParaConfigLog, IDeviceLog
    {
        private FormLogger formLogger = new FormLogger();
        private SerialPort serialPort;
        private Dlt645Transport transport;
        private ConsoleLogger consoleLogger;
        private Dlt645Client client;
        private MeterAddress meterAddress;
        private SynchronizationContext synchronizationContext = null;
        private bool optLock = false; /* 操作锁，true：正在进行某项操作 */
        private String optMessage = null;
        private Dlt645Password password = null;
        private Dlt645OperatorCode operatorCode = null;
        //private FreezeLineChart freezeLineChart = null;
        //private DateTimeAxis    dateTimeAxis    = null; // y轴
        //private LinearAxis      dataAxis = null; // x轴
        //private FreezeDataRead freezeDataRead;
        private ReadData readData;
        private string  paraConfigTableName;
        // static public DataIdDbContext DataIdDb = new DataIdDbContext();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(!RegistrationCode.LicFileChk())
            {
                this.Text += " 未激活软件";
                return;
            }
            ParaUpdate();
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
            //  column.HeaderText = ColumnName.OutOfOffice.ToString();
            // column.Name = ColumnName.OutOfOffice.ToString();
            // column.AutoSizeMode = 
            //     DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkbox.FlatStyle = FlatStyle.Standard;
            // checkbox.ThreeState = true;
            checkbox.CellTemplate = new DataGridViewCheckBoxCell();
            checkbox.CellTemplate.Value = false;
            // checkbox.CellTemplate.Style.BackColor = Color.Beige;
            //添加的checkbox在dgv第一列
            this.dataGridViewReadList.Columns.Insert(0, checkbox);
            dataGridViewReadList.Columns.Add("No", "编号");
            // dataGridViewDataIdList.Columns[0].Width = 80;
            dataGridViewReadList.Columns.Add("Id", "数据标识");
            dataGridViewReadList.Columns.Add("Name", "数据项名称");
            dataGridViewReadList.Columns.Add("Format", "数据格式");
            dataGridViewReadList.Columns.Add("DataBytes", "数据长度（字节）");
            dataGridViewReadList.Columns.Add("Unit", "单位");
            dataGridViewReadList.Columns.Add("Rst", "结果");
            
            dataGridViewReadList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewParaConfig.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            checkbox = new DataGridViewCheckBoxColumn();
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
            dataGridViewWrite.Columns.Insert(0, checkbox);
            dataGridViewWrite.Columns.Add("No", "编号");
            // dataGridViewDataIdList.Columns[0].Width = 80;
            dataGridViewWrite.Columns.Add("Id", "数据标识");
            dataGridViewWrite.Columns.Add("Name", "数据项名称");
            dataGridViewWrite.Columns.Add("Format", "数据格式");
            dataGridViewWrite.Columns.Add("DataBytes", "数据长度（字节）");
            dataGridViewWrite.Columns.Add("Unit", "单位");
            dataGridViewWrite.Columns.Add("WriteData", "写入数据");
            dataGridViewWrite.Columns.Add("Rst", "结果");
            
            dataGridViewWrite.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataIdListDisplayAll();
            DataGridViewWriteDisplayUpdate();
            synchronizationContext = SynchronizationContext.Current;

            using var context = new ParaConfigTableDbContext();
            if(context.ParaConfigTables.Count() > 0)
            {
                ParaConfigTable table = context.ParaConfigTables.Include(e => e.DataIds).AsNoTracking().ToArray().First();
                ParaConfigTableDisplay(table);
                paraConfigTableName = table.Name;
            }
            else
            {
                toolStripStatusLabelParaConfigTable.Text = "当前项目：无";
            }
        }

        private void ParaUpdate()
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
            transport = new Dlt645Transport(serialPort, consoleLogger);
            client = new Dlt645Client(transport);
            meterAddress = new MeterAddress(opt.MeterAddress);
            password = new Dlt645Password(opt.Authority, Convert.ToInt32(opt.Password, 16));
            operatorCode = new Dlt645OperatorCode(opt.OperatorCode);
        }

        private void 关于MeterTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVersion form = new FormVersion();

            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }
        
        private void 激活ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLicense form = new FormLicense();

            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions form = new FormOptions();

            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            if(form.ShowDialog() == DialogResult.OK)
            {
                ParaUpdate();
            }
        }

        private void 日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formLogger == null)
            {
                formLogger = new FormLogger();
            }
            else if(formLogger.IsDisposed)
            {
                formLogger = new FormLogger();
            }
            if(formLogger.Visible == false)
            {
                formLogger.StartPosition = FormStartPosition.CenterParent;
                formLogger.Show();
            }
        }

        private void 管理数据标识表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataIdListForm form = new DataIdListForm();
            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            if(form.IsChg)
            {
                DataIdListDisplayAll();
            }
        }
        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewReadList.SelectedRows.Count; i++)
            {
                dataGridViewReadList.Rows[dataGridViewReadList.SelectedRows[i].Index].Cells[0].Value = true;
                ((DataGridViewCheckBoxCell)dataGridViewReadList.Rows[dataGridViewReadList.SelectedRows[i].Index].Cells[0]).EditingCellFormattedValue = true;
            }
        }

        private void 取消选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewReadList.SelectedRows.Count; i++)
            {
                dataGridViewReadList.Rows[dataGridViewReadList.SelectedRows[i].Index].Cells[0].Value = false;
                ((DataGridViewCheckBoxCell)dataGridViewReadList.Rows[dataGridViewReadList.SelectedRows[i].Index].Cells[0]).EditingCellFormattedValue = false;
            }
        }

        private void 选择所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                dataGridViewReadList.Rows[i].Cells[0].Value = true;
                ((DataGridViewCheckBoxCell)dataGridViewReadList.Rows[i].Cells[0]).EditingCellFormattedValue = true;
            }
        }

        private void 取消所有选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                dataGridViewReadList.Rows[i].Cells[0].Value = false;
                ((DataGridViewCheckBoxCell)dataGridViewReadList.Rows[i].Cells[0]).EditingCellFormattedValue = false;
            }
        }
        private void 清除所有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                dataGridViewReadList.Rows[i].Cells[7].Value = null;
            }
        }
        private void SetOptLock(Object value)
        {
            this.optLock = (bool)value;
        }
        public void CloseLock()
        {
            synchronizationContext.Post(SetOptLock, false); /* 关闭锁 */
        }
        private void DataIdListDisplayAll()
        {
            dataGridViewReadList.Rows.Clear();
            using var context = new DataIdDbContext();
            DataId[] dataIdArray = context.DataIds.ToArray();
            for (int i = 0; i < dataIdArray.Length; i++)
            {
                if(dataIdArray[i].IsReadable)
                {
                    int index = dataGridViewReadList.Rows.Add();
                    dataGridViewReadList.Rows[index].Cells[1].Value = i;
                    dataGridViewReadList.Rows[index].Cells[2].Value = dataIdArray[i].Id.ToString("X8");
                    dataGridViewReadList.Rows[index].Cells[3].Value = dataIdArray[i].Name;
                    dataGridViewReadList.Rows[index].Cells[4].Value = dataIdArray[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
                    dataGridViewReadList.Rows[index].Cells[5].Value = dataIdArray[i].DataBytes;
                    dataGridViewReadList.Rows[index].Cells[6].Value = dataIdArray[i].Unit;
                }
            }
        }
        private void ReadDataIdEndDisplay(Object obj) 
        {
            ReadMsg msg = (ReadMsg)obj;
            string displayStr = null;
            int index = 0;
            for (int j = 0; j < dataGridViewReadList.RowCount; j++)
            {
                if(dataGridViewReadList.Rows[j].Cells[2].Value.ToString() == msg.DataId.Id.ToString("X8"))
                {
                    index = j;
                    break;
                }
            }
            dataGridViewReadList.CurrentCell = dataGridViewReadList.Rows[index].Cells[7];
            if(msg.IsSuccess)
            {
                displayStr = msg.DataId.GetDataString(msg.DataId.DataArray);
                dataGridViewReadList.Rows[index].Cells[7].Style.BackColor = Color.White;
            }
            else
            {
                displayStr = msg.ErrorLog.ToString();
                dataGridViewReadList.Rows[index].Cells[7].Style.BackColor = Color.Red;
            }
            dataGridViewReadList.Rows[index].Cells[7].Value = displayStr;
        }
        private void ReadingDataIdDisplay(Object obj) 
        {
            DataId dataId = (DataId)obj;
            for (int j = 0; j < dataGridViewReadList.RowCount; j++)
            {
                if(dataGridViewReadList.Rows[j].Cells[2].Value.ToString() == dataId.Id.ToString("X8"))
                {
                    dataGridViewReadList.CurrentCell = dataGridViewReadList.Rows[j].Cells[7];
                    dataGridViewReadList.Rows[j].Cells[7].Value = null;
                    toolStripStatusLabelStatus.Text = "正在读取数据标识：" + dataId.Id.ToString("X8") + " ...";
                    break;
                }
            }
        }
        private void ReadEndDisplay(Object obj)
        {
            toolStripStatusLabelStatus.Text = obj.ToString();
        }
        public void SendMsg(ReadMsg msg)
        {
            synchronizationContext.Post(ReadDataIdEndDisplay, msg);
        }
        public void SendReadDataId(DataId dataId)
        {
            synchronizationContext.Post(ReadingDataIdDisplay, dataId);
        }

        public void ReadEnd()
        {
            synchronizationContext.Post(SetOptLock, false); /* 关闭锁 */
            synchronizationContext.Post(ReadEndDisplay, "读取完成");
        }
        private void buttonReadOne_Click(object sender, EventArgs e)
        {
            // List<DataId> selectList = new List<DataId>();
            if(optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            optLock = true;
            optMessage = "正在单次读取";
            DataId dataId = null;
            List<DataId> dataIdList = new List<DataId>();
            using var context = new DataIdDbContext();
            DataId[] dataIdArray = context.DataIds.ToArray();
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                if((dataGridViewReadList.Rows[i].Cells[0].Value != null) 
                && (bool)dataGridViewReadList.Rows[i].Cells[0].Value == true)
                {
                    dataId = dataIdArray[Convert.ToInt32(dataGridViewReadList.Rows[i].Cells[1].Value)];  
                    dataIdList.Add(dataId);
                }
            }
            readData = new ReadData(this.client, this, meterAddress);
            Thread readOnceThr = new Thread(readData.ReadOnce);
            readOnceThr.IsBackground = true;
            readOnceThr.Start(dataIdList);
        }
        
        private void DataGridViewWriteDisplayUpdate()
        {
            using var context = new DataIdDbContext();
            DataId[] dataIdArray = context.DataIds.ToArray();
            for (int i = 0; i < dataIdArray.Length; i++)
            {
                if(dataIdArray[i].IsWritable)
                {
                    int index = dataGridViewWrite.Rows.Add();
                    dataGridViewWrite.Rows[index].Cells[1].Value = i;
                    dataGridViewWrite.Rows[index].Cells[2].Value = dataIdArray[i].Id.ToString("X8");
                    dataGridViewWrite.Rows[index].Cells[3].Value = dataIdArray[i].Name;
                    dataGridViewWrite.Rows[index].Cells[4].Value = dataIdArray[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
                    dataGridViewWrite.Rows[index].Cells[5].Value = dataIdArray[i].DataBytes;
                    dataGridViewWrite.Rows[index].Cells[6].Value = dataIdArray[i].Unit;
                }
            }
        }

        private void dataGridViewWrite_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using var context = new DataIdDbContext();
            DataId[] dataIdArray = context.DataIds.ToArray();
            DataId dataId = dataIdArray[Convert.ToInt32(dataGridViewWrite.Rows[dataGridViewWrite.CurrentCell.RowIndex].Cells[1].Value)];
            FormWrite form = new FormWrite(dataId);
            form.StartPosition = FormStartPosition.CenterParent;
            if(form.ShowDialog() == DialogResult.OK)
            {
                dataGridViewWrite.Rows[dataGridViewWrite.CurrentCell.RowIndex].Cells[7].Value = form.DataString;
            }
        }

        private void buttonStartAdjMeter_Click(object sender, EventArgs e)
        {
            if(optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            optLock = true;
            optMessage = "正在校表。。。";
            if(!comboBoxTypeSelect.Items.Contains(comboBoxTypeSelect.Text))
            {
                richTextBoxAdjMeterStatus.AppendText("未选择校表方案\n");
                richTextBoxAdjMeterStatus.ScrollToCaret();
                optLock = false;
                return;
            }
            EmuAdj emuAdj = null;
            if(comboBoxTypeSelect.Text == "相变-HT7036")
            {
                emuAdj = new Ht7036(this.client, this);
            }
            else if(comboBoxTypeSelect.Text == "II型终端-V9203")
            {
                emuAdj = new V9203(this.client, this);
            }
            else if(comboBoxTypeSelect.Text == "相变-HT7022E")
            {
                emuAdj = new Ht7022e(this.client, this);
            }
            else
            {
                richTextBoxAdjMeterStatus.AppendText("校表方案错误\n");
                richTextBoxAdjMeterStatus.ScrollToCaret();
                optLock = false;
                return;
            }

            Thread th = new Thread(emuAdj.AdjMeter);
            th.IsBackground = true;
            th.Start();
        }
        private void UpdateAdjMeterStatus(object status)
        {
            string s = status.ToString() + "\n";
            richTextBoxAdjMeterStatus.AppendText(s);
            richTextBoxAdjMeterStatus.ScrollToCaret();
        }

        public void IAdjMeterLog(string message)
        {
            synchronizationContext.Post(UpdateAdjMeterStatus, message);
        }
        private void ReadFreezeDataPhaseChangeProgramBar(Object obj)
        {
            FreezeReadMsg msg = (FreezeReadMsg)obj;
            toolStripStatusLabelFreeze.Text = msg.ToolStripStatusLabel;
            toolStripProgressBarFreezeRead.Value = msg.ProgressBar;
        }
        FreezeDataFactory factory = null;
        private void buttonFreezeRead_Click(object sender, EventArgs e)
        {
            if(buttonFreezeRead.Text == "读取")
            {
                if((comboBoxFreezeMethon.Text == "时间点")
                && (dateTimePickerFreezeReadEnd.Value.Ticks < dateTimePickerFreezeReadStart.Value.Ticks))
                {
                    MessageBox.Show("开始时间：" + dateTimePickerFreezeReadStart.Value.ToString("yy-MM-dd HH:mm") + 
                    "，早于结束时间：" + dateTimePickerFreezeReadEnd.Value.ToString("yy-MM-dd HH:mm"), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(optLock)
                {
                    MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }            
                optLock = true;
                optMessage = "正在读取冻结数据";
                toolStripProgressBarFreezeRead.Value = toolStripProgressBarFreezeRead.Minimum;
                factory = new FreezeDataFactory(comboBoxProjectSelect.Text,
                                                comboBoxFreezeMethon.Text,
                                                dateTimePickerFreezeReadStart.Value,
                                                dateTimePickerFreezeReadEnd.Value,
                                                (int)numericUpDownFreezeTime.Value,
                                                Convert.ToInt32(numericUpDownFreezeCnt.Text),
                                                Convert.ToInt32(comboBoxFreezeBlkNo.Text),
                                                this,
                                                client,
                                                meterAddress);

                Thread threadFreezeRead = new Thread(factory.GetFreezeDataList);
                threadFreezeRead.IsBackground = true;
                threadFreezeRead.Start();
                buttonFreezeRead.Text = "停止";
                toolStripStatusLabelFreezeProject.Text = "当前项目：" + comboBoxProjectSelect.Text;
            }
            else if(buttonFreezeRead.Text == "停止")
            {
                if(factory != null)
                {
                    factory.GetFreezeDataListStop();
                }
                optLock = false; 
                buttonFreezeRead.Text = "读取";
            }
        }

        public void SendMsg(FreezeReadMsg msg)
        {
            synchronizationContext.Post(ReadFreezeDataPhaseChangeProgramBar, (object)msg);
        }

        public void End()
        {
            optLock = false;
        }

       
        private void 管理参数配置表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParaConfigManageForm form = new ParaConfigManageForm();
            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }
        private void ParaConfigTableDisplay(ParaConfigTable table)
        {
            toolStripStatusLabelParaConfigTable.Text = "当前项目: "+ table.Name;
            if(dataGridViewParaConfig.Columns.Count == 0)
            {
                dataGridViewParaConfig.Columns.Add("No", "编号");
                dataGridViewParaConfig.Columns.Add("Id", "标识");
                dataGridViewParaConfig.Columns.Add("Name", "名称");
                dataGridViewParaConfig.Columns.Add("Format", "格式");
                dataGridViewParaConfig.Columns.Add("DataBytes", "长度");
                dataGridViewParaConfig.Columns.Add("Unit", "单位");
                dataGridViewParaConfig.Columns.Add("data", "数据");
                 //为dgv增加复选框列
                DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
                checkbox.HeaderText = "自动加一";
                checkbox.Name = "IsChecked";
                checkbox.TrueValue = true;
                checkbox.FalseValue = false;
                checkbox.DataPropertyName = "IsChecked";
                dataGridViewParaConfig.Columns.Add(checkbox);
                dataGridViewParaConfig.Columns.Add("Rst", "编程结果");
                dataGridViewParaConfig.Columns.Add("Rst", "比对结果");
            }
            if(table.DataIds != null)
            {
                int no = 0;
                foreach (var item in table.DataIds)
                {
                    int index = dataGridViewParaConfig.Rows.Add();
                    dataGridViewParaConfig.Rows[index].Cells[0].Value = no;
                    dataGridViewParaConfig.Rows[index].Cells[1].Value = item.Id.ToString("X8");
                    dataGridViewParaConfig.Rows[index].Cells[2].Value = item.Name;
                    dataGridViewParaConfig.Rows[index].Cells[3].Value = item.Format;// == null? null : (dataIdArray[i].Format.ToString());
                    dataGridViewParaConfig.Rows[index].Cells[4].Value = item.DataBytes;
                    dataGridViewParaConfig.Rows[index].Cells[5].Value = item.Unit;
                    dataGridViewParaConfig.Rows[index].Cells[6].Value = item.GetDataString(item.DataArray);
                    if(!ParaConfigTable.HasCommAddrAutoAddList.Contains(item))
                    {
                        dataGridViewParaConfig.Rows[index].Cells[7].ReadOnly = true;;
                    }
                    no++;
                }
            }
        }

        private ParaConfig paraConfig;
        private void 编程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(paraConfigTableName == null)
            {
                toolStripStatusLabelParaConfig.Text = "错误：参数配置表为空";
                return;
            }
            if(optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            optLock = true;
            optMessage = "正在参数配置";
            paraConfig = new ParaConfig(client, meterAddress, password, operatorCode, this);
            
            using var context = new ParaConfigTableDbContext();

            for (int j = 1; j < dataGridViewParaConfig.RowCount; j++)
            {
                if((dataGridViewParaConfig.Rows[j].Cells[7].Value != null)
                && ((bool)dataGridViewParaConfig.Rows[j].Cells[7].Value == true))
                {
                    uint id = Convert.ToUInt32(dataGridViewParaConfig.Rows[j].Cells[1].Value.ToString(), 16);
                    ulong tmp = Convert.ToUInt64(dataGridViewParaConfig.Rows[j].Cells[6].Value.ToString());
                    tmp++;
                    dataGridViewParaConfig.Rows[j].Cells[6].Value = tmp.ToString();
                    byte[] arrayTmp = new byte[6];

                    string sTmp = tmp.ToString();
                    int lenTmp = sTmp.Length;
                    for (int i = 0; i < arrayTmp.Length; i++)
                    {
                        arrayTmp[i] = Convert.ToByte(sTmp.Substring(lenTmp - 2 - i * 2, 2), 16);
                    }

                    ParaConfigDataId dataId = context.DataIds.Single(e => e.Id == id);
                    context.Remove(dataId);
                    context.SaveChanges();
                    dataId.DataArray = arrayTmp;
                    context.DataIds.Add(dataId);
                    context.SaveChanges();
                }
            }

            ParaConfigTable paraConfigTable = context.ParaConfigTables.AsNoTracking().Include(e => e.DataIds).Single(e => e.Name == paraConfigTableName);
            List<DataId> dataIds = new List<DataId>();
            foreach (var item in paraConfigTable.DataIds)
            {
                dataIds.Add((DataId)item);  
            }
            Thread thread = new Thread(paraConfig.ParaSet);
            thread.IsBackground = true;
            thread.Start(dataIds);
        }

        private void 比对ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(paraConfigTableName == null)
            {
                toolStripStatusLabelParaConfig.Text = "错误：参数配置表为空";
                return;
            }
            if(optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            optLock = true;
            optMessage = "正在参数比对";
            paraConfig = new ParaConfig(client, meterAddress, password, operatorCode, this);
            
            using var context = new ParaConfigTableDbContext();
            ParaConfigTable paraConfigTable = context.ParaConfigTables.Include(e => e.DataIds).AsNoTracking().Single(e => e.Name == paraConfigTableName);
            List<DataId> dataIds = new List<DataId>();
            foreach (var item in paraConfigTable.DataIds)
            {
                dataIds.Add((DataId)item);  
            }

            Thread thread = new Thread(paraConfig.ParaCompare);
            thread.IsBackground = true;
            thread.Start(dataIds);
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(paraConfig != null)
            {
                paraConfig.StopOpt();
                toolStripStatusLabelParaConfig.Text = "已停止";
            }

        }
        private void ToolStripStatusLabelStatusUpdate(Object obj)
        {
            DataId dataId = (DataId)obj;
            toolStripStatusLabelStatus.Text = obj.ToString();
            for (int j = 0; j < dataGridViewParaConfig.RowCount; j++)
            {
                if(dataGridViewParaConfig.Rows[j].Cells[1].Value.ToString() == dataId.Id.ToString("X8"))
                {
                    dataGridViewParaConfig.CurrentCell = dataGridViewParaConfig.Rows[j].Cells[7];
                    if(optMessage == "正在参数比对")
                    {
                        dataGridViewParaConfig.Rows[j].Cells[9].Value = null;
                        toolStripStatusLabelParaConfig.Text = "当前比对的数据标识-<" + dataId.Id.ToString("X8") + ">";
                    }
                    else
                    {
                        dataGridViewParaConfig.Rows[j].Cells[8].Value = null;
                        toolStripStatusLabelParaConfig.Text = "当前配置的数据标识-<" + dataId.Id.ToString("X8") + ">";
                    }
                    break;
                }
            }

        }
        private void ParaConfigRstDisplay(object obj)
        {
            ParaConfigMsg msg = (ParaConfigMsg)obj;
            for (int j = 0; j < dataGridViewParaConfig.RowCount; j++)
            {
                if(dataGridViewParaConfig.Rows[j].Cells[1].Value.ToString() == msg.DataId.Id.ToString("X8"))
                {
                    if(optMessage == "正在参数比对")
                    {
                        if(msg.IsSuccess)
                        {
                            dataGridViewParaConfig.Rows[j].Cells[9].Value = "一致";
                            dataGridViewParaConfig.Rows[j].Cells[9].Style.BackColor = Color.Green;
                        }
                        else
                        {
                            dataGridViewParaConfig.Rows[j].Cells[9].Value = msg.ErrorLog;
                            dataGridViewParaConfig.Rows[j].Cells[9].Style.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        if(msg.IsSuccess)
                        {
                            dataGridViewParaConfig.Rows[j].Cells[8].Value = "成功";
                            dataGridViewParaConfig.Rows[j].Cells[8].Style.BackColor = Color.Green;
                        }
                        else
                        {
                            dataGridViewParaConfig.Rows[j].Cells[8].Value = msg.ErrorLog;
                            dataGridViewParaConfig.Rows[j].Cells[8].Style.BackColor = Color.Red;
                        }
                    }
                    break;
                }
            }
        }
        private void ParaConfigEnd(object obj)
        {
            if(optMessage == "正在参数比对")
            {
                toolStripStatusLabelParaConfig.Text = "参数比对完成";
            }
            else
            {
                toolStripStatusLabelParaConfig.Text = "参数配置完成";
            }
            End();
        }
        public void SendMsg(ParaConfigMsg msg)
        {
            synchronizationContext.Post(ParaConfigRstDisplay, msg);
        }

        public void SendConfigDataId(DataId dataId)
        {
            synchronizationContext.Post(ToolStripStatusLabelStatusUpdate, dataId);
        }
        public void ConfigEnd()
        {
            synchronizationContext.Post(ParaConfigEnd, new object());
        }

        private void contextMenuStripParaConfig_Opening(object sender, CancelEventArgs e)
        {
            using var context = new ParaConfigTableDbContext();
            List<ParaConfigTable> list = context.ParaConfigTables.AsNoTracking().ToList();
            if(list.Count > 0)
            {
                ToolStripMenuItem menu = (ToolStripMenuItem)contextMenuStripParaConfig.Items[contextMenuStripParaConfig.Items.IndexOf(选择参数配置方案ToolStripMenuItem)];
                menu.DropDownItems.Clear();
                foreach (var item in list)
                {
                    ToolStripMenuItem addMenu = new ToolStripMenuItem(item.Name);
                    addMenu.Click += new System.EventHandler(this.addMenu_Click);
                    menu.DropDownItems.Add(addMenu);
                }
            }
        }

        private void addMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            if(paraConfigTableName != menu.Text)
            {
                using var context = new ParaConfigTableDbContext();
                ParaConfigTable table = context.ParaConfigTables.Include(e => e.DataIds).AsNoTracking().Single(e => e.Name == menu.Text);
                ParaConfigTableDisplay(table);
                paraConfigTableName = menu.Text;
            }
        }

        private void comboBoxProjectSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxProjectSelect.Text == "相变") 
            {
                comboBoxFreezeMethon.Items.Clear();
                comboBoxFreezeMethon.Items.Add("时间点");
                comboBoxFreezeMethon.Text = "时间点";
                numericUpDownFreezeCnt.Visible = false;
                labelFreezeCnt.Visible = false;
                dateTimePickerFreezeReadEnd.Visible = true;
                dateTimePickerFreezeReadStart.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                comboBoxFreezeBlkNo.Items.Clear();
                comboBoxFreezeBlkNo.Items.Add(1);

                numericUpDownFreezeTime.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
            }
            else if(comboBoxProjectSelect.Text == "II型终端")
            {
                comboBoxFreezeMethon.Items.Clear();
                comboBoxFreezeMethon.Items.Add("时间点");
                comboBoxFreezeMethon.Items.Add("次数块");
                comboBoxFreezeMethon.Items.Add("次数单个");
                comboBoxFreezeMethon.Text = "时间点";
                numericUpDownFreezeCnt.Visible = false;
                labelFreezeCnt.Visible = false;
                dateTimePickerFreezeReadEnd.Visible = true;
                dateTimePickerFreezeReadStart.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                comboBoxFreezeBlkNo.Items.Clear();
                comboBoxFreezeBlkNo.Items.Add(1);
                comboBoxFreezeBlkNo.Items.Add(2);

                numericUpDownFreezeTime.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
            }
        }

        private void comboBoxFreezeMethon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxFreezeMethon.Text == "时间点") 
            {
                numericUpDownFreezeCnt.Visible = false;
                labelFreezeCnt.Visible = false;
                dateTimePickerFreezeReadEnd.Visible = true;
                dateTimePickerFreezeReadStart.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                numericUpDownFreezeTime.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
            }
            else if(comboBoxFreezeMethon.Text.Contains("次数"))
            {
                dateTimePickerFreezeReadEnd.Visible = false;
                dateTimePickerFreezeReadStart.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                numericUpDownFreezeCnt.Visible = true;
                labelFreezeCnt.Visible = true;

                numericUpDownFreezeTime.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
            }
        }
        private void dataGridViewFreezeDisplay(FreezeDataFactory dataFactory)
        {
            dataGridViewFreeze.Columns.Clear();
            dataGridViewFreeze.Columns.Add("No", "编号");
            dataGridViewFreeze.Columns.Add("Time", "时间");
            for (int i = 0; i < dataFactory.FreezeDataBlocks[0].ItemList.Count; i++)
            {
                dataGridViewFreeze.Columns.Add(i.ToString(), dataFactory.FreezeDataBlocks[0].ItemList[i].Name);
            }
            for (int i = 0; i < dataFactory.FreezeDataBlocks.Count; i++)
            {
                int index = dataGridViewFreeze.Rows.Add();
                dataGridViewFreeze.Rows[index].Cells[0].Value = i;
                dataGridViewFreeze.Rows[index].Cells[1].Value = dataFactory.FreezeDataBlocks[i].time.ToString("yyyy-MM-dd HH:mm:ss");
                for (int j = 0; j < dataFactory.FreezeDataBlocks[i].ItemList.Count; j++)
                {
                    string format = "F" + dataFactory.FreezeDataBlocks[i].ItemList[j].Point.ToString();
                    dataGridViewFreeze.Rows[index].Cells[2 + j].Value = dataFactory.FreezeDataBlocks[i].ItemList[j].Value.ToString(format);
                }
            }
        }
        private void FreezeReadEndDisplay(Object obj)
        {
            buttonFreezeRead.Text = "读取";
            if((factory != null) 
            && (factory.FreezeDataBlocks.Count > 0))
            {
                List<string> leftString = FreezeDataFactory.CreateLiftString(comboBoxProjectSelect.Text);
                dataGridViewFreezeDisplay(factory);
            }
            End();
        }
        public void FreezeReadEnd()
        {
            synchronizationContext.Post(FreezeReadEndDisplay, new object());
        }

        private void toolStripMenuItemOutput_Click(object sender, EventArgs e)
        {
            Stream myStream ;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
        
            saveFileDialog.Filter = "excel文件 (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1 ;
            saveFileDialog.RestoreDirectory = true ;
            saveFileDialog.Title = "请选择冻结数据保存路径";
            saveFileDialog.FileName = toolStripStatusLabelFreezeProject.Text.Split("：")[1] + "_冻结数据_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
        
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if((myStream = saveFileDialog.OpenFile()) != null)
                {
                    FreezeDataFactory.SaveFreezeData(myStream, factory.FreezeDataBlocks);
                    myStream.Close();
                }
            }
        }

        private void 单次读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            optLock = true;
            optMessage = "正在单次读取";
            DataId dataId = null;
            List<DataId> dataIdList = new List<DataId>();
            using var context = new DataIdDbContext();
            DataId[] dataIdArray = context.DataIds.ToArray();
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridViewReadList.Rows[i].Cells[0];
                //if ((dataGridViewReadList.Rows[i].Cells[0].Value != null)
                //&& (bool)dataGridViewReadList.Rows[i].Cells[0].Value == true)
                if ((bool)cell.EditingCellFormattedValue == true)
                {
                    dataId = dataIdArray[Convert.ToInt32(dataGridViewReadList.Rows[i].Cells[1].Value)];
                    dataIdList.Add(dataId);
                }
            }
            readData = new ReadData(this.client, this, meterAddress);
            Thread readOnceThr = new Thread(readData.ReadOnce);
            readOnceThr.IsBackground = true;
            readOnceThr.Start(dataIdList);
        }

        private void 循环读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            optLock = true;
            optMessage = "正在循环读取";
            DataId dataId = null;
            List<DataId> dataIdList = new List<DataId>();
            using var context = new DataIdDbContext();
            DataId[] dataIdArray = context.DataIds.ToArray();
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                if ((dataGridViewReadList.Rows[i].Cells[0].Value != null)
                && (bool)dataGridViewReadList.Rows[i].Cells[0].Value == true)
                {
                    dataId = dataIdArray[Convert.ToInt32(dataGridViewReadList.Rows[i].Cells[1].Value)];
                    dataIdList.Add(dataId);
                }
            }
            readData = new ReadData(this.client, this, meterAddress);
            Thread readCycleThr = new Thread(readData.ReadCycle);
            readCycleThr.IsBackground = true;
            readCycleThr.Start(dataIdList);
        }

        private void 停止ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (readData != null)
            {
                readData.EndRead();
            }
        }

        private void buttonOptExecute_Click(object sender, EventArgs e)
        {
            if((textBoxUpdateSoftware.Text.Trim().Length < 2) && (comboBoxOpt.Text == "升级"))
            {
                MessageBox.Show("请选择升级文件！", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);;
                return;
            }
            if(optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            optLock = true;
            optMessage = "正在执行" + comboBoxOpt.Text + "操作";
            DeviceFactory deviceFactory = null;
            deviceFactory = new DeviceFactory(client, meterAddress, password, operatorCode, this);
            Thread thread = new Thread(deviceFactory.ExcuteSpecialOrderThread);
            string[] arg = new string[3];
            arg[0] = "II型终端";
            arg[1] = comboBoxOpt.Text;
            arg[2] = textBoxUpdateSoftware.Text.Trim();
            thread.IsBackground = true;
            thread.Start((Object)arg);
        }
        private void SpecialOrderDisplay(Object obj)
        {
            toolStripStatusLabelOpt.Text = obj.ToString();
        }
        private void SpecialOrderEnd(object obj)
        {
            End();
        }
        public void SendDeviceLog(string msg)
        {
            synchronizationContext.Post(SpecialOrderDisplay, (Object)msg);
        }

        public void DeviceOptEnd()
        {
            synchronizationContext.Post(SpecialOrderEnd, new Object());
        }

        private void comboBoxOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxOpt.Text == "升级")
            {
                labelUpdateSoftware.Visible = true;
                textBoxUpdateSoftware.Visible = true;
                buttonSelectUpdateSoftware.Visible = true;
            }
            else
            {
                labelUpdateSoftware.Visible = false;
                textBoxUpdateSoftware.Visible = false;
                buttonSelectUpdateSoftware.Visible = false;
            }
        }

        private void buttonSelectUpdateSoftware_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "bin文件(*.bin)|*.bin"; ;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxUpdateSoftware.Text = fileDialog.FileName;
            }
        }
    }
}
