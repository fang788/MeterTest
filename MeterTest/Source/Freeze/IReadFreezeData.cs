using System;
using System.Collections.Generic;

namespace MeterTest.Source.Freeze
{
    public interface IReadFreezeData
    {
        FreezeDataBlock ReadFreezeDataFromTime(DateTime time, int blockNo);
        FreezeDataBlock ReadFreezeDataFromCntBlk(int cnt, int blockNo);
        FreezeDataBlock ReadFreezeDataFromCntOnce(int cnt, int blockNo);
        int GetFreezeDateBlockCnt();
    }
}