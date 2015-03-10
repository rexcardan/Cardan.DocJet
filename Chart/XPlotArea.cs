using System.Linq;
using System.Xml.Linq;
using Cardan.DocJet.XML;
using OpenXmlPowerTools;

namespace Cardan.DocJet.Chart
{
    public class XPlotArea : JetElement
    {
        public XPlotArea() : base(C.plotArea)
        {
            Layout = new XElement(C.layout);
            ApplyCurrentStyle();
        }

        public XPlotArea(XElement el) : base(el)
        {
        }

        public Shape Shape
        {
            get { return new Shape(Get(C.spPr)); }
            set { Set(value); }
        }

        public XElement Layout
        {
            get { return Get(C.layout); }
            set { WrappedElement.Add(value); }
        }

        public AbstractPlot PrimaryPlot
        {
            get
            {
                AbstractPlot ab = AbstractPlot.Map(GetAnyOf(0, C.scatterChart, C.lineChart, C.areaChart));
                if (ab != null)
                {
                    ab.IsSecondary = false;
                }
                return ab;
            }
            set
            {
                SetAnyOf(0, value, C.scatterChart, C.lineChart, C.areaChart);
                if (XAxis == null || YAxis == null)
                {
                    XAxis = XAxis ?? new ValueAxis();
                    YAxis = YAxis ?? new ValueAxis();
                    XAxis.CrossAxisId = YAxis.Id;
                    YAxis.CrossAxisId = XAxis.Id;
                }
            }
        }

        public AbstractPlot SecondaryPlot
        {
            get
            {
                AbstractPlot ab = AbstractPlot.Map(GetAnyOf(1, C.scatterChart, C.lineChart, C.areaChart));
                if (ab != null)
                {
                    ab.IsSecondary = true;
                }
                return ab;
            }
            set
            {
                SetAnyOf(1, value, C.scatterChart, C.lineChart, C.areaChart);
                if (X2Axis == null || Y2Axis == null)
                {
                    X2Axis = X2Axis ?? new ValueAxis();
                    Y2Axis = Y2Axis ?? new ValueAxis();
                    X2Axis.CrossAxisId = YAxis.Id;
                    Y2Axis.CrossAxisId = XAxis.Id;
                }
            }
        }

        public ValueAxis XAxis
        {
            get
            {
                if (PrimaryPlot != null)
                {
                    return GetAll<ValueAxis>(C.valAx)
                        .FirstOrDefault(v => (v.Id == PrimaryPlot.AxisId1 || v.Id == PrimaryPlot.AxisId2)
                                             && (v.Position == AxisPositions.Bottom || v.Position == AxisPositions.Top));
                }
                return GetAll<ValueAxis>(C.valAx)
                    .FirstOrDefault(v => (v.Position == AxisPositions.Bottom || v.Position == AxisPositions.Top));
            }
            set
            {
                if (PrimaryPlot != null)
                {
                    if (XChartStyleTemplate.XAxisStyle != null)
                    {
                        XChartStyleTemplate.XAxisStyle(value);
                    }
                    value.ForceX();
                    if (XAxis != null)
                    {
                        string originalId = XAxis.Id;
                        XAxis.WrappedElement.ReplaceWith(value.WrappedElement);
                        if (PrimaryPlot.AxisId1 == originalId)
                        {
                            PrimaryPlot.AxisId1 = value.Id;
                        }
                        if (PrimaryPlot.AxisId2 == originalId)
                        {
                            PrimaryPlot.AxisId2 = value.Id;
                        }
                    }
                    else
                    {
                        WrappedElement.Add(value.WrappedElement);
                        PrimaryPlot.AxisId1 = value.Id;
                    }
                }
            }
        }

        public ValueAxis YAxis
        {
            get
            {
                if (PrimaryPlot != null)
                {
                    return GetAll<ValueAxis>(C.valAx)
                        .FirstOrDefault(v => (v.Id == PrimaryPlot.AxisId1 || v.Id == PrimaryPlot.AxisId2)
                                             && (v.Position == AxisPositions.Left || v.Position == AxisPositions.Right));
                }
                return GetAll<ValueAxis>(C.valAx)
                    .FirstOrDefault(v => (v.Position == AxisPositions.Left || v.Position == AxisPositions.Right));
            }
            set
            {
                if (PrimaryPlot != null)
                {
                    if (XChartStyleTemplate.YAxisStyle != null)
                    {
                        XChartStyleTemplate.YAxisStyle(value);
                    }
                    value.ForceY();
                    if (YAxis != null)
                    {
                        string originalId = YAxis.Id;
                        YAxis.WrappedElement.ReplaceWith(value.WrappedElement);
                        if (PrimaryPlot.AxisId1 == originalId)
                        {
                            PrimaryPlot.AxisId1 = value.Id;
                        }
                        if (PrimaryPlot.AxisId2 == originalId)
                        {
                            PrimaryPlot.AxisId2 = value.Id;
                        }
                    }
                    else
                    {
                        WrappedElement.Add(value.WrappedElement);
                        PrimaryPlot.AxisId2 = value.Id;
                    }
                }
            }
        }

