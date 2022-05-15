using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using MeterTest.Source.Config;
using MeterTest.Source.SQLite;
using MeterTest.Source.Dlt645;
using MeterTest.Source.WindowsForm;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.WindowsForm
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            using (var context = new MeterTestDbContext())
            {
                MeterTestConfig config = context.MeterTestConfigs.FirstOrDefault();
                config.PortName = ComboBoxPort.Text;
                config.BaudRate = Convert.ToInt32(ComboBoxBaudRate.Text);
                config.DataBits = Convert.ToInt32(ComboBoxDataBit.Text);
                config.Parity = (Parity)Enum.Parse(typeof(Parity), ComboBoxCheckBit.Text);
                config.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ComboBoxStopBit.Text);
                config.ReadTimeout = Convert.ToInt32(numericUpDownReadTimeOut.Text);
                config.TableBodySerialPortName = comboBoxTTPort.Text;

                Dlt645Server service = context.Dlt645Servers.FirstOrDefault();
                service.MeterAddress = new MeterAddress(textBoxServerAddress.Text);
                service.Authority = Convert.ToByte(comboBoxAuthority.Text, 16);
                service.Password = Convert.ToInt32(textBoxPassword.Text);
                service.OperatorCode = Convert.ToInt32(textBoxOperatorCode.Text, 16);
                
                context.SaveChanges();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            MeterTestConfig config = MeterTestDbContext.GetMeterTestConfig();
            ComboBoxPort.Text = config.PortName;
            ComboBoxBaudRate.Text = config.BaudRate.ToString();
            ComboBoxDataBit.Text = config.DataBits.ToString();
            ComboBoxCheckBit.Text = config.Parity.ToString();
            ComboBoxStopBit.Text = config.StopBits.ToString();
            numericUpDownReadTimeOut.Text = config.ReadTimeout.ToString();
            comboBoxTTPort.Text = config.TableBodySerialPortName;

            Dlt645Server service = MeterTestDbContext.GetDlt645Server();
            comboBoxAuthority.Text = service.Dlt645Password.Authority.ToString("X2"); 
            textBoxPassword.Text = service.Dlt645Password.Password.ToString("X6");
            textBoxOperatorCode.Text = service.Dlt645OperatorCode.ToString();
            textBoxServerAddress.Text = service.MeterAddress.ToString();

            treeViewProject.Nodes[0].ContextMenuStrip = contextMenuStripAddProject;
            Project[] projects = MeterTestDbContext.GetProjectArray();
            treeViewProject.Nodes[0].Nodes.Clear();
            if((projects != null) && (projects.Length > 0))
            {
                foreach (var item in projects)
                {
                    TreeNode treeNode = new TreeNode(item.Name);
                    treeNode.ContextMenuStrip = contextMenuStripDelProject;
                    treeViewProject.Nodes[0].Nodes.Add(treeNode);
                }
                textBoxProjectName.Text = projects[0].Name;
                textBoxProjectChgTime.Text = new DateTime(projects[0].Ticks).ToString("yyyy-MM-dd hh:mm:ss");
                checkBoxIsUse.Checked = projects[0].IsUse;
                List<DataIdTable> paraDataIdTables = MeterTestDbContext.GetParaConfigTables(projects[0].Name);
                if(paraDataIdTables != null)
                {
                    textBoxParaTableCnt.Text = paraDataIdTables.Count.ToString();
                }
                else
                {
                    textBoxParaTableCnt.Text = "0";
                }
                List<DataIdTable> RwDataIdTables = MeterTestDbContext.GetRwDataIdTables(projects[0].Name);
                if(RwDataIdTables != null)
                {
                    textBoxRwTableCnt.Text = RwDataIdTables.Count.ToString();
                }
                else
                {
                    textBoxRwTableCnt.Text = "0";
                }
                treeViewProject.SelectedNode = treeViewProject.Nodes[0].Nodes[0];
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxServerAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(((e.KeyChar < (char)'0') || (e.KeyChar > (char)'9')) 
            && (e.KeyChar != (char)'A')
            && (e.KeyChar != (char)'a')
            && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true; 
            }
        }

        private void comboBoxTTPort_DropDown(object sender, EventArgs e)
        {
            comboBoxTTPort.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBoxTTPort.Items.Add(s);
            }
        }

        // private void buttonRWManage_Click(object sender, EventArgs e)
        // {
        //     DataIdListForm form = new DataIdListForm();
        //     this.AddOwnedForm(form);
        //     form.StartPosition = FormStartPosition.CenterParent;
        //     form.ShowDialog();
        //     List<DataIdTable> RwDataIdTables = MeterTestDbContext.GetRwDataIdTables(textBoxProjectName.Text);
        //     if(RwDataIdTables != null)
        //     {
        //         textBoxRwTableCnt.Text = RwDataIdTables.Count.ToString();
        //     }
        //     else
        //     {
        //         textBoxRwTableCnt.Text = "0";
        //     }
        // }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddName form = new FormAddName("请输入项目名称", "项目名称：", "项目");
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
            if(form.SelectRwProjectName != null)
            {
                Project project = null;
                using(var context = new MeterTestDbContext())
                {
                    if(context.Projects.SingleOrDefault(e => e.Name == form.SelectRwProjectName) == null)
                    {
                        project = new Project();
                        project.Name = form.SelectRwProjectName;
                        project.Ticks = DateTime.Now.Ticks;
                        project.IsUse = true;
                        context.Projects.Add(project);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("已存在项目：" + form.SelectRwProjectName + "，请勿重复添加！", "MeterTest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Project[] projects = MeterTestDbContext.GetProjectArray();
                treeViewProject.Nodes[0].Nodes.Clear();
                foreach (var item in projects)
                {
                    TreeNode treeNode = new TreeNode(item.Name);
                    treeNode.ContextMenuStrip = contextMenuStripDelProject;
                    treeViewProject.Nodes[0].Nodes.Add(treeNode);
                }
                textBoxProjectName.Text = project.Name;
                textBoxProjectChgTime.Text = new DateTime(project.Ticks).ToString("yyyy-MM-dd hh:mm:ss");
                checkBoxIsUse.Visible = project.IsUse;
                textBoxParaTableCnt.Text = "0";
                textBoxRwTableCnt.Text = "0";
                checkBoxIsUse.Checked = project.IsUse;
                treeViewProject.SelectedNode = treeViewProject.Nodes[0].Nodes[project.Name];
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((treeViewProject.Nodes[0].Nodes != null) 
            && (treeViewProject.Nodes[0].Nodes.Contains(treeViewProject.SelectedNode)))
            {
                using(var context = new MeterTestDbContext())
                {
                    Project project = context.Projects.Single(e => e.Name == treeViewProject.SelectedNode.Text);
                    List<DataIdTable> dataIdTables = context.DataIdTables.Where(e => e.ProjectName == project.Name)
                                                                         .ToList();
                    if(dataIdTables != null)
                    {
                        foreach (var item in dataIdTables)
                        {
                            List<DataId> dataIds = context.DataIds.Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableName")  == item.Name)
                                                                  .Where(e => EF.Property<bool>(e, "ForeignKey_DataIdTableIsConfig")  == item.IsConfig)
                                                                  .Where(e => EF.Property<string>(e, "ForeignKey_DataIdTableProjectName")  == item.ProjectName)
                                                                  .ToList();
                            if(dataIds != null)
                            {
                                context.RemoveRange(dataIds);
                            }    
                        }
                        context.RemoveRange(dataIdTables);
                    }
                    context.Projects.Remove(project);
                    context.SaveChanges();
                }
                Project[] projects = MeterTestDbContext.GetProjectArray();
                treeViewProject.Nodes[0].Nodes.Clear();
                if((projects != null) && (projects.Length > 0))
                {
                    foreach (var item in projects)
                    {
                        TreeNode treeNode = new TreeNode(item.Name);
                        treeNode.ContextMenuStrip = contextMenuStripDelProject;
                        treeViewProject.Nodes[0].Nodes.Add(treeNode);
                    }
                    textBoxProjectName.Text = projects[0].Name;
                    textBoxProjectChgTime.Text = new DateTime(projects[0].Ticks).ToString("yyyy-MM-dd hh:mm:ss");
                    checkBoxIsUse.Checked = projects[0].IsUse;
                    List<DataIdTable> paraDataIdTables = MeterTestDbContext.GetParaConfigTables(projects[0].Name);
                    if(paraDataIdTables != null)
                    {
                        textBoxParaTableCnt.Text = paraDataIdTables.Count.ToString();
                    }
                    else
                    {
                        textBoxParaTableCnt.Text = "0";
                    }
                    List<DataIdTable> RwDataIdTables = MeterTestDbContext.GetRwDataIdTables(projects[0].Name);
                    if(RwDataIdTables != null)
                    {
                        textBoxRwTableCnt.Text = RwDataIdTables.Count.ToString();
                    }
                    else
                    {
                        textBoxRwTableCnt.Text = "0";
                    }
                }
            }
        }

        private void buttonRwTableMng_Click(object sender, EventArgs e)
        {
            if((treeViewProject.Nodes[0].Nodes != null) 
            && (treeViewProject.Nodes[0].Nodes.Contains(treeViewProject.SelectedNode)))
            {
                FormDataIdTableMng form = new FormDataIdTableMng(textBoxProjectName.Text, false);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
                List<DataIdTable> RwDataIdTables = MeterTestDbContext.GetRwDataIdTables(textBoxProjectName.Text);
                if(RwDataIdTables != null)
                {
                    textBoxRwTableCnt.Text = RwDataIdTables.Count.ToString();
                }
                else
                {
                    textBoxRwTableCnt.Text = "0";
                }
            }
        }

        private void buttonParaTableMng_Click(object sender, EventArgs e)
        {
            if((treeViewProject.Nodes[0].Nodes != null) 
            && (treeViewProject.Nodes[0].Nodes.Contains(treeViewProject.SelectedNode)))
            {
                FormDataIdTableMng form = new FormDataIdTableMng(textBoxProjectName.Text, true);
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
                List<DataIdTable> paraDataIdTables = MeterTestDbContext.GetParaConfigTables(textBoxProjectName.Text);
                if(paraDataIdTables != null)
                {
                    textBoxParaTableCnt.Text = paraDataIdTables.Count.ToString();
                }
                else
                {
                    textBoxParaTableCnt.Text = "0";
                }
            }
        }

        private void treeViewProject_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if((treeViewProject.Nodes[0].Nodes != null) 
            && (treeViewProject.Nodes[0].Nodes.Contains(treeViewProject.SelectedNode))
            && (textBoxProjectName.Text != treeViewProject.SelectedNode.Text))
            {
                Project project = MeterTestDbContext.GetProject(treeViewProject.SelectedNode.Text);
                if(project == null)
                {
                    MessageBox.Show("程序错误，请联系方兵！");
                    return;
                }
                textBoxProjectName.Text = project.Name;
                textBoxProjectChgTime.Text = new DateTime(project.Ticks).ToString("yyyy-MM-dd hh:mm:ss");
                checkBoxIsUse.Checked = project.IsUse;
                List<DataIdTable> paraDataIdTables = MeterTestDbContext.GetParaConfigTables(project.Name);
                if(paraDataIdTables != null)
                {
                    textBoxParaTableCnt.Text = paraDataIdTables.Count.ToString();
                }
                else
                {
                    textBoxParaTableCnt.Text = "0";
                }
                List<DataIdTable> RwDataIdTables = MeterTestDbContext.GetRwDataIdTables(project.Name);
                if(RwDataIdTables != null)
                {
                    textBoxRwTableCnt.Text = RwDataIdTables.Count.ToString();
                }
                else
                {
                    textBoxRwTableCnt.Text = "0";
                }
            }
        }
        private void checkBoxIsUse_CheckedChanged(object sender, EventArgs e)
        {
            using(var context = new MeterTestDbContext())
            {
                Project project = context.Projects.Single(e => e.Name == textBoxProjectName.Text);
                project.IsUse = checkBoxIsUse.Checked;
                context.SaveChanges();
            }
        }

        private void ComboBoxPort_DropDown(object sender, EventArgs e)
        {
            ComboBoxPort.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                ComboBoxPort.Items.Add(s);
            }
        }
    }
}
