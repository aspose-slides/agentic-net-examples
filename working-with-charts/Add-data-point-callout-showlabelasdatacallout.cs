using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddChartCalloutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide's shape collection
                IShapeCollection shapes = presentation.Slides[0].Shapes;

                // Add a clustered column chart
                IChart chart = shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Access the first series of the chart
                IChartSeries series = chart.ChartData.Series[0];

                // Enable data callout for all data labels in this series
                series.Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                // Style the callout of the first data point
                IChartDataPoint dataPoint = series.DataPoints[0];
                dataPoint.Format.Fill.FillType = FillType.Solid;
                dataPoint.Format.Fill.SolidFillColor.Color = Color.Red;
                dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
                dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;

                // Save the presentation
                presentation.Save("ChartCallout_out.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception)
            {
                // Handle other exceptions
            }
        }
    }
}