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
using MeterTest.source.Config;
using MeterTest.source.dlt645;
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
        private MeterAddress meterAddress;
        private SynchronizationContext synchronizationContext = null;
        private bool optLock = false; /* 操作锁，true：正在进行某项操作 */
        private String optMessage = null;
        private bool cycleSwith = false;
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
            this.dataGridViewDataIdList.Columns.Insert(0, checkbox);
            dataGridViewDataIdList.Columns.Add("No", "编号");
            // dataGridViewDataIdList.Columns[0].Width = 80;
            dataGridViewDataIdList.Columns.Add("Id", "数据标识");
            dataGridViewDataIdList.Columns.Add("Name", "数据项名称");
            dataGridViewDataIdList.Columns.Add("Format", "数据格式");
            dataGridViewDataIdList.Columns.Add("DataBytes", "数据长度（字节）");
            dataGridViewDataIdList.Columns.Add("Unit", "单位");
            dataGridViewDataIdList.Columns.Add("Rst", "结果");
            
            dataGridViewDataIdList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // dataGridViewDataIdList.AutoResizeColumns();
            DataIdListDisplayAll();
            synchronizationContext = SynchronizationContext.Current;
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
            transport = new Transport(serialPort, consoleLogger);
            client = new Client(transport);
            meterAddress = new MeterAddress(opt.MeterAddress);
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
            Form form = new DataIdListForm();
            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            if(form.ShowDialog() == DialogResult.OK)
            {
                DataIdListDisplayAll();
            }
        }
        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDataIdList.SelectedRows.Count; i++)
            {
                dataGridViewDataIdList.Rows[dataGridViewDataIdList.SelectedRows[i].Index].Cells[0].Value = true;
            }
        }

        private void 取消选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDataIdList.SelectedRows.Count; i++)
            {
                dataGridViewDataIdList.Rows[dataGridViewDataIdList.SelectedRows[i].Index].Cells[0].Value = false;
            }
        }

        private void 选择所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDataIdList.Rows.Count; i++)
            {
                dataGridViewDataIdList.Rows[i].Cells[0].Value = true;
            }
        }

        private void 取消所有选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDataIdList.Rows.Count; i++)
            {
                dataGridViewDataIdList.Rows[i].Cells[0].Value = false;
            }
        }
        private void 清除所有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewDataIdList.Rows.Count; i++)
            {
                dataGridViewDataIdList.Rows[i].Cells[7].Value = null;
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
                    // DataGridViewRow row = new DataGridViewRow();
                    // row.Cells.Add();
                    // row.Cells[1].Value = i;
                    // row.Cells[2].Value = dataIdArray[i].Id.ToString("X8");
                    // row.Cells[3].Value = dataIdArray[i].Name;
                    // row.Cells[4].Value = dataIdArray[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
                    // row.Cells[5].Value = dataIdArray[i].DataBytes;
                    // row.Cells[6].Value = dataIdArray[i].Unit;
                    // dataGridViewDataIdList.Rows.Add(row);
                }
                //dataGridViewDataIdList.AutoResizeColumns();
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
                        for (int j = 0; j < dataGridViewDataIdList.RowCount; j++)
                        {
                            if(dataGridViewDataIdList.Rows[j].Cells[2].Value.ToString() == rst.DataId.Id.ToString("X8"))
                            {
                                index = j;
                                break;
                            }
                        }
                        dataGridViewDataIdList.Rows[index].Cells[7].Value = null;
                        dataGridViewDataIdList.CurrentCell = dataGridViewDataIdList.Rows[index].Cells[7];
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
            for (int j = 0; j < dataGridViewDataIdList.RowCount; j++)
            {
                if(dataGridViewDataIdList.Rows[j].Cells[2].Value.ToString() == rst.DataId.Id.ToString("X8"))
                {
                    index = j;
                    break;
                }
            }
            if(rst.Result)
            {
                displayStr = rst.DataId.GetDataString(rst.DataBytes);
                dataGridViewDataIdList.Rows[index].Cells[7].Style.BackColor = Color.White;
            }
            else
            {
                displayStr = rst.Error.ToString();
                dataGridViewDataIdList.Rows[index].Cells[7].Style.BackColor = Color.Red;
            }
            dataGridViewDataIdList.Rows[index].Cells[7].Value = displayStr;
        }
        private void ReadOnce(Object obj)
        {
            List<DataId> dataIdList = (List<DataId>)obj;
            CommResult rst = null;
            cycleSwith = true;
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
                }
                catch(Exception e)
                {
                    MessageBox.Show("未知错误" + e.Message, "MeterTest",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    rst.Error = "未知错误";
                }
                finally
                {
                    Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                    dic.Add("read", rst);
                    synchronizationContext.Post(ReadOptUiUpdate, dic);
                    Thread.Sleep(500);
                }
                if(cycleSwith == false)
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
            cycleSwith = true;
            
            int cycleReadErrorCnt = 0;
            int cycleReadOkCnt = 0;
            int timeOutCnt = 0;
            // int errorCnt = 0;

            while(cycleSwith)
            {
                // foreach (var item in dataIdList)
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
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("未知错误" + e.Message, "MeterTest",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rst.Error = "未知错误";

                    }
                    finally
                    {
                        Dictionary<String, CommResult> dic = new Dictionary<string, CommResult>();
                        dic.Add("Read Cycle", rst);
                        synchronizationContext.Post(ReadOptUiUpdate, dic);
                        Thread.Sleep(500);
                    }
                    if(!cycleSwith)
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
            for (int i = 0; i < dataGridViewDataIdList.Rows.Count; i++)
            {
                if((dataGridViewDataIdList.Rows[i].Cells[0].Value != null) 
                && (bool)dataGridViewDataIdList.Rows[i].Cells[0].Value == true)
                {
                    dataId = DataIdDb.DataIds.ToArray()[Convert.ToInt32(dataGridViewDataIdList.Rows[i].Cells[1].Value)];  
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
            for (int i = 0; i < dataGridViewDataIdList.Rows.Count; i++)
            {
                if((dataGridViewDataIdList.Rows[i].Cells[0].Value != null) 
                && (bool)dataGridViewDataIdList.Rows[i].Cells[0].Value == true)
                {
                    dataId = DataIdDb.DataIds.ToArray()[Convert.ToInt32(dataGridViewDataIdList.Rows[i].Cells[1].Value)];  
                    dataIdList.Add(dataId);
                }
            }
            Thread readCycleThr = new Thread(ReadCycle);
            readCycleThr.IsBackground = true;
            readCycleThr.Start(dataIdList);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            cycleSwith = false;
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            Point point1 = new Point(21, this.buttonReadOne.Location.Y);
            this.buttonReadOne.Location = point1;
            Point point2 = new Point(21 + this.Size.Width / 4, this.buttonReadOne.Location.Y);
            buttonReadClyce.Location = point2;
            Point point3 = new Point(21 + this.Size.Width / 2, this.buttonReadOne.Location.Y);
            buttonStop.Location = point3;
        }
    }
}
