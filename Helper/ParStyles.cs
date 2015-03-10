using System.Xml.Linq;
using Cardan.DocJet.Styles;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Helper
{
    public class ParStyles
    {
        public static XElement Generate(StyleIds id)
        {
            return Generate(id.ToString());
        }

        private static XElement Generate(string styleId)
        {
            var props = new XElement(W.pStyle, new XAttribute(W.val, styleId));
            return props;
        }
    }
}