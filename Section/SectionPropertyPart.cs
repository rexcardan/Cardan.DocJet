using System.Xml.Linq;

namespace Cardan.DocJet.Section
{
    public abstract class SectionPropertyPart
    {
        public abstract XElement ToXElement();
    }
}