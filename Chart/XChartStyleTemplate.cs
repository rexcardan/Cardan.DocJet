using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Cardan.DocJet.Chart
{
    public static class XChartStyleTemplate
    {
        public static List<XDocument> ChartColorStyleParts = new List<XDocument>();
        public static List<XDocument> ChartStyleParts = new List<XDocument>();
        public static Action<XChartSpace> ChartSpaceStyle { get; set; }
        public static Action<XChart> ChartStyle { get; set; }
        public static Action<XPlotArea> PlotAreaStyle { get; set; }
        public static List<Action<Series>> PrimarySeriesStyles { get; set; }
        public static List<Action<Series>> SecondarySeriesStyles { get; set; }
        public static Action<ValueAxis> XAxisStyle { get; set; }
        public static Action<ValueAxis> YAxisStyle { get; set; }
        public static Action<ValueAxis> X2AxisStyle { get; set; }
        public static Action<ValueAxis> Y2AxisStyle { get; set; }
    }
}