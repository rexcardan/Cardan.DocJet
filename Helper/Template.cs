using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Xml.Linq;
using Cardan.DocJet.Chart;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Helper
{
    /// <summary>
    ///     This reads the resource file and can pull content controls out by name to create "templates"
    /// </summary>
    public class Template
    {
        public static WmlDocument GetChartMasterTemplateWML()
        {
            var rm = new ResourceManager("Cardan.DocJet.Properties.Resources", Assembly.GetExecutingAssembly());
            var chartRes = (byte[]) rm.GetObject("charts");
            //Find template in resources and copy
            return new WmlDocument("charts.docx", chartRes);
        }

        public static IEnumerable<XElement> GetTemplate(string controlName)
        {
            var rm = new ResourceManager("Cardan.DocJet.Properties.Resources", Assembly.GetExecutingAssembly());
            var chartRes = (byte[]) rm.GetObject("charts");

            //Find template in resources and copy
            var source = new WmlDocument("charts.docx", chartRes);
            XElement control = source.GetContentControl(controlName);
            IEnumerable<XElement> content = control.Element(W.sdtContent).Elements();
            return content;
        }

        public static void SetChartSpaceTemplate(string controlName)
        {
            IEnumerable<XElement> content = GetTemplate(controlName);
            string chartId = content.Descendants(C.chart).First().Attribute(R.id).Value;
            using (
                WordprocessingDocument refDoc =
                    (new OpenXmlMemoryStreamDocument(GetChartMasterTemplateWML())).GetWordprocessingDocument())
            {
                var chart = (ChartPart) refDoc.MainDocumentPart.GetPartById(chartId);
                XDocument xdocChart = chart.GetXDocument();
                XElement chartSpaceTemplate = xdocChart.Element(C.chartSpace);
                XElement chartTemplate = chartSpaceTemplate != null ? chartSpaceTemplate.Element(C.chart) : null;
                XElement plotAreaTemplate = chartTemplate != null ? chartTemplate.Element(C.plotArea) : null;
                ValueAxis xAxis = plotAreaTemplate != null ? new XPlotArea(plotAreaTemplate).XAxis : null;
                ValueAxis yAxis = plotAreaTemplate != null ? new XPlotArea(plotAreaTemplate).YAxis : null;
                ValueAxis x2Axis = plotAreaTemplate != null ? new XPlotArea(plotAreaTemplate).X2Axis : null;
                ValueAxis y2Axis = plotAreaTemplate != null ? new XPlotArea(plotAreaTemplate).Y2Axis : null;

                XChartStyleTemplate.ChartSpaceStyle = xcs => ChartStyler.Style(xcs, chartSpaceTemplate);
                XChartStyleTemplate.ChartStyle = xc => ChartStyler.Style(xc, chartTemplate);
                XChartStyleTemplate.PlotAreaStyle = xp => ChartStyler.Style(xp, plotAreaTemplate);

                XChartStyleTemplate.XAxisStyle = va => ChartStyler.StyleAxis(va, xAxis);
                XChartStyleTemplate.YAxisStyle = va => ChartStyler.StyleAxis(va, yAxis);
                XChartStyleTemplate.X2AxisStyle = va => ChartStyler.StyleAxis(va, x2Axis, xAxis);
                XChartStyleTemplate.Y2AxisStyle = va => ChartStyler.StyleAxis(va, y2Axis, yAxis);

                XChartStyleTemplate.PrimarySeriesStyles = ChartStyler.GetPrimarySeriesStyles(plotAreaTemplate);
                XChartStyleTemplate.SecondarySeriesStyles = ChartStyler.GetSecondarySeriesStyles(plotAreaTemplate);
                XChartStyleTemplate.ChartColorStyleParts.Clear();
                XChartStyleTemplate.ChartStyleParts.Clear();

                //Copy Color and Style Parts
                chart.ChartColorStyleParts.ToList()
                    .ForEach(cc => XChartStyleTemplate.ChartColorStyleParts.Add(cc.GetXDocument()));
                chart.ChartStyleParts.ToList().ForEach(cc => XChartStyleTemplate.ChartStyleParts.Add(cc.GetXDocument()));
            }
        }
    }
}