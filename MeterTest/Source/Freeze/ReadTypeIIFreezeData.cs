using System;
using System.Collections.Generic;

namespace MeterTest.Source.Freeze
{
    public class ReadTypeIIFreezeData : IReadFreezeData
    {
        public List<FreezeItem> FreezeItemBlk1List = new List<FreezeItem>
        {
            new FreezeItem(5  , 5, "XXXXXXXX.XX  ",   "kWh  ",     "正向有功总电能 "       ),
            new FreezeItem(10 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "反向有功总电能 "       ),
            new FreezeItem(15 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "第一象限无功电能 "     ),
            new FreezeItem(20 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "第二象限无功电能 "     ),
            new FreezeItem(25 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "第三象限无功电能 "     ),
            new FreezeItem(30 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "第四象限无功电能 "     ),
            new FreezeItem(35 , 3, "XXX.XXX      ",   "kW   ",    "正向有功需量 "         ),
            new FreezeItem(38 , 3, "XXX.XXX      ",   "kW   ",    "反向有功需量 "         ),
            new FreezeItem(41 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "A相正向有功电能 "      ),
            new FreezeItem(46 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "A相反向有功电能 "      ),
            new FreezeItem(51 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "A相第一象限无功电能 " ),
            new FreezeItem(56 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "A相第二象限无功电能 " ),
            new FreezeItem(61 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "A相第三象限无功电能 " ),
            new FreezeItem(66 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "A相第四象限无功电能 " ),
            new FreezeItem(71 , 3, "XXX.XXX      ",   "kWh  ",     "A相正向有功需量 "      ),
            new FreezeItem(74 , 3, "XXX.XXX      ",   "kWh  ",     "A相反向有功需量 "      ),
            new FreezeItem(77 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "B相正向有功电能 "      ),
            new FreezeItem(82 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "B相反向有功电能 "      ),
            new FreezeItem(87 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "B相第一象限无功电能 "  ),
            new FreezeItem(92 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "B相第二象限无功电能 "  ),
            new FreezeItem(97 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "B相第三象限无功电能 "  ),
            new FreezeItem(102 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "B相第四象限无功电能 "  ),
            new FreezeItem(107 , 3, "XXX.XXX      ",   "kWh  ",     "B相正向有功需量 "      ),
            new FreezeItem(110 , 3, "XXX.XXX      ",   "kWh  ",     "B相反向有功电能 "      ),
            new FreezeItem(113 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "C相正向有功电能 "      ),
            new FreezeItem(118 , 5, "XXXXXXXX.XX  ",   "kWh  ",     "C相反向有功电能 "      ),
            new FreezeItem(123 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "C相第一象限无功电能 "  ),
            new FreezeItem(128 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "C相第二象限无功电能 "  ),
            new FreezeItem(133 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "C相第三象限无功电能 "  ),
            new FreezeItem(138 , 5, "XXXXXXXX.XX  ",   "kvarh ",      "C相第四象限无功电能 "  ),
            new FreezeItem(143 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(146 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(149 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(152 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(155 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(158 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(161 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(164 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(167 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(170 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(173 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
            new FreezeItem(176 , 3, "XXX.XXX      ",   "kWh  ",     "C相正向有功需量 "      ),
        };
        public List<FreezeItem> FreezeItemBlk2List = new List<FreezeItem>
        {        
            new FreezeItem(5  , 2, "XXX.X        ",   "V    ",   "A相电压 "              ),
            new FreezeItem(7  , 2, "XXX.X        ",   "V    ",   "B相电压 "              ),
            new FreezeItem(9  , 2, "XXX.X        ",   "V    ",   "C相电压 "              ),
            new FreezeItem(11 , 3, "XXX.XXX      ",   "A    ",   "A相电流 "              ),
            new FreezeItem(14 , 3, "XXX.XXX      ",   "A    ",   "B相电流 "              ),
            new FreezeItem(17 , 3, "XXX.XXX      ",   "A    ",   "C相电流 "              ),
            new FreezeItem(20 , 3, "XXX.XXX      ",   "kW   ",    "瞬时总有功功率 "       ),
            new FreezeItem(23 , 3, "XXX.XXX      ",   "kW   ",    "瞬时A相有功功率 "      ),
            new FreezeItem(26 , 3, "XXX.XXX      ",   "kW   ",    "瞬时B相有功功率 "      ),
            new FreezeItem(29 , 3, "XXX.XXX      ",   "kW   ",    "瞬时C相有功功率 "      ),
            new FreezeItem(32 , 3, "XXX.XXX      ",   "kvar ",      "瞬时无功功率 "         ),
            new FreezeItem(35 , 3, "XXX.XXX      ",   "kvar ",      "瞬时A相无功功率 "      ),
            new FreezeItem(38 , 3, "XXX.XXX      ",   "kvar ",      "瞬时B相无功功率 "      ),
            new FreezeItem(41 , 3, "XXX.XXX      ",   "kvar ",      "瞬时C相无功功率 "      ),
            new FreezeItem(44 , 3, "XXX.XXX      ",   "kVA  ",     "瞬时视在总功率 "       ),
            new FreezeItem(47 , 3, "XXX.XXX      ",   "kVA  ",     "瞬时A相视在功率 "      ),
            new FreezeItem(50 , 3, "XXX.XXX      ",   "kVA  ",     "瞬时B相视在功率 "      ),
            new FreezeItem(53 , 3, "XXX.XXX      ",   "kVA  ",     "瞬时C相视在功率 "      ),
            new FreezeItem(56 , 3, "XXX.XXX      ",   "A    ",   "零线（序)电流 "        ),
            new FreezeItem(59 , 2, "XX.XX        ",   "Hz   ",    "频率 "                ),
            new FreezeItem(61 , 3, "XX.XXXX      ",   "kW   ",    "有功需量 "            ),
            new FreezeItem(64 , 2, "XXX.X        ",   "℃   " ,  "（表箱）表内温度 "      ),
            new FreezeItem(66 , 3, "XXX.XXX      ",   "     ",    "剩余电流 "            ),
        };
        
        public List<FreezeDataBlock> ReadFreezeDataFromCntBlk(int cnt, int blockNo)
        {
            throw new NotImplementedException();
        }

        public List<FreezeDataBlock> ReadFreezeDataFromCntOnce(int cnt, int blockNo)
        {
            throw new NotImplementedException();
        }

        public List<FreezeDataBlock> ReadFreezeDataFromTime(DateTime start, DateTime end, int time, int blockNo)
        {
            throw new NotImplementedException();
        }
    }
}