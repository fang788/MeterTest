using System;
using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Freeze
{
    public class FreezeDataBlock : IComparable
    {
        public DateTime time;
        public int No;
        public int Bytes;
        public byte[] ByteArray = null;
        public uint TimeReadDataId;
        public List<FreezeItem> ItemList = new List<FreezeItem>();

        public void ByteArrayConvetToItemList()
        {
            if(ByteArray.Length != Bytes)
            {
                throw new System.Exception("读取的数据长度不正确");
            }
            this.time = new DateTime(PublicClass.ByteBcd2Hex(ByteArray[4]) + 2000,
                                     PublicClass.ByteBcd2Hex(ByteArray[3]),
                                     PublicClass.ByteBcd2Hex(ByteArray[2]),
                                     PublicClass.ByteBcd2Hex(ByteArray[1]),
                                     PublicClass.ByteBcd2Hex(ByteArray[0]),
                                     0);
            //  = dateTime;
            for (int i = 0; i < ItemList.Count; i++)
            {
                FreezeItem item = ItemList[i];
                item.Value = 0;
                for (int j = 0; j < item.Length; j++)
                {
                    item.Value *= 10;
                    item.Value += PublicClass.ByteBcd2Hex(ByteArray[j + item.Offset]);
                }
                for (int j = 0; j < item.Point; j++)
                {
                    item.Value /= 10;
                }
            }
        }

        public FreezeDataBlock()
        {
        }
        
        public FreezeDataBlock(int no, int bytes, uint dataId, List<FreezeItem> itemList)
        {
            No = no;
            Bytes = bytes;
            TimeReadDataId = dataId;
            ItemList = itemList;
        }

        public int CompareTo(object obj)
        {
            return this.time.CompareTo(((FreezeDataBlock)obj).time);
        }

        public override bool Equals(object obj)
        {
            return obj is FreezeDataBlock block &&
                   time == block.time &&
                   No == block.No &&
                   EqualityComparer<List<FreezeItem>>.Default.Equals(ItemList, block.ItemList);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(time, No, ItemList);
        }
    }
}