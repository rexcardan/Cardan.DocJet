using System.Xml.Linq;

namespace Cardan.DocJet.Helper
{
    public static class XConverter
    {
        /// <summary>
        ///     A4 page portrait with 1" margins
        /// </summary>
        public static int A4FullNormalP_EMU
        {
            get { return GetEMUs(6.5); }
        }

        /// <summary>
        ///     A4 page portrait with 1" margins
        /// </summary>
        public static int A4FullNormalP_Points
        {
            get { return GetTwips(6.5); }
        }

        public static XElement A4LandscapeSectionProps
        {
            get
            {
                return
                    XElement.Parse(
                        " <w:sectPr xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main' w:rsidR='007875D4' w:rsidSect='00B8128F'><w:pgSz w:w='15840' w:h='12240' w:orient='landscape' />       <w:pgMar w:top='1440' w:right='1440' w:bottom='1440' w:left='1440' w:header='720' w:footer='720' w:gutter='0' />       <w:cols w:space='720' />       <w:docGrid w:linePitch='360' />     </w:sectPr> ");
            }
        }

        public static XElement A4PortraitSectionProps
        {
            get
            {
                return
                    XElement.Parse(
                        " <w:sectPr xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main' w:rsidR='007875D4' w:rsidSect='00B8128F'><w:pgSz w:w='12240' w:h='15840'/>       <w:pgMar w:top='1440' w:right='1440' w:bottom='1440' w:left='1440' w:header='720' w:footer='720' w:gutter='0' />       <w:cols w:space='720' />       <w:docGrid w:linePitch='360' />     </w:sectPr> ");
            }
        }

        public static int GetEMUs(double inches)
        {
            return (int) (inches*914400);
        }

        public static int GetTwips(double inches)
        {
            return (int) (1440*inches);
        }
    }
}