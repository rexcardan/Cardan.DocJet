using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using Cardan.DocJet.Chart;
using Cardan.DocJet.Data;
using Cardan.DocJet.Extensions;
using Cardan.DocJet.Helper;
using Cardan.DocJet.Section;
using Cardan.DocJet.Styles;
using Cardan.DocJet.XML;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;
using S = Cardan.DocJet.Styles.StyleIds;
using E = System.Xml.Linq.XElement;
using XA = System.Xml.Linq.XAttribute;

namespace Cardan.DocJet
{
    /// <summary>
    ///     The doc is the document held in memory for manipulation
    /// </summary>
    public class Doc : IDisposable
    {
        private readonly OpenXmlMemoryStreamDocument _streamDoc;

        /// <summary>
        ///     All docs are initialized with the BasicSimple theme
        /// </summary>
        public Doc()
        {
            _streamDoc = OpenXmlMemoryStreamDocument.CreateWordprocessingDocument();
            Theme = Themes.BasicSimple;
        }

        /// <summary>
        ///     The theme that holds the styles for the document.
        /// </summary>
        public AbstractStyleTheme Theme { get; set; }

        /// <summary>
        ///     Imports the styles from a separate word document. This is used if user created styles are defined and these
        ///     are to be used in document generation.
        /// </summary>
        /// <param name="docXStylePath">the path to the styled docx</param>
        /// <example>
        ///     <code>
        ///         var dj = new Cardan.DocJet.Doc();
        ///         dj.ImportStyles(@"..\BWCapitalized.docx");
        /// </code>
        /// </example>
        public void ImportStyles(string docXStylePath)
        {
            var styleDoc = new WmlDocument(docXStylePath);
            var styles = styleDoc.GetStyleXDocument();
            var styleDict = new Dictionary<string, E>();
            styles.Descendants(W.style).ToList().ForEach(s =>
            {
                var key = s.Attribute(W.styleId).Value;
                styleDict.Add(key, s);
            });
            Theme.AddOrReplaceStyles(styleDict);
        }

        /// <summary>
        ///     Appends a piece of text with a certian style id. This can be headers, comments, etc. See the StyleId enum
        ///     for options in the id.
        /// </summary>
        /// <param name="id">the style id of this paragraph</param>
        /// <param name="text">the text of the paragraph</param>
        /// <example>
        ///     <code>
        ///         var dj = new Cardan.DocJet.Doc();
        ///         dj.AppendParagraph(StyleIds.Title, "The Greatest Title In the World!");
        /// </code>
        /// </example>
        public void AppendParagraph(S id, string text)
        {
            E style = ParStyles.Generate(id);
            var p = new E(W.p, new E(W.pPr, style), new E(W.r, new E(W.t, text)));
            DefineStyleIfNotExist(style.Attributes(W.val).First().Value);
            Append(p);
        }

        /// <summary>
        ///     Appends a list of items to the document
        /// </summary>
        /// <param name="items">a hierarchical chain of nodes to form the list</param>
        public void AppendList(params LNode[] items)
        {
            AppendList(ListFormat.Default, items);
        }

        /// <summary>
        ///     Appends a list of items to the document
        /// </summary>
        /// <param name="format">the format in which to build the list (numbers, bullets, etc)</param>
        /// <param name="items">a hierarchical chain of nodes to form the list</param>
        public void AppendList(ListFormat format, params LNode[] items)
        {
            MainDocumentPart doc = _streamDoc.GetWordprocessingDocument().MainDocumentPart;
            NumberingDefinitionsPart numPart = doc.GetPartsOfType<NumberingDefinitionsPart>().FirstOrDefault() ??
                                               doc.AddNewPart<NumberingDefinitionsPart>(IdGenerator.NextId());
            string numId = numPart.AddNewNumListType(format);

            //Insert paragraph that references numId
            foreach (LNode it in items)
            {
                Append(it.ToParagraphs(numId, ParStyles.Generate(S.ListParagraph)));
            }
        }

        public void AppendPageBreak()
        {
            var p = new E(W.p, new E(W.r, new E(W.br, new XA(W.type, "page"))));
            Append(p);
        }

        public void InsertChart<T>(Action<XChartSpace, T> chartBuildAction, double widthInch = 6.5,
            double heightInch = 3.60) where T : AbstractPlot
        {
            if (XChartStyleTemplate.ChartSpaceStyle == null)
            {
                ChartStyles.LoadDefault();
            }
            var cSpace = new XChartSpace();
            cSpace.Chart.PlotArea.PrimaryPlot = Activator.CreateInstance<T>();

            chartBuildAction(cSpace, (T) cSpace.Chart.PlotArea.PrimaryPlot);
            string id = IdGenerator.NextId();
            var cp = _streamDoc.GetWordprocessingDocument().MainDocumentPart.AddNewPart<ChartPart>(id);
            ChartStyler.Style(cp);
            cp.PutXDocument(XDocument.Parse(cSpace.ToString()));
            ElementSorter.Sort(cp);
            InsertChartParagraph(id, XConverter.GetEMUs(widthInch), XConverter.GetEMUs(heightInch), cSpace.Chart.Title);
        }

