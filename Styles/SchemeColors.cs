using System.Collections.Generic;
using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Styles
{
    public sealed class SchemeColors : XElement
    {
        private Dictionary<string, SchemeColors> colors = new Dictionary<string, SchemeColors>
        {
            {"accent1", Accent1},
            {"accent2", Accent2},
            {"accent3", Accent3},
            {"accent4", Accent4},
            {"accent5", Accent5},
            {"accent6", Accent6}
            //TODO Add the rest
        };

        public SchemeColors(string val)
            : base(A.schemeClr)
        {
            Attribute("val").Value = val;
        }

        public static SchemeColors Accent1
        {
            get { return new SchemeColors("accent1"); }
        }

        public static SchemeColors Accent2
        {
            get { return new SchemeColors("accent2"); }
        }

        public static SchemeColors Accent3
        {
            get { return new SchemeColors("accent3"); }
        }

        public static SchemeColors Accent4
        {
            get { return new SchemeColors("accent4"); }
        }

        public static SchemeColors Accent5
        {
            get { return new SchemeColors("accent5"); }
        }

        public static SchemeColors Accent6
        {
            get { return new SchemeColors("accent6"); }
        }

        public static SchemeColors Text1
        {
            get { return new SchemeColors("tx1"); }
        }

        public static SchemeColors Text2
        {
            get { return new SchemeColors("tx2"); }
        }

        public static SchemeColors Background1
        {
            get { return new SchemeColors("bg1"); }
        }

        public static SchemeColors Background2
        {
            get { return new SchemeColors("bg2"); }
        }

        public static SchemeColors Hyperlink
        {
            get { return new SchemeColors("hlink"); }
        }

        public static SchemeColors FollowedHyperlink
        {
            get { return new SchemeColors("folHlink"); }
        }

        public static SchemeColors Dark1
        {
            get { return new SchemeColors("dk1"); }
        }

        public static SchemeColors Dark2
        {
            get { return new SchemeColors("dk2"); }
        }

        public static SchemeColors Light1
        {
            get { return new SchemeColors("lt1"); }
        }

        public static SchemeColors Light2
        {
            get { return new SchemeColors("lt2"); }
        }

        public static SchemeColors PhColor
        {
            get { return new SchemeColors("phClr"); }
        }
    }
}