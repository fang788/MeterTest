using System;
using System.Collections.Generic;

namespace MeterTest.Source.Freeze
{
    public interface IReadFreezeData
    {
        List<FreezeDataBlock> ReadFreezeDataFromTime(DateTime start, DateTime end, int time, int blockNo);
        List<FreezeDataBlock> ReadFreezeDataFromCntBlk(int cnt, int blockNo);
        List<FreezeDataBlock> ReadFreezeDataFromCntOnce(int cnt, int blockNo);
    }
}