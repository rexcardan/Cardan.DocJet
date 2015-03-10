using System;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;

namespace Cardan.DocJet.Helper
{
    public class Reference
    {
        public static void CopySubparts(OpenXmlPart orig, OpenXmlPart created, params Type[] exceptions)
        {
            foreach (
                IdPartPair part in orig.Parts.Where(p => !exceptions.ToList().Exists(e => e == p.OpenXmlPart.GetType()))
                )
            {
                created.AddPart(part.OpenXmlPart, part.RelationshipId);
            }
        }
    }
}