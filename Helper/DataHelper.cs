namespace Cardan.DocJet.Helper
{
    public class DataHelper
    {
        public static dynamic Cast(string val, string format)
        {
            switch (format)
            {
                default:
                    return double.Parse(val);
            }
        }

        public static string GetFormat(dynamic dynamic)
        {
            if (dynamic is double)
            {
                return "General";
            }
            return "General";
        }
    }
}