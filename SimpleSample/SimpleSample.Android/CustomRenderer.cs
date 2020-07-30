using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using SimpleSample;
using SimpleSample.Droid;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfChart.XForms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.Graphics.Paint;
using Native = Com.Syncfusion.Charts;

[assembly: ExportRenderer(typeof(ChartExt), typeof(CustomChartRenderer))]
namespace SimpleSample.Droid
{
    public class CustomChartRenderer : SfChartRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Syncfusion.SfChart.XForms.SfChart> e)
        {
            base.OnElementChanged(e);
        }

        public override SfChartExt CreateNativeChart()
        {
            return new CustomChart(Android.App.Application.Context);
        }
    }


    public class CustomChart : SfChartExt
    {
        public CustomChart(Android.Content.Context context) : base(context)
        {

        }

        protected override Com.Syncfusion.Charts.ChartSeries CreateNativeChartSeries(Syncfusion.SfChart.XForms.ChartSeries formSeries)
        {
            if (formSeries is Syncfusion.SfChart.XForms.LineSeries)
            {
                return new CustomLineSeries();
            }
            return base.CreateNativeChartSeries(formSeries);
        }

    }

    public class CustomLineSeries : Native.LineSeries
    {
        Native.SeriesRenderer seriesRenderer;

        protected override Native.ChartSegment CreateSegment()
        {
            return new CustomLineSegment();
        }

        protected override void OnAttachedToChart()
        {
            base.OnAttachedToChart();
            seriesRenderer.SetLayerType(Android.Views.LayerType.Software, null);
        }

        protected override Native.SeriesRenderer GetView()
        {
            seriesRenderer = base.GetView();
            return base.GetView();
        }
    }

    public class CustomLineSegment : Native.LineSegment
    {
        private readonly float width = 5;
        Paint paint = new Paint();

        public override void OnDraw(Canvas canvas)
        {
           
            paint.StrokeWidth = this.Series.StrokeWidth + width;
            paint.Color = this.Color;
            paint.StrokeCap = Cap.Round;
            canvas.DrawLine(this.X1, this.Y1, this.X2, this.Y2, paint);
        }
    }
}