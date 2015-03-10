using System.Xml.Linq;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Chart
{
    public class XChartSpace : JetElement
    {
        public XChartSpace()
            : base(C.chartSpace)
        {
            IsDate1904 = false;
            EditingLanguage = "en-US";
            IsRoundedCorners = false;
            Chart = new XChart();
            ApplyCurrentStyle();
        }

        public XChartSpace(XElement chartSpace)
            : base(chartSpace)
        {
        }

        public bool IsDate1904
        {
            get { return GetVal(C.date1904) == "1"; }
            set { SetVal(C.date1904, value ? 1 : 0); }
        }

        public string EditingLanguage
        {
            get { return GetVal(C.lang); }
            set { SetVal(C.lang, value); }
        }

        public bool IsRoundedCorners
        {
            get { return GetVal(C.roundedCorners) == "1"; }
            set { SetVal(C.roundedCorners, value ? 1 : 0); }
        }

        public XChart Chart
        {
            get { return new XChart(Get(C.chart)); }
            set { Set(value); }
        }

        public void ApplyCurrentStyle()
        {
            if (XChartStyleTemplate.ChartSpaceStyle != null)
            {
                XChartStyleTemplate.ChartSpaceStyle(this);
            }
            Chart.ApplyCurrentStyle();
        }
    }
}