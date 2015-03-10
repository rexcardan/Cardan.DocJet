using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cardan.DocJet.Maps;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Chart
{
    public class XScatter : AbstractPlot
    {
        public XScatter() : base(C.scatterChart)
        {
            ScatterStyle = ScatterStyles.LineWithMarkers;
        }

        public XScatter(XElement el) : base(el)
        {
        }

        public ScatterStyles ScatterStyle
        {
            get { return GetVal<ScatterStyles>(C.scatterStyle); }
            set { SetVal(C.scatterStyle, value); }
        }

        public IEnumerable<Series> Series
        {
            get { return WrappedElement.Descendants(C.ser).Select(s => new Series(s)); }
        }
    }
}