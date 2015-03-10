using System.Linq;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Extensions
{
    public static class WmlDocExt
    {
        public static XElement GetContentControl(this WmlDocument doc, string tag)
        {
            using (var streamDoc = new OpenXmlMemoryStreamDocument(doc))
            {
                using (WordprocessingDocument document = streamDoc.GetWordprocessingDocument())
                {
                    MainDocumentPart mainDocumentPart = streamDoc.GetWordprocessingDocument().MainDocumentPart;
                    XDocument mdXDoc = mainDocumentPart.GetXDocument();
                    XElement cc = mdXDoc.Descendants(W.sdt)
                        .FirstOrDefault(
                            sdt =>
                                (string) sdt.Elements(W.sdtPr).Elements(W.tag).Attributes(W.val).FirstOrDefault() == tag);
                    return cc;
                }
            }
        }

        public static XDocument GetMainXDocument(this WmlDocument doc)
        {
            using (var streamDoc = new OpenXmlMemoryStreamDocument(doc))
            {
                using (WordprocessingDocument document = streamDoc.GetWordprocessingDocument())
                {
                    MainDocumentPart mainDocumentPart = streamDoc.GetWordprocessingDocument().MainDocumentPart;
                    XDocument mdXDoc = mainDocumentPart.GetXDocument();
                    return mdXDoc;
                }
            }
        }

        public static XDocument GetStyleXDocument(this WmlDocument doc)
        {
            using (var streamDoc = new OpenXmlMemoryStreamDocument(doc))
            {
                using (WordprocessingDocument document = streamDoc.GetWordprocessingDocument())
                {
                    StyleDefinitionsPart stylePart =
                        streamDoc.GetWordprocessingDocument()
                            .MainDocumentPart.GetPartsOfType<StyleDefinitionsPart>()
                            .First();
                    XDocument mdXDoc = stylePart.GetXDocument();
                    return mdXDoc;
                }
            }
        }
    }
}