        private void InsertChartParagraph(string id, int widthEmu, int heightEmu, string name)
        {
            var par = new E(W.p,
                new E(W.r,
                    new E(W.rPr,
                        new E(W.noProof)),
                    new E(W.drawing,
                        new E(WP.inline, new XA("distT", 0), new XA("distB", 0), new XA("distL", 0), new XA("distR", 0),
                            new E(WP.extent, new XA("cx", widthEmu), new XA("cy", heightEmu)),
                            new E(WP.effectExtent, new XA("l", 0), new XA("t", 0), new XA("r", 9525), new XA("b", 0)),
                            new E(WP.docPr, new XA("id", 1), new XA("name", "Chart : " + name)),
                            new E(WP.cNvGraphicFramePr),
                            new E(A.graphic,
                                new E(A.graphicData,
                                    new XA("uri", "http://schemas.openxmlformats.org/drawingml/2006/chart"),
                                    new E(C.chart, new XA(R.id, id))
                                    )
                                )
                            )
                        )
                    )
                );
            Append(par);
        }

        public void InsertTable(DataTable dTable, double widthInches = 6.5)
        {
            int cellWidth = XConverter.GetTwips(widthInches)/dTable.Columns.Count;
            DataRowCollection rows = dTable.Rows;
            var table = new E(W.tbl,
                new E(W.tblPr,
                    new E(W.tblStyle, new XA(W.val, "TableGrid")),
                    new E(W.tblW, new XA(W._w, "0"), new XA(W.type, "auto"))),
                new E(W.tblGrid,
                    Enumerable.Range(0, dTable.Columns.Count - 1)
                        .Select(i => new E(W.gridCol, new XA(W._w, cellWidth))).ToArray()));

            var header = new E(W.tr);

            //Add headers
            for (int cI = 0; cI < dTable.Columns.Count; cI++)
            {
                header.Add(new E(W.tc,
                    new E(W.tcPr,
                        new E(W.tcW, new XA(W._w, cellWidth), new XA(W.type, "dxa"))),
                    new E(W.p,
                        new E(W.r,
                            new E(W.t, dTable.Columns[cI])))));
            }
            table.Add(header);

            //Add data
            for (int rI = 0; rI < dTable.Rows.Count; rI++)
            {
                var r = new E(W.tr);
                for (int cI = 0; cI < dTable.Columns.Count; cI++)
                {
                    r.Add(new E(W.tc,
                        new E(W.tcPr,
                            new E(W.tcW, new XA(W._w, cellWidth), new XA(W.type, "dxa"))),
                        new E(W.p,
                            new E(W.r,
                                new E(W.t, dTable.Rows[rI][cI])))));
                }
                table.Add(r);
            }
            Append(table);
        }

        /// <summary>
        ///     Appends the xelement to the end of the doc
        /// </summary>
        /// <param name="content">the content to insert</param>
        public void Append(E content)
        {
            Append(_streamDoc.GetWordprocessingDocument(), new[] {content});
        }

        /// <summary>
        ///     Appends the list of xelements to the end of the doc
        /// </summary>
        /// <param name="content">the content to insert</param>
        public void Append(IEnumerable<E> content)
        {
            Append(_streamDoc.GetWordprocessingDocument(), content);
        }

        private void Append(WordprocessingDocument currentDoc, IEnumerable<E> content)
        {
            currentDoc.MainDocumentPart.GetXDocument().Root.Element(W.body).Add(content);
            XElement body = currentDoc.MainDocumentPart.GetXDocument().Root.Element(W.body);
            currentDoc.MainDocumentPart.PutXDocument(body.Document);
        }

        /// <summary>
        ///     Saves the doc from memory to a file
        /// </summary>
        /// <param name="outputFile">the path of the file to save the doc</param>
        public void SaveAs(string outputFile)
        {
            PresaveProcess();
            _streamDoc.GetModifiedDocument().SaveAs(outputFile);
            _streamDoc.Dispose();
        }

        public void InsertDoc(string docPath, Dictionary<string, string> templateValues = null)
        {
            var wml = new WmlDocument(docPath);
            InsertDoc(wml, templateValues);
        }

        public void InsertDoc(byte[] docBytes, Dictionary<string, string> templateValues = null)
        {
            var wml = new WmlDocument("RefDoc.docx", docBytes);
            InsertDoc(wml, templateValues);
        }

