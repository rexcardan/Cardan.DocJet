namespace Cardan.DocJet.Maps
{
    public sealed class TickLabelPositions : JetMap
    {
        public TickLabelPositions(string wrapped) : base(wrapped)
        {
        }

        public static TickLabelPositions High
        {
            get { return new TickLabelPositions("high"); }
        }

        public static TickLabelPositions Low
        {
            get { return new TickLabelPositions("low"); }
        }

        public static TickLabelPositions NextTo
        {
            get { return new TickLabelPositions("nextTo"); }
        }

        public static TickLabelPositions None
        {
            get { return new TickLabelPositions("none"); }
        }

        public static TickLabelPositions Triple
        {
            get { return new TickLabelPositions("tri"); }
        }
    }
}