using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MeterTest.Source.Freeze
{
    public class FreezeLineChart
    {
        private static readonly List<LinearAxisLeft> leftList = new List<LinearAxisLeft>()
        {
            new LinearAxisLeft("电压",      0, 0, "F1"     , "V"),
            new LinearAxisLeft("电流",      0, 0, "F3"     , "A"),
            new LinearAxisLeft("有功功率",   0, 0, "F4"    , "kW"),
            new LinearAxisLeft("无功功率",   0, 0, "F4"    , "kVA"),
            new LinearAxisLeft("视在功率",   0, 0, "F4"    , "kVAR"),
            new LinearAxisLeft("功率因数",   0, 0, "F3"    , ""),
            new LinearAxisLeft("频率",       0, 0, "F2"    , "Hz"),
            new LinearAxisLeft("正向有功电能",  0, 0, "F2" , "kWh"),
            new LinearAxisLeft("反向有功电能",  0, 0, "F2" , "kWh"),
            new LinearAxisLeft("正向无功电能",  0, 0, "F2" , "kVAh"),
            new LinearAxisLeft("反向无功电能",  0, 0, "F2" , "kVAh"),
        };
        private PlotModel model;
        private DateTimeAxis bottom;
        public LinearAxis   left;
        public Dictionary<string, LineSeries>   lineDict = new Dictionary<string, LineSeries>();
        //private string       type;
        public FreezeLineChart(PlotModel model, DateTimeAxis bottom, LinearAxis left, string type)
        {
            this.model = model;
            this.bottom = bottom;
            this.left = left;
            this.model.Axes.Add(bottom);
            this.model.Axes.Add(left);
        }
        public void AddLineSeries(LineSeries lineSeries)
        {
            model.Series.Add(lineSeries);
        }
        public static LinearAxis GetLinearAxis(string s)
        {
            LinearAxis linearAxis = null;
            foreach (var item in leftList)
            {
                if(item.Name == s)
                {
                    linearAxis = new LinearAxis
                    { 
                        Position = AxisPosition.Left, 
                        Minimum = item.Minimum, 
                        Maximum = item.Maximum, 
                        StringFormat = item.StringFormat,
                        IsZoomEnabled = false,
                        IsPanEnabled =  false,
                        FractionUnit = 1.0,
                        FractionUnitSymbol = null,
                        FormatAsFractions = false,
                        Title = item.Name + " <"+ item.Unit + ">",
                    };
                }
            }
            if(linearAxis == null)
            {
                throw new System.Exception("linearAxis == null");
            }
            return linearAxis;
        }
        public void SetBottomMin(DateTime min)
        {
            this.model.Axes[0].Minimum = DateTimeAxis.ToDouble(min);
        }
        public void SetBottomMax(DateTime max)
        {
            this.model.Axes[0].Maximum = DateTimeAxis.ToDouble(max);
        }
        public void DisplayFreezeData(string type, FreezeData data)
        {
            LineSeries line;
            foreach (var item in data.ValueDic)
            {
                if((item.Key.Contains(type)) && (!lineDict.ContainsKey(item.Key)))
                {
                    line = new LineSeries();
                    if(item.Key.Contains("A"))
                    {
                        line.Color = OxyColors.DarkOrange;
                    }
                    else if(item.Key.Contains("B"))
                    {
                        line.Color = OxyColors.Blue;
                    }
                    else if(item.Key.Contains("C"))
                    {
                        line.Color = OxyColors.Red;
                    }
                    else if(item.Key.Contains("总"))
                    {
                        line.Color = OxyColors.Black;
                    }
                    else
                    {
                        line.Color = OxyColors.LightGreen;
                    }
                    lineDict.Add(item.Key, line);
                    this.model.Series.Add(line);
                    left.Minimum = item.Value * 0.9;
                    left.Maximum = item.Value / 0.9;
                }
                if(lineDict.TryGetValue(item.Key, out line))
                {
                    line.Points.Add(new DataPoint(DateTimeAxis.ToDouble(data.Time), item.Value));
                    if(bottom.Maximum < DateTimeAxis.ToDouble(data.Time))
                    {
                        bottom.Maximum = DateTimeAxis.ToDouble(data.Time);
                    }
                    if(bottom.Minimum > DateTimeAxis.ToDouble(data.Time))
                    {
                        bottom.Minimum = DateTimeAxis.ToDouble(data.Time);
                    }
                    double max = GetYMax();
                    double min = GetMin();
                    if((left.Maximum != (max + (max - min) * 0.1))
                    || (left.Minimum != (min - (max - min) * 0.1)))
                    {
                        if(min != max)
                        {
                            left.Maximum = max + (max - min) * 0.1;
                            left.Minimum = min - (max - min) * 0.1; //max + (max - min) * 0.1;
                        }
                        else
                        {
                            left.Maximum = max * 1.01;
                            left.Minimum = min * 0.99; //max + (max - min) * 0.1;
                        }
                        left.FractionUnit = (left.Maximum - left.Minimum) / 20;
                    }
                }
            }
        }
        private double GetMin()
        {
            double min = 0;
            bool first = true;
            foreach (var item in lineDict)
            {
                foreach (var data in item.Value.Points)
                {
                    if(first)
                    {
                        min = data.Y;
                        first = false;
                    }
                    if(data.Y < min)
                    {
                        min = data.Y;
                    }
                }
            }
            return min;
        }

        private double GetYMax()
        {
            double max = 0;
            bool first = true;
            foreach (var item in lineDict)
            {
                foreach (var data in item.Value.Points)
                {
                    if(first)
                    {
                        max = data.Y;
                        first = false;
                    }
                    if(data.Y > max)
                    {
                        max = data.Y;
                    }
                }
            }
            return max;
        }
        public void ChangeDisplayLine(string type, List<FreezeData> freezeDataList)
        {
            if((freezeDataList == null) || (freezeDataList.Count == 0))
            {
                return;
            }
            foreach (var item in lineDict)
            {
                if(!item.Key.Contains(type))
                {
                    this.model.Series.Remove(item.Value);
                    lineDict.Remove(item.Key);
                }
            }
            foreach (FreezeData item in freezeDataList)
            {
                foreach (var data in item.ValueDic)
                {
                    LineSeries line;
                    if(data.Key.Contains(type) && (!lineDict.ContainsKey(data.Key)))
                    {
                        line = new LineSeries();
                        if(data.Key.Contains("A"))
                        {
                            line.Color = OxyColors.Yellow;
                        }
                        else if(data.Key.Contains("B"))
                        {
                            line.Color = OxyColors.Blue;
                        }
                        else if(data.Key.Contains("C"))
                        {
                            line.Color = OxyColors.Red;
                        }
                        else if(data.Key.Contains("总"))
                        {
                            line.Color = OxyColors.Black;
                        }
                        else
                        {
                            line.Color = OxyColors.LightGreen;
                        }
                        lineDict.Add(data.Key, line);
                        this.model.Series.Add(line);
                    }
                    if(lineDict.TryGetValue(data.Key, out line))
                    {
                        line.Points.Add(new DataPoint(DateTimeAxis.ToDouble(item.Time), data.Value));
                    }
                }
            }
        }
    }
    public class LinearAxisLeft
    {
        public string Name;
        public double Minimum;
        public double Maximum;
        public string StringFormat;
        public string Unit;

        public LinearAxisLeft(string name, double minimum, double maximum, string stringFormat)
        {
            Name = name;
            Minimum = minimum;
            Maximum = maximum;
            StringFormat = stringFormat;
        }

        public LinearAxisLeft(string name, double minimum, double maximum, string stringFormat, string unit) : this(name, minimum, maximum, stringFormat)
        {
            Unit = unit;
        }
    }
}