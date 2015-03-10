using System.Xml.Linq;
using Cardan.DocJet.Helper;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Section
{
    public class Margin : SectionPropertyPart
    {
        public Margin(double top = 0, double bottom = 0, double left = 0, double right = 0, double header = 0,
            double footer = 0, double gutter = 0)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
            Header = header;
            Footer = footer;
            Gutter = gutter;
        }

        //<w:pgMar w:top="720" w:right="720" w:bottom="720" w:left="720" w:header="720" w:footer="720" w:gutter="0" xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main" />
        public double Top { get; set; }
        public double Bottom { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
        public double Header { get; set; }
        public double Footer { get; set; }
        public double Gutter { get; set; }

        public override XElement ToXElement()
        {
            return new XElement(W.pgMar,
                new XAttribute(W.top, XConverter.GetTwips(Top)),
                new XAttribute(W.bottom, XConverter.GetTwips(Bottom)),
                new XAttribute(W.left, XConverter.GetTwips(Left)),
                new XAttribute(W.right, XConverter.GetTwips(Right)),
                new XAttribute(W.header, XConverter.GetTwips(Header)),
                new XAttribute(W.footer, XConverter.GetTwips(Footer)),
                new XAttribute(W.gutter, XConverter.GetTwips(Gutter)));
        }
    }
}