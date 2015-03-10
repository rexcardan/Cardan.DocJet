using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.XML
{
    public class RunFont : XElement
    {
        public static RunFont Bullet_1 = new RunFont("default", "Symbol", "Symbol");
        public static RunFont Bullet_2 = new RunFont("default", "Courier New", "Courier New", "Courier New");
        public static RunFont Bullet_3 = new RunFont("default", "Wingdings", "Wingdings");

        public RunFont(string hint, string ascii, string hAnsi) : base(W.rFonts,
            new XAttribute(W.hint, hint), new XAttribute(W.ascii, ascii), new XAttribute(W.hAnsi, hAnsi))
        {
        }

        public RunFont(string hint, string ascii, string hAnsi, string cs)
            : base(W.rFonts,
                new XAttribute(W.hint, hint), new XAttribute(W.ascii, ascii), new XAttribute(W.hAnsi, hAnsi),
                new XAttribute(W.cs, cs))
        {
        }
    }
}