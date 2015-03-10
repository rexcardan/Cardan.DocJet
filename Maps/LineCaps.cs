namespace Cardan.DocJet.Maps
{
    public sealed class LineCaps : JetMap
    {
        public LineCaps(string cap) : base(cap)
        {
        }

        public static LineCaps Round
        {
            get { return new LineCaps("rnd"); }
        }

        public static LineCaps Square
        {
            get { return new LineCaps("sq"); }
        }

        public static LineCaps Flat
        {
            get { return new LineCaps("flat"); }
        }
    }
}