using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.XML
{
    public class XStdRun : JetElement
    {
        public XStdRun() : base(W.sdt)
        {
        }

        public XStdRun(XElement el) : base(el)
        {
        }

        public string Tag
        {
            get { return GetFirstMatchDescendantAttVal(W.val, W.sdtPr, W.tag); }
            set { SetFirstMatchDescendantAttVal(W.val, value, W.sdtPr, W.tag); }
        }

        public string Alias
        {
            get { return GetFirstMatchDescendantAttVal(W.val, W.sdtPr, W.alias); }
            set { SetFirstMatchDescendantAttVal(W.val, value, W.sdtPr, W.alias); }
        }

        public string Value
        {
            get { return GetFirstMatchDescendantInnerXML(W.sdtContent, W.r, W.t); }
            set { SetFirstMatchDescendantInnerXML(value, W.sdtContent, W.r, W.t); }
        }
    }
}