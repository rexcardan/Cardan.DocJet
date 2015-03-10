using System.Collections.Generic;
using System.Xml.Linq;

namespace Cardan.DocJet.Styles
{
    public abstract class AbstractStyleTheme
    {
        private readonly Dictionary<string, XElement> availableStyles;

        public AbstractStyleTheme()
        {
            availableStyles = new Dictionary<string, XElement>();
            availableStyles.Add("Normal", Normal);
            availableStyles.Add("Heading1", Heading1);
            availableStyles.Add("Heading2", Heading2);
            availableStyles.Add("Heading3", Heading3);
            availableStyles.Add("Heading4", Heading4);
            availableStyles.Add("Heading5", Heading5);
            availableStyles.Add("Heading6", Heading6);
            availableStyles.Add("Heading7", Heading7);
            availableStyles.Add("Heading8", Heading8);
            availableStyles.Add("Heading9", Heading9);
            availableStyles.Add("DefaultParagraphFont", DefaultParagraphFont);
            availableStyles.Add("TableNormal", TableNormal);
            availableStyles.Add("NoList", NoList);
            availableStyles.Add("NoSpacing", NoSpacing);
            availableStyles.Add("Heading1Char", Heading1Char);
            availableStyles.Add("Heading2Char", Heading2Char);
            availableStyles.Add("Heading3Char", Heading3Char);
            availableStyles.Add("Heading4Char", Heading4Char);
            availableStyles.Add("Heading5Char", Heading5Char);
            availableStyles.Add("Heading6Char", Heading6Char);
            availableStyles.Add("Heading7Char", Heading7Char);
            availableStyles.Add("Heading8Char", Heading8Char);
            availableStyles.Add("Heading9Char", Heading9Char);
            availableStyles.Add("Title", Title);
            availableStyles.Add("TitleChar", TitleChar);
            availableStyles.Add("Subtitle", Subtitle);
            availableStyles.Add("SubtitleChar", SubtitleChar);
            availableStyles.Add("SubtleEmphasis", SubtleEmphasis);
            availableStyles.Add("Emphasis", Emphasis);
            availableStyles.Add("IntenseEmphasis", IntenseEmphasis);
            availableStyles.Add("Strong", Strong);
            availableStyles.Add("Quote", Quote);
            availableStyles.Add("QuoteChar", QuoteChar);
            availableStyles.Add("IntenseQuote", IntenseQuote);
            availableStyles.Add("IntenseQuoteChar", IntenseQuoteChar);
            availableStyles.Add("SubtleReference", SubtleReference);
            availableStyles.Add("IntenseReference", IntenseReference);
            availableStyles.Add("BookTitle", BookTitle);
            availableStyles.Add("ListParagraph", ListParagraph);
            availableStyles.Add("Caption", Caption);
            availableStyles.Add("TOCHeading", TOCHeading);
        }

        public abstract XElement Normal { get; }
        public abstract XElement NoSpacing { get; }
        public abstract XElement Heading1 { get; }
        public abstract XElement Heading1Char { get; }
        public abstract XElement Heading2 { get; }
        public abstract XElement Heading2Char { get; }
        public abstract XElement Heading3 { get; }
        public abstract XElement Heading3Char { get; }
        public abstract XElement Heading4 { get; }
        public abstract XElement Heading4Char { get; }
        public abstract XElement Heading5 { get; }
        public abstract XElement Heading5Char { get; }
        public abstract XElement Heading6 { get; }
        public abstract XElement Heading6Char { get; }
        public abstract XElement Heading7 { get; }
        public abstract XElement Heading7Char { get; }
        public abstract XElement Heading8 { get; }
        public abstract XElement Heading8Char { get; }
        public abstract XElement Heading9 { get; }
        public abstract XElement Heading9Char { get; }
        public abstract XElement DefaultParagraphFont { get; }
        public abstract XElement TableNormal { get; }
        public abstract XElement Title { get; }
        public abstract XElement NoList { get; }
        public abstract XElement TitleChar { get; }
        public abstract XElement Subtitle { get; }
        public abstract XElement SubtitleChar { get; }
        public abstract XElement SubtleEmphasis { get; }
        public abstract XElement Emphasis { get; }
        public abstract XElement IntenseEmphasis { get; }
        public abstract XElement Strong { get; }
        public abstract XElement Quote { get; }
        public abstract XElement QuoteChar { get; }
        public abstract XElement IntenseQuote { get; }
        public abstract XElement IntenseQuoteChar { get; }
        public abstract XElement SubtleReference { get; }
        public abstract XElement IntenseReference { get; }
        public abstract XElement BookTitle { get; }
        public abstract XElement ListParagraph { get; }
        public abstract XElement Caption { get; }
        public abstract XElement TOCHeading { get; }

        public XElement GetStyle(string styleId)
        {
            if (availableStyles.ContainsKey(styleId))
            {
                return availableStyles[styleId];
            }
            return null;
        }

        public void AddOrReplaceStyles(Dictionary<string, XElement> newStyles)
        {
            foreach (var s in newStyles)
            {
                if (availableStyles.ContainsKey(s.Key))
                {
                    availableStyles[s.Key] = s.Value;
                }
                else
                {
                    availableStyles.Add(s.Key, s.Value);
                }
            }
        }
    }
}