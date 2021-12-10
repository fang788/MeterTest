using System;
using System.Collections.Generic;

namespace MeterTest.Source.Freeze
{
    public class FreezeDataBlock : IComparable
    {
        public DateTime time;
        public int No;
        public List<FreezeItem> ItemList = new List<FreezeItem>();

        public FreezeDataBlock()
        {
        }

        public FreezeDataBlock(DateTime time, int no, List<FreezeItem> itemList)
        {
            this.time = time;
            No = no;
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