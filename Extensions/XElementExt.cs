using System.IO;
using System.Xml.Linq;
using DocumentFormat.OpenXml;

namespace Cardan.DocJet.Extensions
{
    public static class XElementExt
    {
        public static XElement CloneElement(this XElement element)
        {
            return element != null ? new XElement(element) : null;
        }

        public static OpenXmlElement ToOpenXmlEl(this XElement el)
        {
            OpenXmlElement oxe = el.ToString().ToOpenXmlEl();
            return oxe;
        }

        public static T ToOpenXmlEl<T>(this XElement el) where T : OpenXmlElement
        {
            OpenXmlElement oxe = el.ToOpenXmlEl();
            return (T) oxe;
        }

        public static OpenXmlElement ToOpenXmlEl(this XDocument doc)
        {
            OpenXmlElement oxe = doc.ToString().ToOpenXmlEl();
            return oxe;
        }

        public static T ToOpenXmlEl<T>(this XDocument doc) where T : OpenXmlElement
        {
            OpenXmlElement oxe = doc.ToOpenXmlEl();
            return (T) oxe;
        }

        private static OpenXmlElement ToOpenXmlEl(this string xmlString)
        {
            using (var sw = new StreamWriter(new MemoryStream()))
            {
                sw.Write(xmlString);
                sw.Flush();
                sw.BaseStream.Seek(0, SeekOrigin.Begin);

                OpenXmlReader re = OpenXmlReader.Create(sw.BaseStream);

                re.Read();
                OpenXmlElement oxe = re.LoadCurrentElement();
                re.Close();
                return oxe;
            }
        }
    }
}