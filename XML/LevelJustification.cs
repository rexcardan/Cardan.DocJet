using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.XML
{
    public class LevelJustification : XElement
    {
        public static LevelJustification Left = new LevelJustification("left");
        public static LevelJustification Right = new LevelJustification("right");

        public LevelJustification(string dir) : base(W.lvlJc, new XAttribute(W.val, dir))
        {
        }
    }
}