        public ValueAxis X2Axis
        {
            get
            {
                if (SecondaryPlot != null)
                {
                    return GetAll<ValueAxis>(C.valAx)
                        .FirstOrDefault(v => (v.Id == SecondaryPlot.AxisId1 || v.Id == SecondaryPlot.AxisId2)
                                             && (v.Position == AxisPositions.Bottom || v.Position == AxisPositions.Top));
                }
                return GetAll<ValueAxis>(C.valAx)
                    .FirstOrDefault(
                        v => v.Id != XAxis.Id && (v.Position == AxisPositions.Bottom || v.Position == AxisPositions.Top));
            }
            set
            {
                if (SecondaryPlot != null)
                {
                    if (XChartStyleTemplate.X2AxisStyle != null)
                    {
                        XChartStyleTemplate.X2AxisStyle(value);
                    }
                    value.ForceX2();
                    if (X2Axis != null)
                    {
                        string originalId = X2Axis.Id;
                        X2Axis.WrappedElement.ReplaceWith(value.WrappedElement);
                        if (SecondaryPlot.AxisId1 == originalId)
                        {
                            SecondaryPlot.AxisId1 = value.Id;
                        }
                        if (SecondaryPlot.AxisId2 == originalId)
                        {
                            SecondaryPlot.AxisId2 = value.Id;
                        }
                    }
                    else
                    {
                        WrappedElement.Add(value.WrappedElement);
                        SecondaryPlot.AxisId1 = value.Id;
                    }
                }
            }
        }

        public ValueAxis Y2Axis
        {
            get
            {
                if (SecondaryPlot != null)
                {
                    return GetAll<ValueAxis>(C.valAx)
                        .FirstOrDefault(v => (v.Id == SecondaryPlot.AxisId1 || v.Id == SecondaryPlot.AxisId2)
                                             && (v.Position == AxisPositions.Left || v.Position == AxisPositions.Right));
                }
                return GetAll<ValueAxis>(C.valAx)
                    .FirstOrDefault(
                        v => v.Id != YAxis.Id && (v.Position == AxisPositions.Left || v.Position == AxisPositions.Right));
            }
            set
            {
                if (SecondaryPlot != null)
                {
                    if (XChartStyleTemplate.Y2AxisStyle != null)
                    {
                        XChartStyleTemplate.Y2AxisStyle(value);
                    }
                    value.ForceY2();
                    if (Y2Axis != null)
                    {
                        string originalId = Y2Axis.Id;
                        Y2Axis.WrappedElement.ReplaceWith(value.WrappedElement);
                        if (SecondaryPlot.AxisId1 == originalId)
                        {
                            SecondaryPlot.AxisId1 = value.Id;
                        }
                        if (SecondaryPlot.AxisId2 == originalId)
                        {
                            SecondaryPlot.AxisId2 = value.Id;
                        }
                    }
                    else
                    {
                        WrappedElement.Add(value.WrappedElement);
                        SecondaryPlot.AxisId2 = value.Id;
                    }
                }
            }
        }

        #region PLUMBING

        public void UpdateSeriesIdsAndOrder()
        {
            var allSeries =
                (SecondaryPlot != null ? PrimaryPlot.Series.Concat(SecondaryPlot.Series) : PrimaryPlot.Series)
                    .Select((ser, i) => new {Series = ser, Index = i}).ToList();
            allSeries.ForEach(s =>
            {
                s.Series.Index = s.Index;
                s.Series.Order = s.Index;
            });
        }

        #endregion

        public void ApplyCurrentStyle()
        {
            if (XChartStyleTemplate.PlotAreaStyle != null)
            {
                XChartStyleTemplate.PlotAreaStyle(this);
            }
            if (XChartStyleTemplate.XAxisStyle != null)
            {
                XChartStyleTemplate.XAxisStyle(XAxis);
            }
            if (XChartStyleTemplate.YAxisStyle != null)
            {
                XChartStyleTemplate.YAxisStyle(YAxis);
            }
            if (XChartStyleTemplate.X2AxisStyle != null)
            {
                XChartStyleTemplate.X2AxisStyle(X2Axis);
            }
            if (XChartStyleTemplate.Y2AxisStyle != null)
            {
                XChartStyleTemplate.Y2AxisStyle(Y2Axis);
            }
            if (PrimaryPlot != null)
            {
                PrimaryPlot.ApplyCurrentStyle();
            }
            if (SecondaryPlot != null)
            {
                SecondaryPlot.ApplyCurrentStyle();
            }
        }
    }
}