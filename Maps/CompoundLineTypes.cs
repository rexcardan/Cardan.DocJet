namespace Cardan.DocJet.Maps
{
    public sealed class CompoundLineTypes : JetMap
    {
        public CompoundLineTypes(string wrapped) : base(wrapped)
        {
        }

        public static CompoundLineTypes Single
        {
            get { return new CompoundLineTypes("sng"); }
        }

        public static CompoundLineTypes Double
        {
            get { return new CompoundLineTypes("dbl"); }
        }

        public static CompoundLineTypes ThickThin
        {
            get { return new CompoundLineTypes("thickThin"); }
        }

        public static CompoundLineTypes ThinThick
        {
            get { return new CompoundLineTypes("thinThick"); }
        }

        public static CompoundLineTypes Triple
        {
            get { return new CompoundLineTypes("tri"); }
        }
    }
}