using Cardan.DocJet.XML;

namespace Cardan.DocJet.Helper
{
    /// <summary>
    ///     A class to help format list items
    /// </summary>
    public class NodeFormat
    {
        public NodeFormat(NumberFormat numFormat)
        {
            NumberFormat = numFormat;
        }

        public NodeFormat(NumberFormat numFormat, string levelStringFormat, LevelJustification justification = null,
            Indentation indentation = null, int startNumber = 1)
        {
            NumberFormat = numFormat;
            LevelStringFormat = levelStringFormat;
            StartNumber = startNumber;
            Indentation = indentation;
            Justification = justification;
        }

        public int StartNumber { get; set; }
        public LevelJustification Justification { get; set; }
        public Indentation Indentation { get; set; }
        public NumberFormat NumberFormat { get; set; }

        /// <summary>
        ///     This exists to create scenarios where the subitems can contain the letter or number from the parent
        ///     (eg 1.A). You do this by a percent sign followed by the node level "n". %n is the default (%1 for first
        ///     level items, %2 for second level items, etc. You can get fancy with something like %1.%2 to do the 1.A
        ///     example.
        /// </summary>
        public string LevelStringFormat { get; set; }
    }
}