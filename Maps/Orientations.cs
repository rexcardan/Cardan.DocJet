namespace Cardan.DocJet.Maps
{
    public class Orientations : JetMap
    {
        public Orientations(string or) : base(or)
        {
        }

        public static Orientations MinToMax
        {
            get { return new Orientations("minMax"); }
        }

        public static Orientations MaxToMin
        {
            get { return new Orientations("maxMin"); }
        }
    }
}