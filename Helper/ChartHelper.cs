using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Helper
{
    public class ChartHelper
    {
        public void SolidifyChartSpace(XElement chartSpace)
        {
            foreach (XElement ser in chartSpace.Descendants(C.ser))
            {
                foreach (XElement text in ser.Descendants(C.tx))
                {
                    //Remove everything except the value
                    IEnumerable<XElement> val = text.Descendants(C.v);
                    text.ReplaceAll(val);
                }
                RemoveAllStringRefs(ser.Descendants(C.cat).SingleOrDefault());
                //Val Replacement
                RemoveAllNumRefs(ser.Descendants(C.val).SingleOrDefault());
                //XVal Replacement
                RemoveAllNumRefs(ser.Descendants(C.xVal).SingleOrDefault());
                //YVal Replacement
                RemoveAllNumRefs(ser.Descendants(C.yVal).SingleOrDefault());
                //Remove All External Data
                chartSpace.Descendants(C.externalData).Remove();
            }
        }

        private static void RemoveAllStringRefs(XElement cat)
        {
            if (cat != null)
            {
                foreach (XElement stringRef in cat.Descendants(C.strRef))
                {
                    var stringLit = new XElement(C.strLit);
                    XElement cache = stringRef.Descendants(C.strCache).Single();
                    stringLit.Add(cache.Nodes());
                    stringRef.ReplaceWith(stringLit);
                }
            }
        }

        private static void RemoveAllNumRefs(XElement val)
        {
            if (val != null)
            {
                XElement numRef = val.Descendants(C.numRef).SingleOrDefault();
                if (numRef != null)
                {
                    var numLit = new XElement(C.numLit);
                    XElement cache = numRef.Descendants(C.numCache).Single();
                    numLit.Add(cache.Nodes());
                    numRef.ReplaceWith(numLit);
                }
            }
        }
    }
}