        private void InsertDoc(WmlDocument wml, Dictionary<string, string> templateValues = null)
        {
            using (WordprocessingDocument refDoc = (new OpenXmlMemoryStreamDocument(wml)).GetWordprocessingDocument())
            {
                MainDocumentPart main = refDoc.MainDocumentPart;
                XDocument xdoc = main.GetXDocument();
                List<ImagePart> images = main.GetPartsOfType<ImagePart>().ToList();
                var imageDict = new Dictionary<string, ImagePart>();
                images.ForEach(i => imageDict.Add(main.GetIdOfPart(i), i));
                IEnumerable<XElement> blips = xdoc.Descendants(A.blip);
                foreach (XElement blip in blips)
                {
                    string id = IdGenerator.NextId();
                    string oldId = blip.Attribute(R.embed).Value;
                    if (imageDict.ContainsKey(oldId))
                    {
                        ImagePart refIm = imageDict[oldId];
                        ImagePart im =
                            _streamDoc.GetWordprocessingDocument().MainDocumentPart.AddImagePart(refIm.ContentType, id);
                        im.FeedData(refIm.GetStream());
                    }
                    blip.SetAttributeValue(R.embed, id);
                }
                if (templateValues != null)
                {
                    foreach (var val in templateValues)
                    {
                        XStdRun run =
                            xdoc.Descendants(W.sdt).Select(s => new XStdRun(s)).FirstOrDefault(r => r.Tag == val.Key);
                        if (run != null)
                        {
                            run.Value = val.Value;
                        }
                    }
                }
                xdoc.Root.Element(W.body).Element(W.sectPr).Remove();
                xdoc.Descendants(W.bookmarkStart).Remove();
                xdoc.Descendants(W.bookmarkEnd).Remove();
                xdoc.Root.Attributes()
                    .Where(a => a.IsNamespaceDeclaration)
                    .Select(a => a)
                    .ToList()
                    .ForEach(n => AddNamespaceToRoot(n));
                xdoc.Root.Element(W.body).Elements().ToList().ForEach(e =>
                {
                    e.Descendants()
                        .Where(d => d.Attribute("id") != null)
                        .ToList()
                        .ForEach(d => d.SetAttributeValue("id", IdGenerator.NextIntId()));
                    e.Descendants()
                        .Where(d => d.Name == W.p)
                        .ToList()
                        .ForEach(d => d.SetAttributeValue(W14.paraId, IdGenerator.NextIntId()));
                    Append(e);
                });
                if (xdoc.Root.Element(W.body).Element(W.sectPr) != null)
                {
                    var p = new E(W.p, new E(W.pPr, xdoc.Root.Element(W.body).Element(W.sectPr).CloneElement()));
                    Append(p);
                }
            }
        }

        public void AddNamespaceToRoot(XA nSpace)
        {
            XDocument xdoc = _streamDoc.GetWordprocessingDocument().MainDocumentPart.GetXDocument();
            XElement root = xdoc.Root;
            if (root.Attribute(nSpace.Name) == null)
            {
                root.Add(nSpace);
            }
            _streamDoc.GetWordprocessingDocument().MainDocumentPart.PutXDocument(xdoc);
        }

        public DJSection CreateSection(params SectionPropertyPart[] props)
        {
            return new DJSection(this, props);
        }

        #region PLUMBING

        void IDisposable.Dispose()
        {
            _streamDoc.Dispose();
        }

        /// <summary>
        ///     Adds a section properties element in case the last paragraph only exists to define a section.
        /// </summary>
        private void PresaveProcess()
        {
            XDocument xdoc = _streamDoc.GetWordprocessingDocument().MainDocumentPart.GetXDocument();
            XElement last = xdoc.Root.Elements(W.body).Elements().Last();
            if ((last.Name == W.p) && last.Descendants(W.sectPr).Count() > 0 && last.Descendants(W.r).Count() == 0)
            {
                XElement sProp = last.Descendants(W.sectPr).First().CloneElement();
                last.Remove();
                xdoc.Root.Element(W.body).Add(sProp);
                _streamDoc.GetWordprocessingDocument().MainDocumentPart.PutXDocument(xdoc);
            }
        }

        /// <summary>
        ///     Creates a style in the stylepart of the document if it does not already exist there.
        /// </summary>
        /// <param name="styleId">the style id to create if it does not exist</param>
        private void DefineStyleIfNotExist(string styleId)
        {
            StyleDefinitionsPart styles =
                _streamDoc.GetWordprocessingDocument().MainDocumentPart.StyleDefinitionsPart ??
                _streamDoc.GetWordprocessingDocument().MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            XDocument xStyles = styles.GetXDocument();
            XElement root = xStyles.Root.CloneElement() ?? new XElement(W.styles);
            if (root.Descendants(W.style).Attributes(W.styleId).Where(s => s.Value == styleId).Count() == 0)
            {
                XElement newStyle = Theme.GetStyle(styleId);
                root.Add(newStyle);
                xStyles.RemoveNodes();
                xStyles.Add(root);
                styles.PutXDocument(xStyles);
                var dependencies = new List<XElement>();
                newStyle.Descendants(W.basedOn).ToList().ForEach(d => dependencies.Add(d));
                newStyle.Descendants(W.link).ToList().ForEach(d => dependencies.Add(d));
                dependencies.ForEach(d => DefineStyleIfNotExist(d.Attribute(W.val).Value));
            }
        }

        #endregion
    }
}