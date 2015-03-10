using System;
using System.Xml.Linq;
using Cardan.DocJet.Styles;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Chart
{
    public class Shape : JetElement
    {
        public Shape() : base(C.spPr)
        {
        }

        public Shape(XElement el) : base(el)
        {
        }

        public Outline Outline
        {
            get { return new Outline(Get(A.ln)); }
        }

        public Shape WithSolidFill(SchemeColors c)
        {
            RemoveFills();
            Set(A.solidFill, new JetElement(new XElement(A.solidFill, c)));
            return this;
        }

        public Shape WithNoFill()
        {
            RemoveFills();
            Set(A.noFill, new JetElement(new XElement(A.noFill)));
            return this;
        }

        private void RemoveFills()
        {
            Remove(A.solidFill, A.noFill, A.pattFill, A.blipFill, A.gradFill);
        }

        public Shape WithOutline(Action<Outline> outlineAction)
        {
            throw new NotImplementedException();
        }
    }
}