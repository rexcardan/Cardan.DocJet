using System.Xml.Linq;
using Cardan.DocJet.Maps;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Chart
{
    public class Scaling : JetElement
    {
        public Scaling() : base(C.scaling)
        {
        }

        public Scaling(XElement el) : base(el)
        {
        }

        public Orientations Orientation
        {
            get { return GetVal<Orientations>(C.orientation); }
            set { SetVal(C.orientation, value); }
        }

        public double Minimum
        {
            get { return GetVal<double>(C.min); }
            set { SetVal(C.min, value); }
        }

        public double Maximum
        {
            get { return GetVal<double>(C.max); }
            set { SetVal(C.max, value); }
        }
    }
}