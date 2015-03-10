using System.Xml.Linq;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Chart
{
    public class XMarker : JetElement
    {
        public XMarker() : base(C.marker)
        {
            Size = 5;
            Symbol = Symbols.Auto;
        }

        public XMarker(XElement marker) : base(marker)
        {
        }

        public int Size
        {
            get { return GetVal<int>(C.size); }
            set { SetVal(C.size, value); }
        }

        public Shape Shape
        {
            get { return new Shape(Get(C.spPr)); }
            set { Set(value); }
        }

        public Symbols Symbol
        {
            get { return GetEnumMappedVal<Symbols>(C.symbol); }
            set { SetEnumMappedVal(C.symbol, value); }
        }
    }
}