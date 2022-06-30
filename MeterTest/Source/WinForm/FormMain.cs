using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;
using MeterTest.Source.SQLite;
using MeterTest.Source.WinForm.WriteForm;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.WinForm 
{
    public partial class FormMain : Form
    {
        public readonly string Version = "1.0.0";
        public readonly string Submit = "334b9b3f88e76216ec701a1f58fcfd399185426b";
        public readonly string SubmitData = "2022-06-10";
        public readonly string DotnetVersion = "5.0.17";
        private FormLogger formLogger;
        private Dlt645Client client;
        private SynchronizationContext synchronizationContext = null;
        private bool optLock = false; /* 操作锁，true：正在进行某项操作 */
        private String optMessage = null;
        private bool stopFlag = false;
        public FormMain()
        {
            InitializeComponent();
            this.Text = "MeterTest   " + Version;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            MeterTestConfig meterTestConfig = MeterTestDbContext.GetMeterTestConfig();
            formLogger    = new FormLogger();
            client        = Dlt645Client.GetDlt645Client(formLogger);
            DataGridViewRead.FormLoad(dataGridViewRead);
            DataGridViewWrite.FormLoad(dataGridViewWrite);
            DataGridViewPara.FormLoad(dataGridViewPara);
            toolStripStatusLabelParaConfigTableName.Text = "当前项目: "+ meterTestConfig.SelectParaProjectName + "  已选择参数配置表：" + meterTestConfig.SelectParaTableName;
            toolStripStatusLabelReadTabName.Text = "当前项目: "+ meterTestConfig.SelectReadProjectName + "  已选择读取表：" + meterTestConfig.SelectReadTableName;
            toolStripStatusLabelWriteTabName.Text = "当前项目: "+ meterTestConfig.SelectWriteProjectName + "  已选择读取表：" + meterTestConfig.SelectWriteTableName;
            synchronizationContext = SynchronizationContext.Current;
        }

        private void 关于MeterTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Tip = String.Format("版本：{0}\n提交: {1}\n日期: {2}\ndotnet: {3}", Version, Submit, SubmitData, DotnetVersion);
            MessageBox.Show(Tip, "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void 选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOptions form = new FormOptions();

            this.AddOwnedForm(form);
            form.StartPosition = FormStartPosition.CenterParent;
            if(form.ShowDialog() == DialogResult.OK)
            {
                client = Dlt645Client.GetDlt645Client(formLogger);
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
            if(formLogger.WindowState == FormWindowState.Minimized)
            {
                formLogger.WindowState = FormWindowState.Normal;
            }
            formLogger.Activate();
        }
        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = null;
            if(sender == 选择ToolStripMenuItem1)
            {
                dataGridView = dataGridViewWrite;
            }
            else
            {
                dataGridView = dataGridViewRead;
            }
            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                item.Cells[0].Value = true;
                ((DataGridViewCheckBoxCell)item.Cells[0]).EditingCellFormattedValue = true;
            }
        }

        private void 取消选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = null;
            if(sender == 取消选择ToolStripMenuItem1)
            {
                dataGridView = dataGridViewWrite;
            }
            else
            {
                dataGridView = dataGridViewRead;
            }
            for (int i = 0; i < dataGridView.SelectedRows.Count; i++)
            {
                dataGridView.Rows[dataGridView.SelectedRows[i].Index].Cells[0].Value = false;
                ((DataGridViewCheckBoxCell)dataGridView.Rows[dataGridView.SelectedRows[i].Index].Cells[0]).EditingCellFormattedValue = false;
            }
        }

        private void 选择所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = null;
            if(sender == 选择所有ToolStripMenuItem1)
            {
                dataGridView = dataGridViewWrite;
            }
            else
            {
                dataGridView = dataGridViewRead;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = true;
                ((DataGridViewCheckBoxCell)dataGridView.Rows[i].Cells[0]).EditingCellFormattedValue = true;
            }
        }

        private void 取消所有选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dataGridView = null;
            if(sender == 取消所有选择ToolStripMenuItem)
            {
                dataGridView = dataGridViewRead;
            }
            else
            {
                dataGridView = dataGridViewWrite;
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells[0].Value = false;
                ((DataGridViewCheckBoxCell)dataGridView.Rows[i].Cells[0]).EditingCellFormattedValue = false;
            }
        }
        private void 清除所有数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewRead.Rows.Count; i++)
            {
                dataGridViewRead.Rows[i].Cells[7].Value = null;
            }
        }
        
        private void 编程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterTestConfig meterTestConfig = MeterTestDbContext.GetMeterTestConfig();
            List<DataId> dataIds = MeterTestDbContext.GetDataIdList(meterTestConfig.SelectParaProjectName, meterTestConfig.SelectParaTableName, true);
            foreach (var dataId in dataIds)
            {
                if((dataId.Format == "YYMMDDWW") 
                || (dataId.Format == "hhmmss")
                || (dataId.Format == "YYMMDDhhmm")
                || (dataId.Format == "YYMMDDhhmmss"))
                {
                    string tmp = null;
                    for (int i = 0; i < dataId.DataArray.Length; i++)
                    {
                        tmp = dataId.DataArray[i].ToString("X2");
                    }
                    if(tmp.Trim('A').Equals(""))
                    {
                        tmp = DateTime.Now.ToString(dataId.Format.Trim('W').Replace('Y', 'y').Replace('h', 'H').Replace('D', 'd'));
                        if(dataId.Format.Contains("WW"))
                        {
                            tmp += ((int)(DateTime.Now.DayOfWeek)).ToString("X2");
                        }
                        for (int i = 0; i < dataId.DataArray.Length; i++)
                        {
                            dataId.DataArray[i] = Convert.ToByte(tmp.Substring(i * 2, 2), 16);
                        }
                        Array.Reverse(dataId.DataArray);
                    }
                }
            }
            if((meterTestConfig == null) || (meterTestConfig.SelectParaTableName == null) || (dataIds == null))
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
            for (int j = 1; j < dataGridViewPara.RowCount; j++)
            {
                dataGridViewPara.Rows[j].Cells[8].Value = null;
                dataGridViewPara.Rows[j].Cells[8].Style.BackColor = Color.White;
            }
            // deviceFactory = new DeviceFactory(client, server, this);
            // Thread thread = new Thread(deviceFactory.ParaConfig);
            // thread.IsBackground = true;
            // thread.Start((object)dataIds);
            Task.Factory.StartNew(() => {
                Dlt645Server dlt645Server = MeterTestDbContext.GetDlt645Server();
                for (int i = 0; i < dataIds.Count; i++)
                {
                    string[] msg = new string[3];
                    msg[0] = dataIds[i].Id.ToString("X8");
                    try
                    {
                        client.Write(dlt645Server.MeterAddress, dataIds[i], dlt645Server.Dlt645Password, dlt645Server.Dlt645OperatorCode);
                        msg[1] = true.ToString();
                    }
                    catch (TimeoutException exception)
                    {
                        msg[1] = false.ToString();
                        msg[2] = exception.Message;
                    }
                    catch (Exception exception)
                    {
                        msg[1] = false.ToString();
                        msg[2] = exception.Message;
                        lock (this)
                        {
                            stopFlag = true;
                        }
                    }
                    finally
                    {
                        synchronizationContext.Post(LogShowParaConfig, (Object)msg);
                    }
                    if(stopFlag)
                    {
                        break;
                    }
                    Thread.Sleep(500);
                }
                optLock = false;
            });
        }

        private void 比对ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeterTestConfig meterTestConfig = MeterTestDbContext.GetMeterTestConfig();
            List<DataId> dataIds = MeterTestDbContext.GetDataIdList(meterTestConfig.SelectParaProjectName, meterTestConfig.SelectParaTableName, true);
            if(dataIds == null)
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
            for (int j = 1; j < dataGridViewPara.RowCount; j++)
            {
                dataGridViewPara.Rows[j].Cells[9].Value = null;
                dataGridViewPara.Rows[j].Cells[9].Style.BackColor = Color.White;
            }
            stopFlag = false;
            Task.Factory.StartNew(() => 
            {
                for (int i = 0; i < dataIds.Count; i++)
                {
                    string[] msg = new string[3];
                    msg[0] = dataIds[i].Id.ToString("X8");
                    try
                    {
                        byte[] dataArray = client.Read(MeterTestDbContext.GetDlt645Server().MeterAddress, dataIds[i]);
                        if(dataIds[i].DataCompare(dataArray))
                        {
                            msg[1] = true.ToString();
                        }
                        else
                        {
                            msg[1] = false.ToString();
                        }
                    }
                    catch (TimeoutException exception)
                    {
                        msg[1] = false.ToString();
                        msg[2] = exception.Message;
                    }
                    catch (Exception exception)
                    {
                        msg[1] = false.ToString();
                        msg[2] = exception.Message;
                        lock (this)
                        {
                            stopFlag = true;
                        }
                    }
                    finally
                    {
                        synchronizationContext.Post(LogShowParaCompare, (Object)msg);
                    }
                    if(stopFlag)
                    {
                        break;
                    }
                    Thread.Sleep(500);
                }
                optLock = false;
            });
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                stopFlag = true;
            }
        }
        
        private void contextMenuStripParaConfig_Opening(object sender, CancelEventArgs e)
        {
            Project[] projects = MeterTestDbContext.GetProjectArray();
            ToolStripMenuItem menuSelect = (ToolStripMenuItem)contextMenuStripParaConfig.Items[contextMenuStripParaConfig.Items.IndexOf(选择参数配置方案ToolStripMenuItem)];
            menuSelect.DropDownItems.Clear();
            foreach (var item in projects)
            {
                ToolStripMenuItem menuProject = new ToolStripMenuItem(item.Name);
                List<DataIdTable> dataIdTables = MeterTestDbContext.GetDataIdTableList(item.Name, true);
                foreach (var dataIdTable in dataIdTables)
                {
                    ToolStripMenuItem menuDataIdTable = new ToolStripMenuItem(dataIdTable.Name);
                    menuDataIdTable.Click += new System.EventHandler(this.SelectParaDataIdTableMenu_Click);
                    menuProject.DropDownItems.Add(menuDataIdTable);
                }
                menuSelect.DropDownItems.Add(menuProject);
            }
        }

        private void SelectParaDataIdTableMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            List<DataId> dataIds = MeterTestDbContext.GetDataIdList(menu.OwnerItem.Text, menu.Text, true);
            using(var context = new MeterTestDbContext())
            {
                MeterTestConfig meterTestConfig = context.MeterTestConfigs.First();
                meterTestConfig.SelectParaProjectName = menu.OwnerItem.Text;
                meterTestConfig.SelectParaTableName   = menu.Text;
                context.SaveChanges();
                DataGridViewPara.DisplayProject(dataGridViewPara, meterTestConfig.SelectParaProjectName, meterTestConfig.SelectParaTableName);
                toolStripStatusLabelParaConfigTableName.Text = "当前项目: "+ meterTestConfig.SelectParaProjectName + "  已选择参数配置表：" + meterTestConfig.SelectParaTableName;
            }
        }

        private void 单次读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<DataId> dataIds = new List<DataId>();
            for (int i = 0; i < dataGridViewRead.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridViewRead.Rows[i].Cells[0];
                if ((bool)cell.EditingCellFormattedValue == true)
                {
                    DataId dataId = MeterTestDbContext.GetDataId(MeterTestDbContext.GetMeterTestConfig().SelectReadProjectName, MeterTestDbContext.GetMeterTestConfig().SelectReadTableName, false, Convert.ToUInt32(dataGridViewRead.Rows[i].Cells[2].Value.ToString(), 16));
                    dataIds.Add(dataId);
                }
            }
            if(dataIds.Count > 0)
            {
                optLock = true;
                optMessage = "正在单次读取";
                stopFlag = false;
                Task.Factory.StartNew(() => 
                {
                    for (int i = 0; i < dataIds.Count; i++)
                    {
                        string[] msg = new string[3];
                        msg[0] = dataIds[i].Id.ToString("X8");
                        try
                        {
                            byte[] byteArray = client.Read(MeterTestDbContext.GetDlt645Server().MeterAddress, dataIds[i]);
                            msg[1] = true.ToString();
                            msg[2] = dataIds[i].GetDataString(byteArray);
                        }
                        catch (TimeoutException exception)
                        {
                            msg[1] = false.ToString();
                            msg[2] = exception.Message;
                        }
                        catch (ClientException exception)
                        {
                            msg[1] = false.ToString();
                            msg[2] = exception.Message;
                        }
                        catch (Exception exception)
                        {
                            msg[1] = false.ToString();
                            msg[2] = exception.Message;
                            lock (this)
                            {
                                stopFlag = true;
                            }
                        }
                        finally
                        {
                            synchronizationContext.Post(LogShowRead, msg);
                        }
                        if(stopFlag)
                        {
                            break;
                        }
                        Thread.Sleep(500);
                    }
                    optLock = false;
                });
            }
        }

        private void 循环读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<DataId> dataIds = new List<DataId>();
            for (int i = 0; i < dataGridViewRead.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridViewRead.Rows[i].Cells[0];
                if ((bool)cell.EditingCellFormattedValue == true)
                {
                    DataId dataId = MeterTestDbContext.GetDataId(MeterTestDbContext.GetMeterTestConfig().SelectReadProjectName, MeterTestDbContext.GetMeterTestConfig().SelectReadTableName, false, Convert.ToUInt32(dataGridViewRead.Rows[i].Cells[2].Value.ToString(), 16));
                    dataIds.Add(dataId);
                }
            }
            if(dataIds.Count > 0)
            {
                optLock = true;
                optMessage = "正在循环读取";
                stopFlag = false;
                Task.Factory.StartNew(() => {
                    while(true)
                    {
                        if(stopFlag)
                        {
                            break;
                        }
                        for (int i = 0; i < dataIds.Count; i++)
                        {
                            string[] msg = new string[3];
                            msg[0] = dataIds[i].Id.ToString("X8");
                            try
                            {
                                byte[] byteArray = client.Read(MeterTestDbContext.GetDlt645Server().MeterAddress, dataIds[i]);
                                msg[1] = true.ToString();
                                msg[2] = dataIds[i].GetDataString(byteArray);
                            }
                            catch (TimeoutException exception)
                            {
                                msg[1] = false.ToString();
                                msg[2] = exception.Message;
                            }
                            catch (ClientException exception)
                            {
                                msg[1] = false.ToString();
                                msg[2] = exception.Message;
                            }
                            catch (Exception exception)
                            {
                                msg[1] = false.ToString();
                                msg[2] = exception.Message;
                                lock (this)
                                {
                                    stopFlag = true;
                                }
                            }
                            finally
                            {
                                synchronizationContext.Post(LogShowRead, msg);
                            }
                            if(stopFlag)
                            {
                                break;
                            }
                            Thread.Sleep(500);
                        }
                    }
                    optLock = false;
                });
            }
        }

        private void 停止ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            stopFlag = true;
        }
        private void LogShowRead(Object obj) 
        {
            string[] logs = (string[])obj;
            for (int j = 0; j < dataGridViewRead.RowCount; j++)
            {
                if(dataGridViewRead.Rows[j].Cells[2].Value.ToString() == logs[0])
                {
                    dataGridViewRead.CurrentCell = dataGridViewRead.Rows[j].Cells[7];
                    dataGridViewRead.Rows[j].Cells[7].Value = logs[2];
                    if(logs[2] == true.ToString())
                    {
                        toolStripStatusLabelRead.Text = "已读取数据标识：" + logs[0];
                    }
                    else
                    {
                        toolStripStatusLabelRead.Text = "读取数据标识：" + logs[0] + " 失败";
                    }
                    break;
                }
            }
        }
        
        private void contextMenuStripRead_Opening(object sender, CancelEventArgs e)
        {
            Project[] projects = MeterTestDbContext.GetProjectArray();
            ToolStripMenuItem menuSelect = (ToolStripMenuItem)contextMenuStripRead.Items[contextMenuStripRead.Items.IndexOf(选择读取表ToolStripMenuItem)];
            menuSelect.DropDownItems.Clear();
            foreach (var item in projects)
            {
                ToolStripMenuItem menuProject = new ToolStripMenuItem(item.Name);
                List<DataIdTable> dataIdTables = MeterTestDbContext.GetDataIdTableList(item.Name, false);
                foreach (var dataIdTable in dataIdTables)
                {
                    ToolStripMenuItem menuDataIdTable = new ToolStripMenuItem(dataIdTable.Name);
                    menuDataIdTable.Click += new System.EventHandler(this.SelectRwDataIdTableMenu_Click);
                    menuProject.DropDownItems.Add(menuDataIdTable);
                }
                menuSelect.DropDownItems.Add(menuProject);
            }
        }
        private void SelectRwDataIdTableMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            List<DataId> dataIds = MeterTestDbContext.GetDataIdList(menu.OwnerItem.Text, menu.Text, true);
            using(var context = new MeterTestDbContext())
            {
                MeterTestConfig meterTestConfig = context.MeterTestConfigs.First();
                meterTestConfig.SelectReadProjectName = menu.OwnerItem.Text;
                meterTestConfig.SelectReadTableName   = menu.Text;
                context.SaveChanges();
                DataGridViewRead.DisplayProject(dataGridViewRead, meterTestConfig.SelectReadProjectName, meterTestConfig.SelectReadTableName);
                toolStripStatusLabelReadTabName.Text = "当前项目: "+ meterTestConfig.SelectReadProjectName + "  已选择读取表：" + meterTestConfig.SelectReadTableName;
            }
        }
        
        private void LogShowParaConfig(Object obj)
        {
            string[] logs = (string[])obj;
            for (int j = 0; j < dataGridViewPara.RowCount; j++)
            {
                if(dataGridViewPara.Rows[j].Cells[1].Value.ToString() == logs[0])
                {
                    if(logs[1] == true.ToString())
                    {
                        dataGridViewPara.Rows[j].Cells[8].Value = "成功";
                        dataGridViewPara.Rows[j].Cells[8].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dataGridViewPara.Rows[j].Cells[8].Value = logs[2];
                        dataGridViewPara.Rows[j].Cells[8].Style.BackColor = Color.Red;
                    }
                    toolStripStatusLabelParaConfig.Text = "已配置数据标识：" + logs[0];
                    dataGridViewPara.CurrentCell = dataGridViewPara.Rows[j].Cells[8];
                    break;
                }
            }
        }
        private void LogShowParaCompare(Object obj)
        {
            string[] logs = (string[])obj;
            for (int j = 0; j < dataGridViewPara.RowCount; j++)
            {
                if(dataGridViewPara.Rows[j].Cells[1].Value.ToString() == logs[0])
                {
                    if(logs[1] == true.ToString())
                    {
                        dataGridViewPara.Rows[j].Cells[9].Value = "一致";
                        dataGridViewPara.Rows[j].Cells[9].Style.BackColor = Color.Green;
                    }
                    else
                    {
                        dataGridViewPara.Rows[j].Cells[9].Value = logs[2];
                        dataGridViewPara.Rows[j].Cells[9].Style.BackColor = Color.Red;
                    }
                    toolStripStatusLabelParaConfig.Text = "已比对数据标识：" + logs[0];
                    dataGridViewPara.CurrentCell = dataGridViewPara.Rows[j].Cells[8];
                    break;
                }
            }
        }
        private void dataGridViewWrite_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;
                DataId dataId = MeterTestDbContext.GetDataId(MeterTestDbContext.GetMeterTestConfig().SelectWriteProjectName,
                                                            MeterTestDbContext.GetMeterTestConfig().SelectWriteTableName,
                                                            false,
                                                            Convert.ToUInt32(dataGridView.SelectedRows[0].Cells[2].Value.ToString(), 16));
                Form form = FormWrite.GetFormWrite(dataId);
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    dataGridView.SelectedRows[0].Cells[7].Value = ((IWriteForm)form).WriteString;
                    dataGridView.SelectedRows[0].Cells[9].Value = dataId.GetDataString(dataId.GetByteArray(((IWriteForm)form).WriteString));
                }
            }
        }
        private void LogShowWrite(Object obj) 
        {
            string[] logs = (string[])obj;
            for (int j = 0; j < dataGridViewRead.RowCount; j++)
            {
                if(dataGridViewWrite.Rows[j].Cells[2].Value.ToString() == logs[0])
                {
                    dataGridViewWrite.CurrentCell = dataGridViewWrite.Rows[j].Cells[7];
                    if(logs[1] == true.ToString())
                    {
                        dataGridViewWrite.Rows[j].Cells[8].Value = "成功";
                        toolStripStatusLabelWrite.Text = "已写入数据标识：" + logs[0];
                    }
                    else
                    {
                        dataGridViewWrite.Rows[j].Cells[8].Value = logs[2];
                        toolStripStatusLabelWrite.Text = "写入数据标识：" + logs[0] + " 失败";
                    }
                    break;
                }
            }
        }
        private void 写入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optLock)
            {
                MessageBox.Show(optMessage.ToString(), "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<DataId> dataIds = new List<DataId>();
            DataGridView dataGridView = (DataGridView)dataGridViewWrite;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGridView.Rows[i].Cells[0];
                if ((bool)cell.EditingCellFormattedValue == true)
                {
                    DataId dataId = MeterTestDbContext.GetDataId(MeterTestDbContext.GetMeterTestConfig().SelectWriteProjectName, MeterTestDbContext.GetMeterTestConfig().SelectWriteTableName, false, Convert.ToUInt32(dataGridView.Rows[i].Cells[2].Value.ToString(), 16));
                    if(dataGridView.Rows[i].Cells[7].Value == null)
                    {
                        MessageBox.Show("数据标识：" + dataId.Id.ToString("X8") + "\r未输入数据", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dataId.DataArray = dataId.GetByteArray(dataGridView.Rows[i].Cells[7].Value.ToString());
                    dataIds.Add(dataId);
                }
            }
            foreach (var dataId in dataIds)
            {
                if((dataId.Format == "YYMMDDWW") 
                || (dataId.Format == "hhmmss")
                || (dataId.Format == "YYMMDDhhmm")
                || (dataId.Format == "YYMMDDhhmmss"))
                {
                    string tmp = null;
                    for (int i = 0; i < dataId.DataArray.Length; i++)
                    {
                        tmp = dataId.DataArray[i].ToString("X2");
                    }
                    if(tmp.Trim('A').Equals(""))
                    {
                        tmp = DateTime.Now.ToString(dataId.Format.Trim('W').Replace('Y', 'y').Replace('h', 'H').Replace('D', 'd'));
                        if(dataId.Format.Contains("WW"))
                        {
                            tmp += ((int)(DateTime.Now.DayOfWeek)).ToString("X2");
                        }
                        for (int i = 0; i < dataId.DataArray.Length; i++)
                        {
                            dataId.DataArray[i] = Convert.ToByte(tmp.Substring(i * 2, 2), 16);
                        }
                        Array.Reverse(dataId.DataArray);
                    }
                }
            }
            if(dataIds.Count > 0)
            {
                optLock = true;
                optMessage = "正在写入";
                stopFlag = false;
                Task.Factory.StartNew(() => 
                {
                    Dlt645Server dlt645Server = MeterTestDbContext.GetDlt645Server();
                    for (int i = 0; i < dataIds.Count; i++)
                    {
                        string[] msg = new string[3];
                        msg[0] = dataIds[i].Id.ToString("X8");
                        try
                        {
                            client.Write(dlt645Server.MeterAddress, dataIds[i], dlt645Server.Dlt645Password, dlt645Server.Dlt645OperatorCode);
                            msg[1] = true.ToString();
                        }
                        catch (TimeoutException exception)
                        {
                            msg[1] = false.ToString();
                            msg[2] = exception.Message;
                        }
                        catch (ClientException exception)
                        {
                            msg[1] = false.ToString();
                            msg[2] = exception.Message;
                        }
                        catch (Exception exception)
                        {
                            msg[1] = false.ToString();
                            msg[2] = exception.Message;
                            //lock (this)
                            //{
                            //    stopFlag = true;
                            //}
                        }
                        finally
                        {
                            synchronizationContext.Post(LogShowWrite, msg);
                        }
                        if(stopFlag)
                        {
                            break;
                        }
                        Thread.Sleep(500);
                    }
                    optLock = false;
                });
            }
        }
        private void SelectWriteDataIdTableMenu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            List<DataId> dataIds = MeterTestDbContext.GetDataIdList(menu.OwnerItem.Text, menu.Text, true);
            using(var context = new MeterTestDbContext())
            {
                MeterTestConfig meterTestConfig = context.MeterTestConfigs.First();
                meterTestConfig.SelectWriteProjectName = menu.OwnerItem.Text;
                meterTestConfig.SelectWriteTableName   = menu.Text;
                context.SaveChanges();
                DataGridViewWrite.DisplayProject(dataGridViewWrite, meterTestConfig.SelectWriteProjectName, meterTestConfig.SelectWriteTableName);
                toolStripStatusLabelWriteTabName.Text = "当前项目: "+ meterTestConfig.SelectWriteProjectName + "  已选择写入表：" + meterTestConfig.SelectWriteTableName;
            }
        }
        private void contextMenuStripWrite_Opening(object sender, CancelEventArgs e)
        {
            Project[] projects = MeterTestDbContext.GetProjectArray();
            ContextMenuStrip contextMenuStripWrite = sender as ContextMenuStrip;
            ToolStripMenuItem menuSelect = (ToolStripMenuItem)contextMenuStripWrite.Items[contextMenuStripWrite.Items.IndexOf(选择写入表ToolStripMenuItem)];
            menuSelect.DropDownItems.Clear();
            foreach (var item in projects)
            {
                ToolStripMenuItem menuProject = new ToolStripMenuItem(item.Name);
                List<DataIdTable> dataIdTables = MeterTestDbContext.GetDataIdTableList(item.Name, false);
                foreach (var dataIdTable in dataIdTables)
                {
                    ToolStripMenuItem menuDataIdTable = new ToolStripMenuItem(dataIdTable.Name);
                    menuDataIdTable.Click += new System.EventHandler(this.SelectWriteDataIdTableMenu_Click);
                    menuProject.DropDownItems.Add(menuDataIdTable);
                }
                menuSelect.DropDownItems.Add(menuProject);
            }
        }
    }
}
