using System.Xml.Linq;

namespace Cardan.DocJet.Styles
{
    public class Word2013 : AbstractStyleTheme
    {
        public override XElement Normal
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:default='1' w:styleId='Normal' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Normal' />  <w:qFormat />  <w:rsid w:val='00610DCD' /></w:style>");
            }
        }

        public override XElement Heading1
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading1' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 1' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading1Char' />  <w:uiPriority w:val='9' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='240' w:after='0' />    <w:outlineLvl w:val='0' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='2E74B5' w:themeColor='accent1' w:themeShade='BF' />    <w:sz w:val='32' />    <w:szCs w:val='32' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading2
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading2' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 2' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading2Char' />  <w:uiPriority w:val='9' />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='40' w:after='0' />    <w:outlineLvl w:val='1' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='2E74B5' w:themeColor='accent1' w:themeShade='BF' />    <w:sz w:val='28' />    <w:szCs w:val='28' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading3
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading3' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 3' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading3Char' />  <w:uiPriority w:val='9' />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='40' w:after='0' />    <w:outlineLvl w:val='2' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='1F4E79' w:themeColor='accent1' w:themeShade='80' />    <w:sz w:val='24' />    <w:szCs w:val='24' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading4
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading4' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 4' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading4Char' />  <w:uiPriority w:val='9' />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='40' w:after='0' />    <w:outlineLvl w:val='3' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:i />    <w:iCs />    <w:color w:val='2E74B5' w:themeColor='accent1' w:themeShade='BF' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading5
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading5' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 5' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading5Char' />  <w:uiPriority w:val='9' />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='40' w:after='0' />    <w:outlineLvl w:val='4' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='2E74B5' w:themeColor='accent1' w:themeShade='BF' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading6
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading6' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 6' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading6Char' />  <w:uiPriority w:val='9' />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='40' w:after='0' />    <w:outlineLvl w:val='5' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='1F4E79' w:themeColor='accent1' w:themeShade='80' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading7
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading7' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 7' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading7Char' />  <w:uiPriority w:val='9' />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='40' w:after='0' />    <w:outlineLvl w:val='6' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:i />    <w:iCs />    <w:color w:val='1F4E79' w:themeColor='accent1' w:themeShade='80' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading8
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading8' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 8' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading8Char' />  <w:uiPriority w:val='9' />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='40' w:after='0' />    <w:outlineLvl w:val='7' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='262626' w:themeColor='text1' w:themeTint='D9' />    <w:sz w:val='21' />    <w:szCs w:val='21' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading9
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Heading9' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='heading 9' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='Heading9Char' />  <w:uiPriority w:val='9' />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:keepNext />    <w:keepLines />    <w:spacing w:before='40' w:after='0' />    <w:outlineLvl w:val='8' />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:i />    <w:iCs />    <w:color w:val='262626' w:themeColor='text1' w:themeTint='D9' />    <w:sz w:val='21' />    <w:szCs w:val='21' />  </w:rPr></w:style>");
            }
        }

        public override XElement DefaultParagraphFont
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:default='1' w:styleId='DefaultParagraphFont' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Default Paragraph Font' />  <w:uiPriority w:val='1' />  <w:semiHidden />  <w:unhideWhenUsed /></w:style>");
            }
        }

        public override XElement TableNormal
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='table' w:default='1' w:styleId='TableNormal' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Normal Table' />  <w:uiPriority w:val='99' />  <w:semiHidden />  <w:unhideWhenUsed />  <w:tblPr>    <w:tblInd w:w='0' w:type='dxa' />    <w:tblCellMar>      <w:top w:w='0' w:type='dxa' />      <w:left w:w='108' w:type='dxa' />      <w:bottom w:w='0' w:type='dxa' />      <w:right w:w='108' w:type='dxa' />    </w:tblCellMar>  </w:tblPr></w:style>");
            }
        }

        public override XElement NoList
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='numbering' w:default='1' w:styleId='NoList' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='No List' />  <w:uiPriority w:val='99' />  <w:semiHidden />  <w:unhideWhenUsed /></w:style>");
            }
        }

        public override XElement NoSpacing
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='NoSpacing' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='No Spacing' />  <w:uiPriority w:val='1' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:spacing w:after='0' w:line='240' w:lineRule='auto' />  </w:pPr></w:style>");
            }
        }

        public override XElement Heading1Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading1Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 1 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading1' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='2E74B5' w:themeColor='accent1' w:themeShade='BF' />    <w:sz w:val='32' />    <w:szCs w:val='32' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading2Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading2Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 2 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading2' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='2E74B5' w:themeColor='accent1' w:themeShade='BF' />    <w:sz w:val='28' />    <w:szCs w:val='28' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading3Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading3Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 3 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading3' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='1F4E79' w:themeColor='accent1' w:themeShade='80' />    <w:sz w:val='24' />    <w:szCs w:val='24' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading4Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading4Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 4 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading4' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:i />    <w:iCs />    <w:color w:val='2E74B5' w:themeColor='accent1' w:themeShade='BF' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading5Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading5Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 5 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading5' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='2E74B5' w:themeColor='accent1' w:themeShade='BF' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading6Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading6Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 6 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading6' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='1F4E79' w:themeColor='accent1' w:themeShade='80' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading7Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading7Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 7 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading7' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:i />    <w:iCs />    <w:color w:val='1F4E79' w:themeColor='accent1' w:themeShade='80' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading8Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading8Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 8 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading8' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:color w:val='262626' w:themeColor='text1' w:themeTint='D9' />    <w:sz w:val='21' />    <w:szCs w:val='21' />  </w:rPr></w:style>");
            }
        }

        public override XElement Heading9Char
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='Heading9Char' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Heading 9 Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Heading9' />  <w:uiPriority w:val='9' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:i />    <w:iCs />    <w:color w:val='262626' w:themeColor='text1' w:themeTint='D9' />    <w:sz w:val='21' />    <w:szCs w:val='21' />  </w:rPr></w:style>");
            }
        }

        public override XElement Title
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Title' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Title' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='TitleChar' />  <w:uiPriority w:val='10' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:spacing w:after='0' w:line='240' w:lineRule='auto' />    <w:contextualSpacing />  </w:pPr>  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:spacing w:val='-10' />    <w:sz w:val='56' />    <w:szCs w:val='56' />  </w:rPr></w:style>");
            }
        }

        public override XElement TitleChar
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='TitleChar' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Title Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Title' />  <w:uiPriority w:val='10' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:rFonts w:asciiTheme='majorHAnsi' w:eastAsiaTheme='majorEastAsia' w:hAnsiTheme='majorHAnsi' w:cstheme='majorBidi' />    <w:spacing w:val='-10' />    <w:sz w:val='56' />    <w:szCs w:val='56' />  </w:rPr></w:style>");
            }
        }

        public override XElement Subtitle
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Subtitle' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Subtitle' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='SubtitleChar' />  <w:uiPriority w:val='11' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:numPr>      <w:ilvl w:val='1' />    </w:numPr>  </w:pPr>  <w:rPr>    <w:color w:val='5A5A5A' w:themeColor='text1' w:themeTint='A5' />    <w:spacing w:val='15' />  </w:rPr></w:style>");
            }
        }

        public override XElement SubtitleChar
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='SubtitleChar' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Subtitle Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Subtitle' />  <w:uiPriority w:val='11' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:color w:val='5A5A5A' w:themeColor='text1' w:themeTint='A5' />    <w:spacing w:val='15' />  </w:rPr></w:style>");
            }
        }

        public override XElement SubtleEmphasis
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:styleId='SubtleEmphasis' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Subtle Emphasis' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:uiPriority w:val='19' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:i />    <w:iCs />    <w:color w:val='404040' w:themeColor='text1' w:themeTint='BF' />  </w:rPr></w:style>");
            }
        }

        public override XElement Emphasis
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:styleId='Emphasis' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Emphasis' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:uiPriority w:val='20' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:i />    <w:iCs />    <w:color w:val='auto' />  </w:rPr></w:style>");
            }
        }

        public override XElement IntenseEmphasis
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:styleId='IntenseEmphasis' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Intense Emphasis' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:uiPriority w:val='21' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:i />    <w:iCs />    <w:color w:val='5B9BD5' w:themeColor='accent1' />  </w:rPr></w:style>");
            }
        }

        public override XElement Strong
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:styleId='Strong' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Strong' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:uiPriority w:val='22' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:b />    <w:bCs />    <w:color w:val='auto' />  </w:rPr></w:style>");
            }
        }

        public override XElement Quote
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Quote' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Quote' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='QuoteChar' />  <w:uiPriority w:val='29' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:spacing w:before='200' />    <w:ind w:left='864' w:right='864' />  </w:pPr>  <w:rPr>    <w:i />    <w:iCs />    <w:color w:val='404040' w:themeColor='text1' w:themeTint='BF' />  </w:rPr></w:style>");
            }
        }

        public override XElement QuoteChar
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='QuoteChar' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Quote Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='Quote' />  <w:uiPriority w:val='29' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:i />    <w:iCs />    <w:color w:val='404040' w:themeColor='text1' w:themeTint='BF' />  </w:rPr></w:style>");
            }
        }

        public override XElement IntenseQuote
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='IntenseQuote' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Intense Quote' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:link w:val='IntenseQuoteChar' />  <w:uiPriority w:val='30' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:pBdr>      <w:top w:val='single' w:sz='4' w:space='10' w:color='5B9BD5' w:themeColor='accent1' />      <w:bottom w:val='single' w:sz='4' w:space='10' w:color='5B9BD5' w:themeColor='accent1' />    </w:pBdr>    <w:spacing w:before='360' w:after='360' />    <w:ind w:left='864' w:right='864' />    <w:jc w:val='center' />  </w:pPr>  <w:rPr>    <w:i />    <w:iCs />    <w:color w:val='5B9BD5' w:themeColor='accent1' />  </w:rPr></w:style>");
            }
        }

        public override XElement IntenseQuoteChar
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:customStyle='1' w:styleId='IntenseQuoteChar' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Intense Quote Char' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:link w:val='IntenseQuote' />  <w:uiPriority w:val='30' />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:i />    <w:iCs />    <w:color w:val='5B9BD5' w:themeColor='accent1' />  </w:rPr></w:style>");
            }
        }

        public override XElement SubtleReference
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:styleId='SubtleReference' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Subtle Reference' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:uiPriority w:val='31' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:smallCaps />    <w:color w:val='404040' w:themeColor='text1' w:themeTint='BF' />  </w:rPr></w:style>");
            }
        }

        public override XElement IntenseReference
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:styleId='IntenseReference' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Intense Reference' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:uiPriority w:val='32' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:b />    <w:bCs />    <w:smallCaps />    <w:color w:val='5B9BD5' w:themeColor='accent1' />    <w:spacing w:val='5' />  </w:rPr></w:style>");
            }
        }

        public override XElement BookTitle
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='character' w:styleId='BookTitle' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='Book Title' />  <w:basedOn w:val='DefaultParagraphFont' />  <w:uiPriority w:val='33' />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:rPr>    <w:b />    <w:bCs />    <w:i />    <w:iCs />    <w:spacing w:val='5' />  </w:rPr></w:style>");
            }
        }

        public override XElement ListParagraph
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='ListParagraph' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='List Paragraph' />  <w:basedOn w:val='Normal' />  <w:uiPriority w:val='34' />  <w:qFormat />  <w:rsid w:val='006C3494' />  <w:pPr>    <w:ind w:left='720' />    <w:contextualSpacing />  </w:pPr></w:style>");
            }
        }

        public override XElement Caption
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='Caption' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='caption' />  <w:basedOn w:val='Normal' />  <w:next w:val='Normal' />  <w:uiPriority w:val='35' />  <w:semiHidden />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:spacing w:after='200' w:line='240' w:lineRule='auto' />  </w:pPr>  <w:rPr>    <w:i />    <w:iCs />    <w:color w:val='44546A' w:themeColor='text2' />    <w:sz w:val='18' />    <w:szCs w:val='18' />  </w:rPr></w:style>");
            }
        }

        public override XElement TOCHeading
        {
            get
            {
                return
                    XElement.Parse(
                        @"<w:style w:type='paragraph' w:styleId='TOCHeading' xmlns:w='http://schemas.openxmlformats.org/wordprocessingml/2006/main'>  <w:name w:val='TOC Heading' />  <w:basedOn w:val='Heading1' />  <w:next w:val='Normal' />  <w:uiPriority w:val='39' />  <w:semiHidden />  <w:unhideWhenUsed />  <w:qFormat />  <w:rsid w:val='00610DCD' />  <w:pPr>    <w:outlineLvl w:val='9' />  </w:pPr></w:style>");
            }
        }
    }
}