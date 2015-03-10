using System.Xml.Linq;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Helper
{
    public class BulletHelper
    {
        public static void InsertRunFont(NodeFormat lev, XElement xLev)
        {
            if (lev.LevelStringFormat == "·")
            {
                xLev.Add(new XElement(W.rPr, RunFont.Bullet_1));
            }
            if (lev.LevelStringFormat == "o")
            {
                xLev.Add(new XElement(W.rPr, RunFont.Bullet_2));
            }
            if (lev.LevelStringFormat == "§")
            {
                xLev.Add(new XElement(W.rPr, RunFont.Bullet_3));
            }
        }
    }
}