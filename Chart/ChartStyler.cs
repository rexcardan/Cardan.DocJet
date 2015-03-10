using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Chart
{
    public static class ChartStyler
    {
        public static void Style(ChartPart cPart)
        {
            //Copy Color and Style Parts
            XChartStyleTemplate.ChartColorStyleParts.ToList().ForEach(cc =>
            {
                var cp = cPart.AddNewPart<ChartColorStylePart>();
                cp.PutXDocument(cc);
            });
            XChartStyleTemplate.ChartStyleParts.ToList().ForEach(cc =>
            {
                var cp = cPart.AddNewPart<ChartStylePart>();
                cp.PutXDocument(cc);
            });
        }

        public static void Style(XChartSpace chartSpace, XElement templateChartSpace)
        {
            // Copy shape properties
            if (templateChartSpace.Element(C.spPr) != null)
            {
                chartSpace.ReplaceOrAdd(templateChartSpace.Element(C.spPr));
            }
            if (templateChartSpace.Element(C.spPr) != null)
            {
                chartSpace.ReplaceOrAdd(templateChartSpace.Element(C.txPr));
            }
        }

        public static void Style(XChart chart, XElement templateChart)
        {
            if (chart != null)
            {
                //Update ChartTitle
                string title = chart.Title; //Store temporarily
                if (templateChart != null)
                {
                    XElement templateTitle = templateChart.Element(C.title);
                    if (templateTitle != null)
                    {
                        chart.ReplaceOrAdd(templateTitle);
                        chart.Title = title;
                    }
                    var templateXChart = new XChart(templateChart);
                    chart.IsTitleVisible = templateXChart.IsTitleVisible;
                }
                //Copy legend
                chart.ReplaceOrAdd(templateChart.Element(C.legend));
            }
        }

        public static void Style(XPlotArea xPlotArea, XElement templatePlotArea)
        {
            if (templatePlotArea != null)
            {
                //Layout - For manual layouts
                xPlotArea.ReplaceOrAdd(templatePlotArea.Element(C.layout));
                //ShapeProps
                XElement spPr = templatePlotArea.Element(C.spPr);
                xPlotArea.ReplaceOrAdd(spPr);
            }
        }

        public static void StyleAxis(ValueAxis axis, ValueAxis templateAxis, ValueAxis primaryAxisTemplate = null)
        {
            if (axis != null)
            {
                ///Style relevant parts from axes
                if (templateAxis != null)
                {
                    axis.Shape = templateAxis.Shape;
                    axis.ReplaceRemoveOrAdd(C.majorGridlines, templateAxis.WrappedElement.Element(C.majorGridlines));
                    axis.ReplaceRemoveOrAdd(C.minorGridlines, templateAxis.WrappedElement.Element(C.minorGridlines));
                    axis.ReplaceRemoveOrAdd(C.majorTickMark, templateAxis.WrappedElement.Element(C.majorTickMark));
                    axis.ReplaceRemoveOrAdd(C.minorTickMark, templateAxis.WrappedElement.Element(C.minorTickMark));
                    axis.ReplaceRemoveOrAdd(C.tickLblPos, templateAxis.WrappedElement.Element(C.tickLblPos));
                    axis.ReplaceOrAdd(templateAxis.WrappedElement.Element(C.delete));
                    string title = axis.Title;
                    axis.ReplaceOrAdd(templateAxis.WrappedElement.Element(C.title));
                    axis.Title = title;
                    axis.ReplaceRemoveOrAdd(C.spPr, templateAxis.WrappedElement.Element(C.spPr));
                    axis.ReplaceRemoveOrAdd(C.txPr, templateAxis.WrappedElement.Element(C.txPr));
                }
                else if (primaryAxisTemplate != null)
                {
                    axis.ReplaceRemoveOrAdd(C.tickLblPos, primaryAxisTemplate.WrappedElement.Element(C.tickLblPos));
                    string title = axis.Title;
                    axis.ReplaceOrAdd(primaryAxisTemplate.WrappedElement.Element(C.title));
                    axis.Title = title;
                    axis.ReplaceRemoveOrAdd(C.spPr, primaryAxisTemplate.WrappedElement.Element(C.spPr));
                    axis.ReplaceRemoveOrAdd(C.txPr, primaryAxisTemplate.WrappedElement.Element(C.txPr));
                }
            }
        }

        public static List<Action<Series>> GetPrimarySeriesStyles(XElement templatePlotArea)
        {
            if (templatePlotArea != null)
            {
                var xTempPlotArea = new XPlotArea(templatePlotArea);
                if (xTempPlotArea.PrimaryPlot != null)
                {
                    return xTempPlotArea.PrimaryPlot.Series.Select(s =>
                    {
                        Action<Series> action = ser =>
                        {
                            ser.Marker = s.Marker;
                            ser.IsSmooth = s.IsSmooth;
                            ser.Shape = s.Shape;
                        };
                        return action;
                    }).ToList();
                }
            }
            return new List<Action<Series>>();
        }

        public static List<Action<Series>> GetSecondarySeriesStyles(XElement templatePlotArea)
        {
            if (templatePlotArea != null)
            {
                var xTempPlotArea = new XPlotArea(templatePlotArea);
                if (xTempPlotArea.SecondaryPlot != null)
                {
                    return xTempPlotArea.SecondaryPlot.Series.Select(s =>
                    {
                        Action<Series> action = ser =>
                        {
                            ser.Marker = s.Marker;
                            ser.IsSmooth = s.IsSmooth;
                        };
                        return action;
                    }).ToList();
                }
            }
            return new List<Action<Series>>();
        }
    }
}