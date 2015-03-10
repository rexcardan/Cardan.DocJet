using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Chart
{
    public abstract class AbstractPlot : JetElement
    {
        public AbstractPlot(XName xname) : base(xname)
        {
        }

        public AbstractPlot(XElement el) : base(el)
        {
        }

        public string AxisId1
        {
            get { return GetVal(C.axId, 0); }
            set { SetVal(C.axId, value, 0); }
        }

        public string AxisId2
        {
            get { return GetVal(C.axId, 1); }
            set { SetVal(C.axId, value, 1); }
        }

        public bool IsSecondary { get; set; }

        public List<Series> Series
        {
            get { return GetAll<Series>(C.ser).ToList(); }
        }

        public static AbstractPlot Map(XElement el)
        {
            if (el == null)
            {
                return null;
            }
            if (el.Name == C.scatterChart)
            {
                return new XScatter(el);
            }
            return null;
        }

        public void AddSeries(string seriesName, DDataCollection data)
        {
            var s = new Series();
            ApplyCurrentStyle(s);
            s.Name = seriesName;
            s.Values = data;
            AddSeries(s);
        }

        public void AddSeries(Action<Series> customSeriesAction)
        {
            var s = new Series();
            ApplyCurrentStyle(s);
            customSeriesAction(s);
            AddSeries(s);
        }

        public void ApplyCurrentStyle()
        {
            foreach (Series ser in Series)
            {
                ApplyCurrentStyle(ser);
            }
        }

        private void ApplyCurrentStyle(Series s)
        {
            List<Action<Series>> styles = IsSecondary
                ? XChartStyleTemplate.SecondarySeriesStyles
                : XChartStyleTemplate.PrimarySeriesStyles;
            if (styles != null && styles.Count > Series.Count)
            {
                styles[s.Index](s);
            }
        }

        public void AddSeries(Series s)
        {
            if (Series.Count() == 0)
            {
                Add(s);
            }
            else
            {
                Series.Last().AddAfterSelf(s);
            }
            if (WrappedElement.Parent != null && WrappedElement.Parent.Name == C.plotArea)
            {
                new XPlotArea(WrappedElement.Parent).UpdateSeriesIdsAndOrder();
            }
        }
    }
}