namespace Cardan.DocJet.Maps
{
    public sealed class Crosses : JetMap
    {
        public Crosses(string cross) : base(cross)
        {
        }

        public static Crosses Autozero
        {
            get { return new Crosses("autoZero"); }
        }

        public static Crosses Minimum
        {
            get { return new Crosses("min"); }
        }

        public static Crosses Maximum
        {
            get { return new Crosses("max"); }
        }
    }
}