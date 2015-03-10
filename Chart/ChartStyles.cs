using Cardan.DocJet.Helper;

namespace Cardan.DocJet.Chart
{
    public class ChartStyles
    {
        public static void LoadDefault()
        {
            Template.SetChartSpaceTemplate("Default");
        }

        public static void LoadSubtle()
        {
            Template.SetChartSpaceTemplate("Subtle");
        }

        public static void LoadBlackNeon()
        {
            Template.SetChartSpaceTemplate("BlackNeon");
        }
    }
}