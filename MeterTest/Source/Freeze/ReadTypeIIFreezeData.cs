using System;
using System.Collections.Generic;
using MeterTest.Source.Dlt645;
using Newtonsoft.Json;

namespace MeterTest.Source.Freeze
{
    public class ReadTypeIIFreezeData : IReadFreezeData
    {
               public const int FreezeDataBlockCnt = 2;
        public const int FreezeMaxCnt = 672;
        private Dlt645Client client;
        private MeterAddress address;
        public FreezeDataBlock CreateFreezeDataBlock (int blockNo)
        {
             FreezeDataBlock block = null;
             if(blockNo == 1)
             {
                block = new FreezeDataBlockTypeII_1();
             }
             else if(blockNo == 2)
             {
                block = new FreezeDataBlockTypeII_2();
             }
             return block;
        }

        public ReadTypeIIFreezeData(Dlt645Client client, MeterAddress address)
        {
            this.client = client;
            this.address = address;
        }

        public int GetFreezeDateBlockCnt()
        {
            return ReadTypeIIFreezeData.FreezeDataBlockCnt;
        }

        // public static FreezeDataBlock[2]
        public List<FreezeDataBlock> ReadFreezeDataFromCntBlk(int cnt, int blockNo)
        {
            if((cnt == 0) 
            || (cnt > FreezeDataBlockCnt) 
            || (blockNo > FreezeMaxCnt)
            || (blockNo == 0))
            {
                throw new InvalidOperationException("cnt = ${cnt}, blockNo = ${blockNo}");
            }
            List<FreezeDataBlock> freezeDataBlocks = new List<FreezeDataBlock>();
            
            DataId dataId = new DataId();
            for (int i = 0; i < cnt; i++)
            {
                FreezeDataBlock block = this.CreateFreezeDataBlock(blockNo);
                dataId.Id = (uint)((uint)0xA20000FF + (blockNo << 20) + (cnt << 8));
                block.ByteArray = client.Read(address, dataId);
                block.ByteArrayConvetToItemList();
                freezeDataBlocks.Add(block);
            }
            return freezeDataBlocks;
        }

        public List<FreezeDataBlock> ReadFreezeDataFromCntOnce(int cnt, int blockNo)
        {
            if((cnt == 0) 
            || (cnt > FreezeDataBlockCnt) 
            || (blockNo > FreezeMaxCnt)
            || (blockNo == 0))
            {
                throw new InvalidOperationException("cnt = ${cnt}, blockNo = ${blockNo}");
            }
            List<FreezeDataBlock> freezeDataBlocks = new List<FreezeDataBlock>();

            return freezeDataBlocks;
        }

        public List<FreezeDataBlock> ReadFreezeDataFromTime(DateTime start, DateTime end, int time, int blockNo)
        {
            if((time == 0) 
            || (time > 60) 
            || (blockNo > FreezeMaxCnt)
            || (blockNo == 0))
            {
                throw new InvalidOperationException("cnt = ${time}, blockNo = ${blockNo}");
            }
            List<FreezeDataBlock> freezeDataBlocks = new List<FreezeDataBlock>();
            DataId dataId = new DataId();
            while(start <= end)
            {
                FreezeDataBlock block = CreateFreezeDataBlock(blockNo);
                dataId.Id = block.TimeReadDataId;
                dataId.DataBytes = 5;
                dataId.DataArray = new byte[5];
                dataId.DataArray[0] = (byte)(start.Year - 2000);
                dataId.DataArray[1] = (byte)(start.Month);
                dataId.DataArray[2] = (byte)(start.Day);
                dataId.DataArray[3] = (byte)(start.Hour);
                dataId.DataArray[4] = (byte)(start.Minute);
                block.ByteArray = client.Read(address, dataId); // TODO: 使用读取格式 3 
                start.AddMinutes(time);
            } 
            return freezeDataBlocks;
        }
    }
}