using System.Xml.Linq;
using Cardan.DocJet.Helper;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Section
{
    //<w:pgSz w:w="12240" w:h="15840" />
    public class PageSize : SectionPropertyPart
    {
        public PageSize(double width, double height, bool isLandscape = false)
        {
            Width = width;
            Height = height;
            IsLandscape = IsLandscape;
        }

        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsLandscape { get; set; }

        public override XElement ToXElement()
        {
            var pgSz = new XElement(W.pgSz,
                new XAttribute(W._w, IsLandscape ? XConverter.GetTwips(Height) : XConverter.GetTwips(Width)),
                new XAttribute(W.h, IsLandscape ? XConverter.GetTwips(Width) : XConverter.GetTwips(Height)));
            if (IsLandscape)
            {
                pgSz.Add(new XAttribute(W.orient, "landscape"));
            }
            return pgSz;
        }
    }
}