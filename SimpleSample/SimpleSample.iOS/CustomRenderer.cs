using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Native = Syncfusion.SfChart.iOS;
using Foundation;
using SimpleSample;
using SimpleSample.iOS;

[assembly: ExportRenderer(typeof(ChartExt), typeof(CustomChartRenderer))]
namespace SimpleSample.iOS
{
    public class CustomChartRenderer : SfChartRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SfChart> e)
        {
            base.OnElementChanged(e);
        }

        public override Native.SFChart CreateNativeChart()
        {
            return new CustomChart();
        }

    }

    public class CustomChart : Native.SFChart
    {
        protected override Native.SFSeries CreateNativeChartSeries(ChartSeries formSeries)
        {
            if (formSeries is LineSeries)
            {
                return new CustomLineSeries();
            }

            return base.CreateNativeChartSeries(formSeries);
        }
    }

    public class CustomLineSeries : Native.SFLineSeries
    {
        protected override Native.SFChartSegment CreateSegment()
        {
            return new CustomLineSegment();
        }
    }

    public class CustomLineSegment : Native.SFLineSegment
    {

        CGPath path = new CGPath();
       
        public override void DrawSegment(CGContext context)
        {
            context.SaveState();
            context.SetLineCap(CGLineCap.Round);
            base.DrawSegment(context);
            context.RestoreState();
        }
        
    }

}