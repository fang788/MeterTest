using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace MeterTest.Source.Test
{
    public class FreezeLineChart
    {
        private static readonly List<LinearAxisLeft> leftList = new List<LinearAxisLeft>()
        {
            new LinearAxisLeft("电压",  0, 420, "F1"),
            new LinearAxisLeft("电流",  0, 200, "F3"),
        };
        private PlotModel model;
        private DateTimeAxis bottom;
        private LinearAxis   left;
        private LineSeries   line;
        public FreezeLineChart(PlotModel model, DateTimeAxis bottom, LinearAxis left)
        {
            this.model = model;
            this.bottom = bottom;
            this.left = left;
            this.model.Axes.Add(bottom);
            this.model.Axes.Add(left);
        }
        // public FreezeLineChart(PlotModel model)
        // {
        //     this.model = model;
        //     this.bottom = ;
        //     this.left = left;
        //     this.model.Axes.Add(bottom);
        //     this.model.Axes.Add(left);
        // }
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
                    linearAxis = new LinearAxis{ Position = AxisPosition.Left, Minimum = item.Minimum, Maximum = item.Maximum, StringFormat = item.StringFormat};
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
            bottom.Minimum = DateTimeAxis.ToDouble(min);
        }
        public void SetBottomMax(DateTime max)
        {
            bottom.Maximum = DateTimeAxis.ToDouble(max);
        }
        public void DisplayFreezeData(string type, FreezeData data)
        {

        }
    }
    public class LinearAxisLeft
    {
        public string Name;
        public double Minimum;
        public double Maximum;
        public string StringFormat;

        public LinearAxisLeft(string name, double minimum, double maximum, string stringFormat)
        {
            Name = name;
            Minimum = minimum;
            Maximum = maximum;
            StringFormat = stringFormat;
        }
    }
}