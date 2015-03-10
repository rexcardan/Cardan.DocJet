namespace Cardan.DocJet.Maps
{
    public sealed class DisplayBlankOptions : JetMap
    {
        public DisplayBlankOptions(string wrapped) : base(wrapped)
        {
        }

        public static DisplayBlankOptions Gap
        {
            get { return new DisplayBlankOptions("gap"); }
        }

        public static DisplayBlankOptions Span
        {
            get { return new DisplayBlankOptions("span"); }
        }

        public static DisplayBlankOptions Zero
        {
            get { return new DisplayBlankOptions("zero"); }
        }
    }
}