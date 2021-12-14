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
        private static List<FreezeItem> CreateFreezeItemList(int blockNo)
        {
            List<FreezeItem> items = null;
            if(blockNo == 1)
            {
                items = new List<FreezeItem>
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
            else if(blockNo == 2)
            {
                items = new List<FreezeItem>()
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
            }
            return items;
        }
        public byte[] ClientReadFormTime(MeterAddress address, DataId dataId, byte[] dataArray)
        {
            int cnt = 5;
            byte[] array = null;
            
            while(cnt > 0)
            {
                try
                {
                    array = client.Read(address, dataId, dataArray);
                    break;
                }
                catch (TimeoutException)
                {
                    cnt--;
                    if(cnt == 0)
                    {
                        throw;
                    }
                }
            }
            return array;
        }
        public FreezeDataBlock CreateFreezeDataBlock (int blockNo)
        {
             FreezeDataBlock block = null;
             if(blockNo == 1)
             {
                block = new FreezeDataBlock(1, 149, 0xA2F00003, CreateFreezeItemList(blockNo));
             }
             else if(blockNo == 2)
             {
                block = new FreezeDataBlock(2, 69, 0xA2F00004, CreateFreezeItemList(blockNo));
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
        public FreezeDataBlock ReadFreezeDataFromCntBlk(int cnt, int blockNo)
        {
            if((cnt == 0) 
            || (cnt > FreezeDataBlockCnt) 
            || (blockNo > FreezeMaxCnt)
            || (blockNo == 0))
            {
                throw new InvalidOperationException("cnt = ${cnt}, blockNo = ${blockNo}");
            }
            
            DataId dataId = new DataId();
            FreezeDataBlock block = this.CreateFreezeDataBlock(blockNo);
            dataId.Id = (uint)((uint)0xA20000FF + (blockNo << 20) + (cnt << 8));
            block.ByteArray = client.Read(address, dataId);
            block.ByteArrayConvetToItemList();
            return block;
        }

        public FreezeDataBlock ReadFreezeDataFromCntOnce(int cnt, int blockNo)
        {
            if((cnt == 0) 
            || (cnt > FreezeDataBlockCnt) 
            || (blockNo > FreezeMaxCnt)
            || (blockNo == 0))
            {
                throw new InvalidOperationException("cnt = ${cnt}, blockNo = ${blockNo}");
            }
            DataId dataId = new DataId();
            FreezeDataBlock block = CreateFreezeDataBlock(blockNo);
            dataId.Id = (uint)(0xA2000000 + ((uint)blockNo << 20) + (cnt << 8));
            block.ByteArray = client.Read(address, dataId);
            for (int j = 0; j < block.ItemList.Count; j++)
            {
                dataId.Id = (uint)(0xA2000000 + ((uint)blockNo << 20) + (cnt << 8) + (j + 1));
                byte[] arrayTmp = client.Read(address, dataId);
                byte[] decArray = new byte[block.ByteArray.Length + arrayTmp.Length];
                Array.Copy(block.ByteArray, decArray, block.ByteArray.Length);
                Array.Copy(arrayTmp, 0, decArray, block.ByteArray.Length, arrayTmp.Length);
                block.ByteArray = decArray;
            }
            block.ByteArrayConvetToItemList();
            return block;
        }

        public FreezeDataBlock ReadFreezeDataFromTime(DateTime time, int blockNo)
        {
            if((blockNo > FreezeMaxCnt)
            || (blockNo == 0))
            {
                throw new InvalidOperationException("cnt = ${time}, blockNo = ${blockNo}");
            }
            DataId dataId = new DataId();
            FreezeDataBlock block = CreateFreezeDataBlock(blockNo);
            dataId.Id = block.TimeReadDataId;
            byte[] array = new byte[6];
            array[5] = PublicClass.ByteHex2Bcd((byte)((time.Year % 100)));//(byte)((((byte)(((start.Year % 100)) / 10)) << 4) | (((byte)(((start.Year % 100)) % 10))));
            array[4] = PublicClass.ByteHex2Bcd((byte)(time.Month       ));//(byte)((((byte)((start.Month       ) / 10)) << 4) | (((byte)((start.Month       ) % 10))));
            array[3] = PublicClass.ByteHex2Bcd((byte)(time.Day         ));//(byte)((((byte)((start.Day         ) / 10)) << 4) | (((byte)((start.Day         ) % 10))));
            array[2] = PublicClass.ByteHex2Bcd((byte)(time.Hour        ));//(byte)((((byte)((start.Hour        ) / 10)) << 4) | (((byte)((start.Hour        ) % 10))));
            array[1] = PublicClass.ByteHex2Bcd((byte)(time.Minute      ));//(byte)((((byte)((start.Minute      ) / 10)) << 4) | (((byte)((start.Minute      ) % 10))));
            array[0] = (byte)1;
            block.ByteArray = ClientReadFormTime(MeterAddress.Wildcard, dataId, array);
            block.ByteArrayConvetToItemList();
            return block;
        }
    }
}