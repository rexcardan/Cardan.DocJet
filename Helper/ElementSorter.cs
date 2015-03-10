using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cardan.DocJet.XML;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Helper
{
    public static class ElementSorter
    {
        private static readonly Dictionary<XName, XName[]> SchemaOrder = new Dictionary<XName, XName[]>
        {
            {C.rich, new[] {A.bodyPr, A.lstStyle, A.p}},
            {A.p, new[] {A.pPr, A.r}},
            {A.r, new[] {A.rPr, A.t}},
            {C.marker, new[] {C.symbol, C.size, C.spPr}},
            {
                C.chart,
                new[]
                {C.title, C.autoTitleDeleted, C.plotArea, C.legend, C.plotVisOnly, C.dispBlanksAs, C.showDLblsOverMax}
            },
            {C.plotArea, new[] {C.layout, C.scatterChart, C.valAx, C.spPr}},
            {C.scatterChart, new[] {C.scatterStyle, C.varyColors, C.ser, C.dLbls, C.axId}},
            {C.ser, new[] {C.idx, C.order, C.tx, C.spPr, C.marker, C.xVal, C.yVal, C.smooth}},
            {
                C.valAx,
                new[]
                {
                    C.axId, C.scaling, C.delete, C.axPos, C.majorGridlines, C.minorGridlines, C.title, C.numFmt,
                    C.majorTickMark, C.minorTickMark, C.tickLblPos, C.spPr, C.txPr, C.crossAx, C.crosses, C.crossBetween
                }
            },
            {
                C.chartSpace,
                new[]
                {C.date1904, C.lang, C.roundedCorners, MC.AlternateContent, C.chart, C.spPr, C.txPr, C.externalData}
            }
        };

        public static void Sort(XElement root)
        {
            if (SchemaOrder.ContainsKey(root.Name))
            {
                XName[] sortOrder = SchemaOrder[root.Name];
                var indexOrder = new Dictionary<XName, int>();
                for (int i = 0; i < sortOrder.Length; i++)
                {
                    indexOrder.Add(sortOrder[i], i);
                }
                List<XElement> ordered = root.Elements().OrderBy(e => indexOrder[e.Name]).ToList();
                root.Elements().Remove();
                ordered.ForEach(o =>
                {
                    Sort(o);
                    root.Add(o);
                });
            }
        }

        public static void Sort(JetElement root)
        {
            Sort(root.WrappedElement);
        }

        public static void Sort(OpenXmlPart part)
        {
            XDocument xdoc = part.GetXDocument();
            Sort(xdoc.Root);
            part.PutXDocument(xdoc);
        }
    }
}