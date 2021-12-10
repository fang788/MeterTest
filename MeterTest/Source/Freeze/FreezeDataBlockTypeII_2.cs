using System;
using System.Collections.Generic;
using MeterTest.Source.Dlt645;

namespace MeterTest.Source.Freeze
{
    public class FreezeDataBlockTypeII_2 : FreezeDataBlock
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
        private static List<FreezeItem> ItemCreate()
        {
            List<FreezeItem> itemList = new List<FreezeItem>()
            {
                new FreezeItem(5  , 2, 1,"XXX.X        ",   "V    ",   "A相电压 "              ),
                new FreezeItem(7  , 2, 1,"XXX.X        ",   "V    ",   "B相电压 "              ),
                new FreezeItem(9  , 2, 1,"XXX.X        ",   "V    ",   "C相电压 "              ),
                new FreezeItem(11 , 3, 3,"XXX.XXX      ",   "A    ",   "A相电流 "              ),
                new FreezeItem(14 , 3, 3,"XXX.XXX      ",   "A    ",   "B相电流 "              ),
                new FreezeItem(17 , 3, 3,"XXX.XXX      ",   "A    ",   "C相电流 "              ),
                new FreezeItem(20 , 3, 3,"XXX.XXX      ",   "kW   ",    "瞬时总有功功率 "       ),
                new FreezeItem(23 , 3, 3,"XXX.XXX      ",   "kW   ",    "瞬时A相有功功率 "      ),
                new FreezeItem(26 , 3, 3,"XXX.XXX      ",   "kW   ",    "瞬时B相有功功率 "      ),
                new FreezeItem(29 , 3, 3,"XXX.XXX      ",   "kW   ",    "瞬时C相有功功率 "      ),
                new FreezeItem(32 , 3, 3,"XXX.XXX      ",   "kvar ",      "瞬时无功功率 "         ),
                new FreezeItem(35 , 3, 3,"XXX.XXX      ",   "kvar ",      "瞬时A相无功功率 "      ),
                new FreezeItem(38 , 3, 3,"XXX.XXX      ",   "kvar ",      "瞬时B相无功功率 "      ),
                new FreezeItem(41 , 3, 3,"XXX.XXX      ",   "kvar ",      "瞬时C相无功功率 "      ),
                new FreezeItem(44 , 3, 3,"XXX.XXX      ",   "kVA  ",     "瞬时视在总功率 "       ),
                new FreezeItem(47 , 3, 3,"XXX.XXX      ",   "kVA  ",     "瞬时A相视在功率 "      ),
                new FreezeItem(50 , 3, 3,"XXX.XXX      ",   "kVA  ",     "瞬时B相视在功率 "      ),
                new FreezeItem(53 , 3, 3,"XXX.XXX      ",   "kVA  ",     "瞬时C相视在功率 "      ),
                new FreezeItem(56 , 3, 3,"XXX.XXX      ",   "A    ",   "零线（序)电流 "        ),
                new FreezeItem(59 , 2, 2,"XX.XX        ",   "Hz   ",    "频率 "                ),
                new FreezeItem(61 , 3, 4,"XX.XXXX      ",   "kW   ",    "有功需量 "            ),
                new FreezeItem(64 , 2, 1,"XXX.X        ",   "℃   " ,  "（表箱）表内温度 "      ),
                new FreezeItem(66 , 3, 3,"XXX.XXX      ",   "     ",    "剩余电流 "            ),
            };
            return itemList;
        }
        public FreezeDataBlockTypeII_2()
        {
            No = 2;
            Bytes = 69;
            ItemList = ItemCreate();
            TimeReadDataId = 0xA2F00004;
        }
    }
}