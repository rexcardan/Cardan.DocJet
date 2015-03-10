using System.Collections.Generic;
using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Data
{
    public class LNode
    {
        public LNode(string text, params LNode[] children)
        {
            Children = new List<LNode>();
            Text = text;
            foreach (LNode child in children)
            {
                Children.Add(child);
            }
        }

        public string Text { get; set; }
        public List<LNode> Children { get; set; }

        public LNode WithChild(LNode child)
        {
            Children.Add(child);
            return this;
        }

        public LNode WithChild(string childText)
        {
            var node = new LNode(childText);
            return WithChild(node);
        }

        public void WithNodes(params string[] nodes)
        {
            foreach (string n in nodes)
            {
                Children.Add(new LNode(n));
            }
        }

        public List<XElement> ToParagraphs(string numId, XElement parStyle, int currentLevel = 0)
        {
            var paragraphs = new List<XElement>();
            var p = new XElement(W.p,
                new XElement(W.pPr, parStyle,
                    new XElement(W.numPr,
                        new XElement(W.ilvl, new XAttribute(W.val, currentLevel)),
                        new XElement(W.numId, new XAttribute(W.val, numId)))),
                new XElement(W.r,
                    new XElement(W.t, Text)));
            paragraphs.Add(p);
            foreach (LNode child in Children)
            {
                foreach (XElement par in child.ToParagraphs(numId, parStyle, currentLevel + 1))
                {
                    paragraphs.Add(par);
                }
            }
            return paragraphs;
        }
    }
}