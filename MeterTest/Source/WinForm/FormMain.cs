using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeterTest.Source.Config;
using MeterTest.Source.Dlt645;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.WindowsForm 
{
    public partial class FormMain : Form
    {
        private FormLogger formLogger;
        private Dlt645Client client;
        private SynchronizationContext synchronizationContext = null;
        private bool optLock = false; /* 操作锁，true：正在进行某项操作 */
        private String optMessage = null;
        private bool stopFlag = false;
        // private DeviceFactory deviceFactory = null;
        public FormMain()
        {
            InitializeComponent();
            this.Text = "MeterTest   " + FormVersion.Version;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            MeterTestConfig meterTestConfig = MeterTestDbContext.GetMeterTestConfig();
            formLogger    = new FormLogger();
            client        = Dlt645Client.GetDlt645Client(formLogger);
            DataGridViewRead.FormLoad(dataGridViewRead);
            DataGridViewWrite.FormLoad(dataGridViewWrite);
            DataGridViewPara.FormLoad(dataGridViewPara);
            toolStripStatusLabelParaConfigTable.Text = "当前项目: "+ meterTestConfig.SelectParaProjectName + "  已选择参数配置表：" + meterTestConfig.SelectParaTableName;
            toolStripStatusLabelRead.Text = "当前项目: "+ meterTestConfig.SelectRwProjectName + "  已选择读写表：" + meterTestConfig.SelectRwTableName;
            synchronizationContext = SynchronizationContext.Current;
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
        }
        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewRead.SelectedRows.Count; i++)
            {
                dataGridViewRead.Rows[dataGridViewRead.SelectedRows[i].Index].Cells[0].Value = true;
                ((DataGridViewCheckBoxCell)dataGridViewRead.Rows[dataGridViewRead.SelectedRows[i].Index].Cells[0]).EditingCellFormattedValue = true;
            }
        }

        private void 取消选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewRead.SelectedRows.Count; i++)
            {
                dataGridViewRead.Rows[dataGridViewRead.SelectedRows[i].Index].Cells[0].Value = false;
                ((DataGridViewCheckBoxCell)dataGridViewRead.Rows[dataGridViewRead.SelectedRows[i].Index].Cells[0]).EditingCellFormattedValue = false;
            }
        }

        private void 选择所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewRead.Rows.Count; i++)
            {
                dataGridViewRead.Rows[i].Cells[0].Value = true;
                ((DataGridViewCheckBoxCell)dataGridViewRead.Rows[i].Cells[0]).EditingCellFormattedValue = true;
            }
        }

        private void 取消所有选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridViewRead.Rows.Count; i++)
            {
                dataGridViewRead.Rows[i].Cells[0].Value = false;
                ((DataGridViewCheckBoxCell)dataGridViewRead.Rows[i].Cells[0]).EditingCellFormattedValue = false;
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
                        // msg[2] = dataIds[i].GetDataString(byteArray);
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
                }
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
                }
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
                toolStripStatusLabelParaConfigTable.Text = "当前项目: "+ meterTestConfig.SelectParaProjectName + "  已选择参数配置表：" + meterTestConfig.SelectParaTableName;
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
                    // DataId dataId = new DataId(Convert.ToUInt32(dataGridViewRead.Rows[i].Cells[2].Value.ToString(), 16));
                    DataId dataId = MeterTestDbContext.GetDataId(MeterTestDbContext.GetMeterTestConfig().SelectRwProjectName, MeterTestDbContext.GetMeterTestConfig().SelectRwTableName, false, Convert.ToUInt32(dataGridViewRead.Rows[i].Cells[2].Value.ToString(), 16));
                    dataIds.Add(dataId);
                }
            }
            if(dataIds.Count > 0)
            {
                optLock = true;
                optMessage = "正在单次读取";
                // deviceFactory = new DeviceFactory(client, server, this);
                // Thread thread = new Thread(deviceFactory.ReadOnce);
                // thread.IsBackground = true;
                // thread.Start((object)dataIds);
                stopFlag = false;
                Task.Factory.StartNew(() => {
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
                    }
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
                    DataId dataId = new DataId(Convert.ToUInt32(dataGridViewRead.Rows[i].Cells[2].Value.ToString(), 16));
                    dataIds.Add(dataId);
                }
            }
            if(dataIds.Count > 0)
            {
                optLock = true;
                optMessage = "正在循环读取";
                // deviceFactory = new DeviceFactory(client, server, this);
                // Thread thread = new Thread(deviceFactory.ReadCycle);
                // thread.IsBackground = true;
                // thread.Start((object)dataIds);
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
                        }
                    }
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
                    dataGridViewRead.Rows[j].Cells[7].Value = logs[3];
                    if(logs[2] == true.ToString())
                    {
                        toolStripStatusLabelStatus.Text = "已读取数据标识：" + logs[0];
                    }
                    else
                    {
                        toolStripStatusLabelStatus.Text = "读取数据标识：" + logs[0] + " 失败";
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
                meterTestConfig.SelectRwProjectName = menu.OwnerItem.Text;
                meterTestConfig.SelectRwTableName   = menu.Text;
                context.SaveChanges();
                DataGridViewRead.DisplayProject(dataGridViewRead, meterTestConfig.SelectRwProjectName, meterTestConfig.SelectRwTableName);
                toolStripStatusLabelRead.Text = "当前项目: "+ meterTestConfig.SelectRwProjectName + "  已选择读写表：" + meterTestConfig.SelectRwTableName;
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
    }
}
