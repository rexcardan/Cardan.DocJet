namespace Cardan.DocJet.Section
{
    public class PageSizes
    {
        public static PageSize Letter
        {
            get { return new PageSize(8.5, 11); }
        }

        public static PageSize Tabloid
        {
            get { return new PageSize(11, 17); }
        }

        public static PageSize Legal
        {
            get { return new PageSize(8.5, 14); }
        }

        public static PageSize Executive
        {
            get { return new PageSize(7.25, 10.5); }
        }
    }
}