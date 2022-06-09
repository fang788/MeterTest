using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MeterTest.Source.Dlt645;
using MeterTest.Source.SQLite;
using Microsoft.EntityFrameworkCore;

namespace MeterTest.Source.WinForm
{
    public class DataGridViewPara
    {
        public static List<DataId> HasCommAddrAutoAddList = new List<DataId>
        {
            new DataId(0x04000401),
            new DataId(0x04000402),
        };
        public static void ColumnInit(DataGridView dataGridView)
        {
            dataGridView.Columns.Add("No", "编号");
            dataGridView.Columns.Add("Id", "标识");
            dataGridView.Columns.Add("Name", "名称");
            dataGridView.Columns.Add("Format", "格式");
            dataGridView.Columns.Add("DataBytes", "数据长度");
            dataGridView.Columns.Add("Unit", "单位");
            dataGridView.Columns.Add("data", "数据");
            //为dgv增加复选框列
            DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
            checkbox.HeaderText = "自动加一";
            checkbox.Name = "IsChecked";
            checkbox.TrueValue = true;
            checkbox.FalseValue = false;
            checkbox.DataPropertyName = "IsChecked";
            dataGridView.Columns.Add(checkbox);
            dataGridView.Columns.Add("Rst", "编程结果");
            dataGridView.Columns.Add("Rst", "比对结果");
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void DisplayProject(DataGridView dataGridView, string projectName, string tableName)
        {
            dataGridView.Rows.Clear();
            List<DataId> dataIds = MeterTestDbContext.GetDataIdList(projectName, tableName, true);
            if(dataIds == null)
            {
                return;
            }
            int no = 0;
            foreach (var item in dataIds)
            {
                int index = dataGridView.Rows.Add();
                dataGridView.Rows[index].Cells[0].Value = no;
                dataGridView.Rows[index].Cells[1].Value = item.Id.ToString("X8");
                dataGridView.Rows[index].Cells[2].Value = item.Name;
                dataGridView.Rows[index].Cells[3].Value = item.Format;// == null? null : (dataIdArray[i].Format.ToString());
                dataGridView.Rows[index].Cells[4].Value = item.DataBytes;
                dataGridView.Rows[index].Cells[5].Value = item.Unit;
                dataGridView.Rows[index].Cells[6].Value = item.GetDataString(item.DataArray);
                if(!HasCommAddrAutoAddList.Contains(item))
                {
                    dataGridView.Rows[index].Cells[7].ReadOnly = true;;
                }
                no++;
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
            DisplayProject(dataGridView, config.SelectParaProjectName, config.SelectParaTableName);
        }
    }
}