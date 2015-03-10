using Cardan.DocJet.Helper;
using Cardan.DocJet.Maps;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;
using X = System.Xml.Linq.XElement;
using XA = System.Xml.Linq.XAttribute;

namespace Cardan.DocJet.Chart
{
    public class ValueAxis : JetElement
    {
        public ValueAxis()
            : base(C.valAx)
        {
            Id = IdGenerator.NextIntId();
            IsCrossBetween = false;
            MajorTickMark = TickMarks.Out;
            MinorTickMarks = TickMarks.None;
            Scaling = new Scaling();
            Scaling.Orientation = Orientations.MinToMax;
            NumberingFormat = "General";
            IsVisible = true;
        }

        public ValueAxis(X valAx) : base(valAx)
        {
        }

        public string Id
        {
            get { return GetVal(C.axId); }
            set { SetVal(C.axId, value); }
        }

        public Scaling Scaling
        {
            get { return Get<Scaling>(C.scaling); }
            set { Set(value); }
        }

        public TickMarks MajorTickMark
        {
            get { return GetVal<TickMarks>(C.majorTickMark); }
            set { SetVal(C.majorTickMark, value); }
        }

        public TickMarks MinorTickMarks
        {
            get { return GetVal<TickMarks>(C.minorTickMark); }
            set { SetVal(C.minorTickMark, value); }
        }

        public AxisPositions Position
        {
            get
            {
                switch (GetVal(C.axPos))
                {
                    case "b":
                        return AxisPositions.Bottom;
                    case "t":
                        return AxisPositions.Top;
                    case "l":
                        return AxisPositions.Left;
                    case "r":
                        return AxisPositions.Right;
                    default:
                        return AxisPositions.Left;
                }
            }
            set
            {
                string val = "";
                switch (value)
                {
                    case AxisPositions.Bottom:
                        val = "b";
                        break;
                    case AxisPositions.Top:
                        val = "t";
                        break;
                    case AxisPositions.Left:
                        val = "l";
                        break;
                    case AxisPositions.Right:
                        val = "r";
                        break;
                    default:
                        val = "l";
                        break;
                }
                SetVal(C.axPos, val);
            }
        }

        public TickLabelPositions TickLablePosition
        {
            get { return GetVal<TickLabelPositions>(C.tickLblPos); }
            set { SetVal(C.tickLblPos, value); }
        }

        public string CrossAxisId
        {
            get { return GetVal(C.crossAx); }
            set { SetVal(C.crossAx, value); }
        }

        public Crosses Crosses
        {
            get { return GetVal<Crosses>(C.crosses); }
            set { SetVal(C.crosses, value); }
        }

        public bool IsCrossBetween
        {
            get { return GetVal(C.crossBetween) == "between"; }
            set { SetVal(C.crossBetween, value ? "between" : "midCat"); }
        }

        public string Title
        {
            get
            {
                X title = GetAfter(WrappedElement.Element(C.title), C.tx, A.t);
                return title != null ? title.Value : string.Empty;
            }
            set
            {
                X title = GetAfter(WrappedElement.Element(C.title), C.tx, A.t);
                if (title != null)
                {
                    title.Value = value;
                }
                else
                {
                    var titleEl = new X(C.title,
                        new X(C.tx, new X(C.rich, new X(A.bodyPr), new X(A.p, new X(A.r, new X(A.t, value))))));
                    WrappedElement.Add(titleEl);
                }
            }
        }

        public string NumberingFormat
        {
            get
            {
                X nf = Get(C.numFmt);
                return nf != null ? nf.Attribute(C.formatCode).Value : null;
            }
            set { ReplaceOrAdd(new X(C.numFmt, new XA("formatCode", value), new XA("sourceLinked", 0))); }
        }

        public Shape Shape
        {
            get { return new Shape(Get(C.spPr)); }
            set { Set(value); }
        }

        public bool IsVisible
        {
            get { return GetVal(C.delete) == "0"; }
            set { SetVal(C.delete, value ? 0 : 1); }
        }

        public void ForceX()
        {
            if (Position != AxisPositions.Bottom || Position != AxisPositions.Top)
            {
                Position = AxisPositions.Bottom;
            }
            Crosses = Crosses.Minimum;
        }

        public void ForceX2()
        {
            if (Position != AxisPositions.Bottom || Position != AxisPositions.Top)
            {
                Position = AxisPositions.Top;
            }
            Crosses = Crosses.Maximum;
        }

        public void ForceY()
        {
            if (Position != AxisPositions.Left || Position != AxisPositions.Right)
            {
                Position = AxisPositions.Left;
            }
            Crosses = Crosses.Minimum;
        }

        public void ForceY2()
        {
            if (Position != AxisPositions.Left || Position != AxisPositions.Right)
            {
                Position = AxisPositions.Right;
            }
            Crosses = Crosses.Maximum;
        }
    }
}