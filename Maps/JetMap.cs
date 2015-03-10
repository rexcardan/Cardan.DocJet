namespace Cardan.DocJet.Maps
{
    public abstract class JetMap
    {
        private readonly string _wrapped;

        public JetMap(string wrapped)
        {
            _wrapped = wrapped;
        }

        public string Wrapped
        {
            get { return _wrapped; }
        }

        public override bool Equals(object obj)
        {
            if (obj is JetMap)
            {
                return ((JetMap) obj).Wrapped == Wrapped;
            }
            return false;
        }
    }
}