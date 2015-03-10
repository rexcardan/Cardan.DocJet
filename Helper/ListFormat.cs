using System.Collections.Generic;
using Cardan.DocJet.XML;

namespace Cardan.DocJet.Helper
{
    public class ListFormat
    {
        public static ListFormat Default = new ListFormat(new List<NodeFormat>
        {
            new NodeFormat(NumberFormat.Decimal, "%1.", LevelJustification.Left, Indentation._1),
            new NodeFormat(NumberFormat.LowerLetter, "%2.", LevelJustification.Left, Indentation._2),
            new NodeFormat(NumberFormat.LowerRoman, "%3.", LevelJustification.Right, Indentation._3),
            new NodeFormat(NumberFormat.Decimal, "%4.", LevelJustification.Left, Indentation._4),
            new NodeFormat(NumberFormat.LowerLetter, "%5", LevelJustification.Left, Indentation._5),
            new NodeFormat(NumberFormat.LowerRoman, "%6", LevelJustification.Right, Indentation._6),
            new NodeFormat(NumberFormat.Decimal, "%7.", LevelJustification.Left, Indentation._7),
            new NodeFormat(NumberFormat.LowerLetter, "%8.", LevelJustification.Left, Indentation._8),
            new NodeFormat(NumberFormat.LowerRoman, "%9.", LevelJustification.Right, Indentation._9)
        });

        public static ListFormat Bullets = new ListFormat(new List<NodeFormat>
        {
            new NodeFormat(NumberFormat.Bullet, "·", LevelJustification.Left, Indentation._1),
            new NodeFormat(NumberFormat.Bullet, "o", LevelJustification.Left, Indentation._2),
            new NodeFormat(NumberFormat.Bullet, "§", LevelJustification.Right, Indentation._3),
            new NodeFormat(NumberFormat.Bullet, "·", LevelJustification.Left, Indentation._4),
            new NodeFormat(NumberFormat.Bullet, "o", LevelJustification.Left, Indentation._5),
            new NodeFormat(NumberFormat.Bullet, "§", LevelJustification.Right, Indentation._6),
            new NodeFormat(NumberFormat.Bullet, "·", LevelJustification.Left, Indentation._7),
            new NodeFormat(NumberFormat.Bullet, "o", LevelJustification.Left, Indentation._8),
            new NodeFormat(NumberFormat.Bullet, "§", LevelJustification.Right, Indentation._9)
        });

        public ListFormat()
        {
            Levels = new List<NodeFormat>();
        }

        public ListFormat(List<NodeFormat> levels)
        {
            Levels = levels;
        }

        public List<NodeFormat> Levels { get; set; }
    }
}