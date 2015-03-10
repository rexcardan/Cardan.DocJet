using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.XML
{
    public class NumberFormat : XElement
    {
        /// <summary>
        ///     Cardinal Text (One, Two Three)
        /// </summary>
        public static NumberFormat CardinalText = new NumberFormat("cardinalText");

        /// <summary>
        ///     Ordinal Text (First, Second, Third)
        /// </summary>
        public static NumberFormat OrdinalText = new NumberFormat("ordinalText");

        /// <summary>
        ///     Ordinal (1st, 2nd, 3rd)
        /// </summary>
        public static NumberFormat Ordinal = new NumberFormat("ordinal");

        /// <summary>
        ///     Lower Letter (a, b, c)
        /// </summary>
        public static NumberFormat LowerLetter = new NumberFormat("lowerLetter");

        /// <summary>
        ///     Upper Letter (A, B, C)
        /// </summary>
        public static NumberFormat UpperLetter = new NumberFormat("upperLetter");

        /// <summary>
        ///     Lower Roman (i, ii, iii)
        /// </summary>
        public static NumberFormat LowerRoman = new NumberFormat("lowerRoman");

        /// <summary>
        ///     Upper Roman (I, II, III)
        /// </summary>
        public static NumberFormat UpperRoman = new NumberFormat("upperRoman");

        /// <summary>
        ///     Decimal Zero (01, 02, 03)
        /// </summary>
        public static NumberFormat DecimalZero = new NumberFormat("decimalZero");

        /// <summary>
        ///     Decimal (1, 2, 3)
        /// </summary>
        public static NumberFormat Decimal = new NumberFormat("decimal");

        /// <summary>
        ///     Bullets
        /// </summary>
        public static NumberFormat Bullet = new NumberFormat("bullet");

        private XElement _xElement;

        public NumberFormat(string formatValue)
            : base(W.numFmt, new XAttribute(W.val, formatValue))
        {
        }
    }
}