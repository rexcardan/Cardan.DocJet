using System.Xml.Linq;

namespace Cardan.DocJet.Chart
{
    /// <summary>
    ///     A class to encapsulte the functionality of ScatterChart, ColumnChart, etc
    /// </summary>
    public abstract class XPlot : XElement
    {
        public XPlot(XName baseName) : base(baseName)
        {
        }

        public virtual XName BaseName
        {
            get { return ""; }
        }
    }
}