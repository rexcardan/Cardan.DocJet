using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.XML
{
    public class Indentation : XElement
    {
        public Indentation(int left, int hanging) : base(W.pPr,
            new XElement(W.ind,
                new XAttribute(W.left, left), new XAttribute(W.hanging, hanging)))
        {
        }

        public static Indentation _1
        {
            get { return new Indentation(720, 360); }
        }

        public static Indentation _2
        {
            get { return new Indentation(1440, 360); }
        }

        public static Indentation _3
        {
            get { return new Indentation(2160, 180); }
        }

        public static Indentation _4
        {
            get { return new Indentation(2880, 360); }
        }

        public static Indentation _5
        {
            get { return new Indentation(3600, 360); }
        }

        public static Indentation _6
        {
            get { return new Indentation(4320, 180); }
        }

        public static Indentation _7
        {
            get { return new Indentation(5040, 360); }
        }

        public static Indentation _8
        {
            get { return new Indentation(5760, 360); }
        }

        public static Indentation _9
        {
            get { return new Indentation(6480, 180); }
        }
    }
}