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
using MeterTest.Source.Test;
using MeterTest.Source.Emu;
using MeterTest.Source.WinowsForm;
using Newtonsoft.Json;
using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Annotations;

namespace MeterTest.Source.WinowsForm
{
    public partial class FormMain : Form, IAdjMeterLogger, IFreezeLog
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
        private int cycleSwith = 0;
        private Dlt645Password password = null;
        private Dlt645OperatorCode operatorCode = null;
        private FreezeLineChart freezeLineChart = null;
        private DateTimeAxis    dateTimeAxis    = null; // y轴
        private LinearAxis      dataAxis = null; // x轴
        private FreezeDataRead freezeDataRead;
        static public DataIdDbContext DataIdDb = new DataIdDbContext();
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

            /* 第一次打开时，加载的折线图 */
            comboBoxFreezeSelect.Text = comboBoxFreezeSelect.Items[0].ToString();
            dateTimePickerFreezeReadStart.Value = DateTime.Now.AddHours(-1);
            
            PlotModel model = new PlotModel { Title = "冻结数据" };
            dateTimeAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom, 
                Minimum = DateTimeAxis.ToDouble(dateTimePickerFreezeReadStart.Value), 
                Maximum = DateTimeAxis.ToDouble(dateTimePickerFreezeReadEnd.Value), 
                StringFormat = "M/d HH:mm",
                IsZoomEnabled = false,
                IsPanEnabled =  false,  
            };
            dataAxis = FreezeLineChart.GetLinearAxis(comboBoxFreezeSelect.Text);
            freezeLineChart = new FreezeLineChart(model, 
                                                  dateTimeAxis,
                                                  dataAxis,
                                                  comboBoxFreezeSelect.Text);
            this.plotViewFreeze.Model = model;
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
            }
        }

        private void 取消选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewReadList.SelectedRows.Count; i++)
            {
                dataGridViewReadList.Rows[dataGridViewReadList.SelectedRows[i].Index].Cells[0].Value = false;
            }
        }

        private void 选择所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                dataGridViewReadList.Rows[i].Cells[0].Value = true;
            }
        }

        private void 取消所有选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                dataGridViewReadList.Rows[i].Cells[0].Value = false;
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
        private void CloseLock()
        {
            synchronizationContext.Post(SetOptLock, false); /* 关闭锁 */
        }
        private void DataIdListDisplayAll()
        {
            dataGridViewReadList.Rows.Clear();
            DataId[] dataIdArray = DataIdDb.DataIds.ToArray();
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
        
        private void ReadOptUiUpdate(Object obj)
        {
            Dictionary<String, CommResult> dic = (Dictionary<String, CommResult>)obj;
            
            CommResult rst;
            if(dic.Count > 0)
            {
                for (int i = 0; i < dic.Count; i++)
                {
                    if(dic.TryGetValue("read", out rst))
                    {
                        ReadDisplay(rst);
                    }
                    if(dic.TryGetValue("reading", out rst))
                    {
                        int index = 0;
                        for (int j = 0; j < dataGridViewReadList.RowCount; j++)
                        {
                            if(dataGridViewReadList.Rows[j].Cells[2].Value.ToString() == rst.DataId.Id.ToString("X8"))
                            {
                                index = j;
                                break;
                            }
                        }
                        dataGridViewReadList.Rows[index].Cells[7].Value = null;
                        dataGridViewReadList.CurrentCell = dataGridViewReadList.Rows[index].Cells[7];
                        toolStripStatusLabelStatus.Text = "正在读取数据标识：" + rst.DataId.Id.ToString("X8") + " ...";
                    }
                    if(dic.TryGetValue("Read Cycle", out rst))
                    {
                        ReadDisplay(rst);
                    }
                }
            }
        }
        private void ReadDisplay(CommResult rst) 
        {
            string displayStr = null;
            int index = 0;
            for (int j = 0; j < dataGridViewReadList.RowCount; j++)
            {
                if(dataGridViewReadList.Rows[j].Cells[2].Value.ToString() == rst.DataId.Id.ToString("X8"))
                {
                    index = j;
                    break;
                }
            }
            if(rst.Result)
            {
                displayStr = rst.DataId.GetDataString(rst.DataBytes);
                dataGridViewReadList.Rows[index].Cells[7].Style.BackColor = Color.White;
            }
            else
            {
                displayStr = rst.Error.ToString();
                dataGridViewReadList.Rows[index].Cells[7].Style.BackColor = Color.Red;
            }
            dataGridViewReadList.Rows[index].Cells[7].Value = displayStr;
        }
        private void ReadOnce(Object obj)
        {
            List<DataId> dataIdList = (List<DataId>)obj;
            CommResult rst = null;
            Interlocked.Exchange(ref cycleSwith, 10);
            foreach (var item in dataIdList)
            {
                try
                {
                    rst = new CommResult();
                    Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                    rst.DataId = item;
                    dic.Add("reading", rst);
                    synchronizationContext.Post(ReadOptUiUpdate, dic);
                    rst.DataBytes = client.Read(meterAddress, item);
                    rst.Result = true;
                }
                catch (ClientException e)
                {
                    rst.Error = e.Message;
                }
                catch (TimeoutException)
                {
                    rst.Error = "响应超时";
                    //break;
                }
                catch(Exception e)
                {
                    MessageBox.Show("未知错误" + e.Message, "MeterTest",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rst.Error = "未知错误";
                    break;
                }
                finally
                {
                    Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                    dic.Add("read", rst);
                    synchronizationContext.Post(ReadOptUiUpdate, dic);
                    Thread.Sleep(500);
                }
                if(cycleSwith == 0)
                {
                    break;
                }
            }
            CloseLock(); /* 关闭锁 */
        }
        private void ReadCycle(Object obj)
        {
            List<DataId> dataIdList = (List<DataId>)obj;
            CommResult rst = null;
            // Interlocked.Increment(ref cycleSwith);
            Interlocked.Exchange(ref cycleSwith, 10);
            // cycleSwith = true;
            int cycleReadErrorCnt = 0;
            int cycleReadOkCnt = 0;
            int timeOutCnt = 0;
            while(cycleSwith != 0)
            {
                for (int i = 0; i < dataIdList.Count; i++)
                {
                    try
                    {
                        rst = new CommResult();
                        DataId item = dataIdList[i];
                        rst.DataId = item;
                        Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                        dic.Add("reading", rst);
                        synchronizationContext.Post(ReadOptUiUpdate, dic);
                        rst.DataBytes = client.Read(meterAddress, item);
                        rst.Result = true;
                        cycleReadOkCnt++;
                    }
                    catch (ClientException e)
                    {
                        rst.Error = e.Message;
                        cycleReadErrorCnt++;
                    }
                    catch (TimeoutException)
                    {
                        rst.Error = "响应超时";
                        timeOutCnt++;
                        Interlocked.Exchange(ref cycleSwith, 0);
                        break;
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("未知错误" + e.Message, "MeterTest",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rst.Error = "未知错误";
                        Interlocked.Exchange(ref cycleSwith, 0);
                        break;
                    }
                    finally
                    {
                        Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                        dic.Add("Read Cycle", rst);
                        synchronizationContext.Post(ReadOptUiUpdate, dic);
                        Thread.Sleep(500);
                    }
                    if(cycleSwith == 0)
                    {
                        break;
                    }
                }
            }
            MessageBox.Show("响应超时次数: " + timeOutCnt.ToString() + "\n"
                           + "错误响应次数: "+ cycleReadErrorCnt.ToString() + "\n"
                           + "正常响应次数: "+ cycleReadOkCnt.ToString() + "\n", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CloseLock(); /* 关闭锁 */
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
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                if((dataGridViewReadList.Rows[i].Cells[0].Value != null) 
                && (bool)dataGridViewReadList.Rows[i].Cells[0].Value == true)
                {
                    dataId = DataIdDb.DataIds.ToArray()[Convert.ToInt32(dataGridViewReadList.Rows[i].Cells[1].Value)];  
                    dataIdList.Add(dataId);
                }
            }
            Thread readOnceThr = new Thread(ReadOnce);
            readOnceThr.IsBackground = true;
            readOnceThr.Start(dataIdList);
        }
        private void buttonReadClyce_Click(object sender, EventArgs e)
        {
            if(optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            optLock = true;
            optMessage = "正在循环读取";
            DataId dataId = null;
            List<DataId> dataIdList = new List<DataId>();
            for (int i = 0; i < dataGridViewReadList.Rows.Count; i++)
            {
                if((dataGridViewReadList.Rows[i].Cells[0].Value != null) 
                && (bool)dataGridViewReadList.Rows[i].Cells[0].Value == true)
                {
                    dataId = DataIdDb.DataIds.ToArray()[Convert.ToInt32(dataGridViewReadList.Rows[i].Cells[1].Value)];  
                    dataIdList.Add(dataId);
                }
            }
            Thread readCycleThr = new Thread(ReadCycle);
            readCycleThr.IsBackground = true;
            readCycleThr.Start(dataIdList);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Interlocked.Exchange(ref cycleSwith, 0);
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            dataGridViewReadList.Left = tabControlMainForm.Left;
            dataGridViewReadList.Top = tabControlMainForm.Top;
            dataGridViewReadList.Width = (int)(tabControlMainForm.Width * 0.96);
            buttonReadOne.Left = tabControlMainForm.Left + 10;
            buttonReadClyce.Left = tabControlMainForm.Left + 10 + tabControlMainForm.Width / 4;
            buttonStop.Left = tabControlMainForm.Left + 10 + tabControlMainForm.Width / 4 * 2;
            if (tabControlMainForm.Height > 150)
            {
                dataGridViewReadList.Height = tabControlMainForm.Height - 150;
                buttonReadOne.Top = tabControlMainForm.Top + tabControlMainForm.Height - 135;
                buttonReadClyce.Top = tabControlMainForm.Top + tabControlMainForm.Height - 135;
                buttonStop.Top = tabControlMainForm.Top + tabControlMainForm.Height - 135;
            }
            else
            {
                dataGridViewReadList.Height = 10;
            }
            // size.Height = (int)(tabControlMainForm.Size.Height * 0.9);
            // Point point1 = new Point(21, dataGridViewReadList.Location.Y + tabControlMainForm.Size.Height - 10);
            // this.buttonReadOne.Location = point1;
            // Point point2 = new Point(21 + this.Size.Width / 4, dataGridViewReadList.Location.Y + tabControlMainForm.Size.Height - 10);
            // buttonReadClyce.Location = point2;
            // Point point3 = new Point(21 + this.Size.Width / 2, dataGridViewReadList.Location.Y + tabControlMainForm.Size.Height - 10);
            // buttonStop.Location = point3;
        }
        private void DataGridViewWriteDisplayUpdate()
        {
            DataId[] dataIdArray = DataIdDb.DataIds.ToArray();
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
            DataId dataId = DataIdDb.DataIds.ToArray()[Convert.ToInt32(dataGridViewWrite.Rows[dataGridViewWrite.CurrentCell.RowIndex].Cells[1].Value)];
            FormWrite form = new FormWrite(dataId);
            form.StartPosition = FormStartPosition.CenterParent;
            if(form.ShowDialog() == DialogResult.OK)
            {
                dataGridViewWrite.Rows[dataGridViewWrite.CurrentCell.RowIndex].Cells[7].Value = form.DataString;
            }
        }

        

        private void ReadFreezeBlockData()
        {
            FreezeDataRead freezeDataTest = new FreezeDataRead(this.client);
            List<FreezeData> freezeDataList = new List<FreezeData>();
            try
            {
                int cnt = freezeDataTest.GetFreezeCnt();
                cnt = cnt > FreezeDataRead.MAX_FREEZE_CNT? FreezeDataRead.MAX_FREEZE_CNT : cnt;
                synchronizationContext.Post(ReadFreezeDataProgramBarStart, cnt);
                for (int i = 1; i <= cnt; i++)
                {
                    byte[] rst = null;
                    try
                    {
                        rst = freezeDataTest.ReadBlock(i);
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.ToString());
                        // throw;
                    }
                    if(rst != null)
                    {
                        FreezeData data = freezeDataTest.FreezeDataConvert(rst);
                        freezeDataList.Add(data);
                        synchronizationContext.Post(ReadFreezeDataProgramBar, i);
                    }
                }
                freezeDataList.Sort();
                freezeDataTest.SaveFreezeData(".\\source\\Test\\冻结数据.xlsx", freezeDataList);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString());
                // throw;
            }
        }
        private void ReadFreezeDataProgramBar(Object obj)
        {
            // int per = (int)obj;
            // progressBar1.Value = per;
        }
        private void ReadFreezeDataProgramBarStart(Object obj)
        {
            // int per = (int)obj;
            // progressBar1.Maximum = per;
        }

        private void buttonStartAdjMeter_Click(object sender, EventArgs e)
        {
            V9203 v9203 = new V9203(this.client, this);
            Thread th = new Thread(v9203.AdjMeter);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if(!endTest)
            {
                endTest = true;
                Thread th = new Thread(V9203AdjTest);
                th.IsBackground = true;
                th.Start();
                button4.Text = "结束测试";
            }
            else
            {
                endTest = false;
                button4.Text = "开始测试";
            }
        }
        bool endTest = false;
        private void V9203AdjTest()
        {
            V9203 v9203 = new V9203(this.client, this);
            int cnt = 0;
            while(endTest)
            {
                cnt ++;
                IAdjMeterLog("第" + cnt + "次测试开始");
                v9203.AdjMeter();
                IAdjMeterLog("第" + cnt + "次测试结束");
                IAdjMeterLog("");
            }
        }

        private void hT7036ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new Ht7036Convert();
            form.StartPosition = FormStartPosition.CenterParent;
            form.Show();
        }

        private void hT7036校表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // FormHt7036Adj form = new FormHt7036Adj(client);
            // this.AddOwnedForm(form);
            // form.StartPosition = FormStartPosition.CenterParent;
            // form.ShowDialog();
            Form form = new FormHt7036Adj(client);
            form.StartPosition = FormStartPosition.CenterParent;
            form.Show();
        }

        private void ReadFreezeDataPhaseChangeProgramBar(Object obj)
        {
            FreezeReadMsg msg = (FreezeReadMsg)obj;
            toolStripStatusLabelFreeze.Text = msg.ToolStripStatusLabel;
            toolStripProgressBarFreezeRead.Value = msg.ProgressBar;
            if(msg.freezeData != null)
            {
                freezeLineChart.DisplayFreezeData(comboBoxFreezeSelect.Text, msg.freezeData);
                plotViewFreeze.Model.InvalidatePlot(true);
            }
        }
        private void buttonFreezeRead_Click(object sender, EventArgs e)
        {
            if(dateTimePickerFreezeReadEnd.Value.Ticks < dateTimePickerFreezeReadStart.Value.Ticks)
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
            DateTime start = new DateTime(dateTimePickerFreezeReadStart.Value.Year, 
                                               dateTimePickerFreezeReadStart.Value.Month, 
                                               dateTimePickerFreezeReadStart.Value.Day, 
                                               dateTimePickerFreezeReadStart.Value.Hour, 
                                               dateTimePickerFreezeReadStart.Value.Minute, 
                                               0);
            DateTime End = new DateTime(dateTimePickerFreezeReadEnd.Value.Year, 
                                             dateTimePickerFreezeReadEnd.Value.Month, 
                                             dateTimePickerFreezeReadEnd.Value.Day, 
                                             dateTimePickerFreezeReadEnd.Value.Hour, 
                                             dateTimePickerFreezeReadEnd.Value.Minute, 
                                             0);
            toolStripProgressBarFreezeRead.Value = toolStripProgressBarFreezeRead.Minimum;
            plotViewFreeze.Model.Series.Clear();  
            freezeLineChart.lineDict.Clear();          
            plotViewFreeze.Model.InvalidatePlot(true);
            freezeDataRead = new FreezeDataRead(client, this, start, End);
            Thread threadFreezeRead = new Thread(freezeDataRead.ReadPhaseChangeFreezeData);
            threadFreezeRead.IsBackground = true;
            threadFreezeRead.Start();
        }
        
        private void comboBoxFreezeSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(plotViewFreeze.Model == null)
            {
                return;
            }
            plotViewFreeze.Model.Axes.Remove(dataAxis);
            dataAxis = FreezeLineChart.GetLinearAxis(comboBoxFreezeSelect.Text);
            freezeLineChart.left = dataAxis;
            freezeLineChart.lineDict.Clear();
            plotViewFreeze.Model.Axes.Add(dataAxis);
            // plotViewFreeze.Model.Title = comboBoxFreezeSelect.Text;
            plotViewFreeze.Model.InvalidatePlot(true);
        }

        private void dateTimePickerFreezeReadStart_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimeAxis != null)
            {
                freezeLineChart.SetBottomMin(dateTimePickerFreezeReadStart.Value);
                plotViewFreeze.Model.InvalidatePlot(true);
            }
        }

        private void dateTimePickerFreezeReadEnd_ValueChanged(object sender, EventArgs e)
        {
            if(dateTimeAxis != null)
            {
                freezeLineChart.SetBottomMax(dateTimePickerFreezeReadEnd.Value);
                plotViewFreeze.Model.InvalidatePlot(true);
            }
        }

        public void SendMsg(FreezeReadMsg msg)
        {
            synchronizationContext.Post(ReadFreezeDataPhaseChangeProgramBar, msg);
        }

        public void End()
        {
            optLock = false;
        }

        private void buttonFreezeReadStop_Click(object sender, EventArgs e)
        {
            if(freezeDataRead != null)
            {
                freezeDataRead.EndFreezeDataRead();
            }
            optLock = false; 
        }
    }
}
