using System;
using System.Xml.Linq;

namespace Cardan.DocJet.Section
{
    public class Orientation : SectionPropertyPart
    {
        private static readonly Action<PageSize> Landscape = pgSz => { pgSz.IsLandscape = true; };
        private static readonly Action<PageSize> Portrait = pgSz => { pgSz.IsLandscape = false; };

        public Action<PageSize> PageSizeAction
        {
            get { return IsLandscape ? Landscape : Portrait; }
        }

        public bool IsLandscape { get; set; }

        public override XElement ToXElement()
        {
            throw new NotImplementedException();
        }
    }
}