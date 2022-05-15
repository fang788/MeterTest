using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.WindowsForm
{
    public class DataGridViewWrite
    {
        public static void ColumnInit(DataGridView dataGridView)
        {
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
            dataGridView.Columns.Insert(0, checkbox);
            dataGridView.Columns.Add("No", "编号");
            // dataGridViewDataIdList.Columns[0].Width = 80;
            dataGridView.Columns.Add("Id", "数据标识");
            dataGridView.Columns.Add("Name", "数据项名称");
            dataGridView.Columns.Add("Format", "数据格式");
            dataGridView.Columns.Add("DataBytes", "数据长度（字节）");
            dataGridView.Columns.Add("Unit", "单位");
            dataGridView.Columns.Add("WriteData", "写入数据");
            dataGridView.Columns.Add("Rst", "结果");
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public static void DisplayProject(DataGridView dataGridView, string projectName, string tableName)
        {
            dataGridView.Rows.Clear();
            List<DataId> dataIds = MeterTestDbContext.GetDataIdList(projectName, tableName, false);
            if(dataIds == null)
            {
                return;
            }
            for (int i = 0; i < dataIds.Count; i++)
            {
                if(dataIds[i].IsReadable)
                {

                    int index = dataGridView.Rows.Add();
                    dataGridView.Rows[index].Cells[1].Value = i;
                    dataGridView.Rows[index].Cells[2].Value = dataIds[i].Id.ToString("X8");
                    dataGridView.Rows[index].Cells[3].Value = dataIds[i].Name;
                    dataGridView.Rows[index].Cells[4].Value = dataIds[i].Format;// == null? null : (dataIdArray[i].Format.ToString());
                    dataGridView.Rows[index].Cells[5].Value = dataIds[i].DataBytes;
                    dataGridView.Rows[index].Cells[6].Value = dataIds[i].Unit;
                }
            }
        }

        public static void FormLoad(DataGridView dataGridView)
        {
            ColumnInit(dataGridView);
            MeterTestConfig config = MeterTestDbContext.GetMeterTestConfig();
            if(config == null)
            {
                config = new MeterTestConfig();
            }
            DisplayProject(dataGridView, config.SelectRwProjectName, config.SelectRwTableName);
        }
    }
}