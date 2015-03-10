using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Cardan.DocJet.Helper;
using Cardan.DocJet.XML;
using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Extensions
{
    public static class NumberingDefPartExtensions
    {
        /// <summary>
        ///     Adds the correct format xml for the number definitions part and returns the numId to be referenced in the paragraph
        /// </summary>
        /// <param name="part">the part to be filled</param>
        /// <param name="format">the format of the numbering</param>
        /// <returns>the num id to be referenced by the paragraph</returns>
        public static string AddNewNumListType(this NumberingDefinitionsPart part, ListFormat format)
        {
            XDocument xdoc = part.GetXDocument();
            if (xdoc.Root == null)
            {
                xdoc.Add(new XElement(W.numbering));
            }
            XElement root = xdoc.Root;
            IEnumerable<XElement> currentTypes = xdoc.Descendants(W.abstractNum);

            foreach (XElement t in currentTypes)
            {
                bool alreadyExists = true;
                List<XElement> levels = t.Descendants(W.lvl).ToList();
                //Make sure all levels already exists
                for (int i = 0; i < levels.Count; i++)
                {
                    XElement lev = levels[i];
                    bool isSameNumFormat = XNode.DeepEquals(lev.Descendants(W.numFmt).First(),
                        format.Levels[i].NumberFormat);
                    string levText = format.Levels[i].LevelStringFormat ?? string.Format("%{0}.", i + 1);
                    bool isSameLevText = lev.Descendants(W.lvlText).First().Attribute(W.val).Value == levText;
                    alreadyExists = alreadyExists && isSameNumFormat && isSameLevText;
                    if (!alreadyExists)
                    {
                        break;
                    }
                }
                if (alreadyExists)
                {
                    string abstractId = t.Attribute(W.abstractNumId).Value;
                    string numId = AppendNewNumToRoot(abstractId, root, true);
                    part.PutXDocument(xdoc);
                    return numId;
                }
            }

            //If this code is reached, one does not already exist. Create new abstractNum
            int newId = currentTypes.Count();
            var abNum = new XElement(W.abstractNum, new XAttribute(W.abstractNumId, newId));
            for (int i = 0; i < format.Levels.Count; i++)
            {
                NodeFormat lev = format.Levels[i];
                var xLev = new XElement(W.lvl, new XAttribute(W.ilvl, i),
                    new XElement(W.start, new XAttribute(W.val, lev.StartNumber)),
                    lev.NumberFormat,
                    new XElement(W.lvlText, new XAttribute(W.val, lev.LevelStringFormat ?? string.Format("%{0}", i + 1))),
                    lev.Justification,
                    lev.Indentation);
                if (lev.NumberFormat == NumberFormat.Bullet)
                {
                    BulletHelper.InsertRunFont(lev, xLev);
                }
                abNum.Add(xLev);
            }

            XElement lastAbNum = root.Descendants(W.abstractNum).LastOrDefault();
            if (lastAbNum != null)
            {
                lastAbNum.AddAfterSelf(abNum);
            }
            else
            {
                root.Add(abNum);
            }

            string newNumId = AppendNewNumToRoot(newId.ToString(), root);
            part.PutXDocument(xdoc);
            return newNumId;
        }

        /// <summary>
        ///     Adds a new W:num to end of root.
        /// </summary>
        /// <param name="abstactNumId">the abstractId to reference in the num</param>
        /// <param name="root">the root of the numberingPartDef</param>
        /// <returns>the string id of the new num</returns>
        private static string AppendNewNumToRoot(string abstactNumId, XElement root, bool forceRestart = false)
        {
            int numId = root.Descendants(W.num).Count() + 1;
            var num = new XElement(W.num, new XAttribute(W.numId, numId),
                new XElement(W.abstractNumId, new XAttribute(W.val, abstactNumId)),
                new XElement(W.lvlOverride, new XAttribute(W.ilvl, 0),
                    new XElement(W.startOverride, new XAttribute(W.val, 1))));
            if (!forceRestart)
            {
                num.Descendants(W.lvlOverride).Remove();
            }
            XElement lastNum = root.Descendants(W.num).LastOrDefault();
            if (lastNum != null)
            {
                lastNum.AddAfterSelf(num);
            }
            else
            {
                root.Add(num);
            }
            return numId.ToString();
        }
    }
}