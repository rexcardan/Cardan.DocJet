namespace Cardan.DocJet.Maps
{
    public sealed class TickMarks : JetMap
    {
        public TickMarks(string cap) : base(cap)
        {
        }

        public static TickMarks Cross
        {
            get { return new TickMarks("cross"); }
        }

        public static TickMarks In
        {
            get { return new TickMarks("in"); }
        }

        public static TickMarks None
        {
            get { return new TickMarks("none"); }
        }

        public static TickMarks Out
        {
            get { return new TickMarks("out"); }
        }
    }
}