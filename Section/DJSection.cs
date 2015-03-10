using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Section
{
    public class DJSection : IDisposable
    {
        public DJSection(Doc doc, params SectionPropertyPart[] parts)
        {
            Parts = parts.ToList();
            Doc = doc;
        }

        private List<SectionPropertyPart> Parts { get; set; }
        private Doc Doc { get; set; }

        public void Dispose()
        {
            var pageSize = Parts.FirstOrDefault(p => p is PageSize) as PageSize;
            var margin = Parts.FirstOrDefault(p => p is Margin) as Margin;
            var orient = Parts.FirstOrDefault(p => p is Orientation) as Orientation;

            var section = new XElement(W.sectPr);
            if (pageSize != null)
            {
                if (orient != null)
                {
                    orient.PageSizeAction(pageSize);
                }
                section.Add(pageSize.ToXElement());
            }
            if (margin != null)
            {
                section.Add(margin.ToXElement());
            }
            Doc.Append(new XElement(W.p, new XElement(W.pPr, section)));
        }
    }
}