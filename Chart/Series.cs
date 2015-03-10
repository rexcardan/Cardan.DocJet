using System.Collections.Generic;
using System.Linq;
using Cardan.DocJet.Helper;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;
using X = System.Xml.Linq.XElement;
using XA = System.Xml.Linq.XAttribute;

namespace Cardan.DocJet.Chart
{
    public class Series : JetElement
    {
        public Series() : base(C.ser)
        {
            Marker = new XMarker();
        }

        public Series(X ser) : base(ser)
        {
        }

        public int Index
        {
            get { return GetVal<int>(C.idx); }
            set { SetVal(C.idx, value); }
        }

        public int Order
        {
            get { return GetVal<int>(C.order); }
            set { SetVal(C.order, value); }
        }

        public XMarker Marker
        {
            get { return Get<XMarker>(C.marker); }
            set { Set(C.marker, value); }
        }

        public string Name
        {
            get { return GetValue(C.tx, C.v); }
            set
            {
                var title = new X(C.tx, new X(C.v, value));
                ReplaceOrAdd(title);
            }
        }

        public DDataCollection Values
        {
            get
            {
                string xFormat = Get(C.xVal, C.formatCode).Value;
                string yFormat = Get(C.yVal, C.formatCode).Value;
                List<X> x = GetAll(C.xVal, C.pt, C.v);
                List<X> y = GetAll(C.yVal, C.pt, C.v);
                List<DData> data =
                    x.Select(
                        (xVal, i) =>
                            new DData(DataHelper.Cast(xVal.Value, xFormat), DataHelper.Cast(y[i].Value, yFormat)))
                        .ToList();
                return new DDataCollection(data);
            }
            set
            {
                dynamic xFormat = DataHelper.GetFormat(value.First().X);
                dynamic yFormat = DataHelper.GetFormat(value.First().Y);
                IEnumerable<X> xPts = value.Select((v, i) => new X(C.pt, new XA("idx", i), new X(C.v, v.X)));
                IEnumerable<X> yPts = value.Select((v, i) => new X(C.pt, new XA("idx", i), new X(C.v, v.Y)));
                var xVals = new X(C.xVal,
                    new X(C.numLit, new X(C.formatCode, xFormat), new X(C.ptCount, new XA("val", xPts.Count())), xPts));
                var yVals = new X(C.yVal,
                    new X(C.numLit, new X(C.formatCode, yFormat), new X(C.ptCount, new XA("val", yPts.Count())), yPts));
                ReplaceOrAdd(xVals);
                ReplaceOrAdd(yVals);
            }
        }

        public bool IsSmooth
        {
            get { return GetVal(C.smooth) == "1"; }
            set { SetVal(C.smooth, value ? 1 : 0); }
        }

        public Shape Shape
        {
            get { return new Shape(Get(C.spPr)); }
            set { Set(value); }
        }
    }
}