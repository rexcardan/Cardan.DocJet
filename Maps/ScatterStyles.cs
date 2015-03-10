namespace Cardan.DocJet.Maps
{
    public sealed class ScatterStyles : JetMap
    {
        public ScatterStyles(string style) : base(style)
        {
        }

        public static ScatterStyles None
        {
            get { return new ScatterStyles("none"); }
        }

        public static ScatterStyles Line
        {
            get { return new ScatterStyles("line"); }
        }

        public static ScatterStyles LineWithMarkers
        {
            get { return new ScatterStyles("lineMarker"); }
        }

        public static ScatterStyles Marker
        {
            get { return new ScatterStyles("marker"); }
        }

        public static ScatterStyles Smooth
        {
            get { return new ScatterStyles("smooth"); }
        }

        public static ScatterStyles SmoothMarker
        {
            get { return new ScatterStyles("smoothMarker"); }
        }
    }
}