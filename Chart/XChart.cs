using System;
using Cardan.DocJet.Maps;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;
using X = System.Xml.Linq.XElement;
using XA = System.Xml.Linq.XAttribute;

namespace Cardan.DocJet.Chart
{
    public class XChart : JetElement
    {
        public XChart()
            : base(C.chart)
        {
            PlotArea = new XPlotArea();
            IsOnlyPlotVisibile = true;
            ShowDataLabelsOverMaximum = false;
            DisplayBlankAs = DisplayBlankOptions.Gap;
            ApplyCurrentStyle();
        }

        public XChart(X xchart) : base(xchart)
        {
        }

        public string Title
        {
            get
            {
                X title = GetAfter(WrappedElement.Element(C.title), C.tx, A.t);
                return title != null ? title.Value : string.Empty;
            }
            set
            {
                X title = GetAfter(WrappedElement.Element(C.title), C.tx, A.t);
                if (title != null)
                {
                    title.Value = value;
                }
                else
                {
                    var titleEl = new X(C.title,
                        new X(C.tx, new X(C.rich, new X(A.bodyPr), new X(A.p, new X(A.r, new X(A.t, value))))));
                    WrappedElement.Add(titleEl);
                }
            }
        }

        public bool IsTitleVisible
        {
            get { return GetVal(C.autoTitleDeleted) == "1"; }
            set { SetVal(C.autoTitleDeleted, value ? 1 : 0); }
        }

        public XPlotArea PlotArea
        {
            get { return Get<XPlotArea>(C.plotArea); }
            set { Set(value); }
        }

        public bool IsOnlyPlotVisibile
        {
            get { return GetVal(C.plotVisOnly) == "1"; }
            set { SetVal(C.plotVisOnly, value ? 1 : 0); }
        }

        public DisplayBlankOptions DisplayBlankAs
        {
            get { return GetVal<DisplayBlankOptions>(C.dispBlanksAs); }
            set { SetVal(C.dispBlanksAs, value); }
        }

        public bool ShowDataLabelsOverMaximum
        {
            get { return GetVal(C.showDLblsOverMax) == "1"; }
            set { SetVal(C.showDLblsOverMax, value ? 1 : 0); }
        }

        public void ApplyCurrentStyle()
        {
            if (XChartStyleTemplate.ChartStyle != null)
            {
                XChartStyleTemplate.ChartStyle(this);
            }
            PlotArea.ApplyCurrentStyle();
        }

        public void AddSecondary<T>(Action<T> secondaryAction) where T : AbstractPlot
        {
            PlotArea.SecondaryPlot = Activator.CreateInstance<T>();
            secondaryAction((T) PlotArea.SecondaryPlot);
        }
    }
}