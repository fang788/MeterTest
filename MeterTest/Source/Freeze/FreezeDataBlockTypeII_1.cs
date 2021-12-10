using System;
using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Freeze
{
    public class FreezeDataBlockTypeII_1 : FreezeDataBlock
    {
        // public override void ByteArrayConvetToItemList()
        // {
        //     if(ByteArray.Length != Bytes)
        //     {
        //         throw new System.Exception("读取的数据长度不正确");
        //     }
        //     DateTime dateTime = new DateTime(PublicClass.ByteBcd2Hex(ByteArray[0]) + 2000,
        //                                      PublicClass.ByteBcd2Hex(ByteArray[1]),
        //                                      PublicClass.ByteBcd2Hex(ByteArray[2]),
        //                                      PublicClass.ByteBcd2Hex(ByteArray[3]),
        //                                      PublicClass.ByteBcd2Hex(ByteArray[4]),
        //                                      0);
        //     this.time = dateTime;
        //     for (int i = 0; i < ItemList.Count; i++)
        //     {
        //         FreezeItem item = ItemList[i];
        //         item.Value = 0;
        //         for (int j = 0; j < item.Length; j++)
        //         {
        //             item.Value *= 10;
        //             item.Value += PublicClass.ByteBcd2Hex(ByteArray[j + item.Offset]);
        //         }
        //         for (int j = 0; j < item.Point; j++)
        //         {
        //             item.Value /= 10;
        //         }
        //     }
        // }
        public FreezeDataBlockTypeII_1()
        {
            No = 2;
            Bytes = 149;
            TimeReadDataId = 0xA2F00003;
            ItemList = new List<FreezeItem>
            {
                new FreezeItem(5  ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "正向有功总电能 "       ),
                new FreezeItem(10 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "反向有功总电能 "       ),
                new FreezeItem(15 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "第一象限无功电能 "     ),
                new FreezeItem(20 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "第二象限无功电能 "     ),
                new FreezeItem(25 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "第三象限无功电能 "     ),
                new FreezeItem(30 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "第四象限无功电能 "     ),
                new FreezeItem(35 ,  3, 3, "XXX.XXX      ",   "kW   ",    "正向有功需量 "         ),
                new FreezeItem(38 ,  3, 3, "XXX.XXX      ",   "kW   ",    "反向有功需量 "         ),
                new FreezeItem(41 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "A相正向有功电能 "      ),
                new FreezeItem(46 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "A相反向有功电能 "      ),
                new FreezeItem(51 ,  5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "A相第一象限无功电能 " ),
                new FreezeItem(56 ,  5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "A相第二象限无功电能 " ),
                new FreezeItem(61 ,  5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "A相第三象限无功电能 " ),
                new FreezeItem(66 ,  5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "A相第四象限无功电能 " ),
                new FreezeItem(71 ,  3, 3, "XXX.XXX      ",   "kWh  ",     "A相正向有功需量 "      ),
                new FreezeItem(74 ,  3, 3, "XXX.XXX      ",   "kWh  ",     "A相反向有功需量 "      ),
                new FreezeItem(77 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "B相正向有功电能 "      ),
                new FreezeItem(82 ,  5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "B相反向有功电能 "      ),
                new FreezeItem(87 ,  5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "B相第一象限无功电能 "  ),
                new FreezeItem(92 ,  5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "B相第二象限无功电能 "  ),
                new FreezeItem(97 ,  5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "B相第三象限无功电能 "  ),
                new FreezeItem(102 , 5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "B相第四象限无功电能 "  ),
                new FreezeItem(107 , 3, 3, "XXX.XXX      ",   "kWh  ",     "B相正向有功需量 "      ),
                new FreezeItem(110 , 3, 3, "XXX.XXX      ",   "kWh  ",     "B相反向有功电能 "      ),
                new FreezeItem(113 , 5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "C相正向有功电能 "      ),
                new FreezeItem(118 , 5, 2, "XXXXXXXX.XX  ",   "kWh  ",     "C相反向有功电能 "      ),
                new FreezeItem(123 , 5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "C相第一象限无功电能 "  ),
                new FreezeItem(128 , 5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "C相第二象限无功电能 "  ),
                new FreezeItem(133 , 5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "C相第三象限无功电能 "  ),
                new FreezeItem(138 , 5, 2, "XXXXXXXX.XX  ",   "kvarh ",      "C相第四象限无功电能 "  ),
                new FreezeItem(143 , 3, 3, "XXX.XXX      ",   "kWh  ",     "C相反向有功需量 "      ),
                new FreezeItem(146 , 3, 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            };
        }
    }
}