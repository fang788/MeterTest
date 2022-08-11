using System;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.WinForm.WriteForm
{
    public interface IWriteForm
    {
        DataId WriteDataId { get; set; }
        String WriteString{ get; set; }
        String WriteTip{get; set; }
    }
}