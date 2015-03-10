using System.Xml.Linq;
using Cardan.DocJet.Maps;
using OpenXmlPowerTools;

namespace Cardan.DocJet.XML
{
    public class Outline : JetElement
    {
        public Outline() : base(A.ln)
        {
        }

        public Outline(XElement el) : base(el)
        {
        }

        public int Width
        {
            get { return int.Parse(WrappedElement.Attribute("w").Value); }
            set { WrappedElement.SetAttributeValue("w", value); }
        }

        public CompoundLineTypes CompoundLineType
        {
            get { return GetAttr<CompoundLineTypes>("cmpd"); }
            set { SetAttr("cmpd", value); }
        }

        public LineCaps LineCap
        {
            get { return GetAttr<LineCaps>("cap"); }
            set { SetAttr("cap", value); }
        }
    }
}