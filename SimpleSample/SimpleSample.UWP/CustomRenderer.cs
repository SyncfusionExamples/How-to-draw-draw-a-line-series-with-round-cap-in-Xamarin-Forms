using SimpleSample;
using SimpleSample.UWP;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfChart.XForms.UWP;
using Native = Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Platform.UWP;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media;
using System.Reflection;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ChartExt), typeof(CustomChartRenderer))]
namespace SimpleSample.UWP
{
    public class CustomChartRenderer : SfChartRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                SetLineJoinEffect(Control.Series);
            }
        }
        private void SetLineJoinEffect(Native.ChartSeriesCollection chartSeries)
        {
            foreach (var series in chartSeries)
            {
                Native.LineSeries lineSeries = series as Native.LineSeries;
                if (lineSeries != null)
                {
                    var segment = typeof(Native.ChartSeriesBase).GetField("Segments", BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic).GetValue(lineSeries) as ObservableCollection<Native.ChartSegment>;
                    if (segment != null)
                    {
                        foreach (var lineSegment in segment)
                        {
                            var segPath = lineSegment.GetRenderedVisual();
                            if (segPath != null)
                            {
                                (segPath as Line).StrokeStartLineCap = PenLineCap.Round;
                                (segPath as Line).StrokeEndLineCap = PenLineCap.Round;
                            }
                               
                        }
                    }
                }
            }
        }
    }

}
