// -----------------------------------------------------------------------------
// Example: Add data point callout showlabelasdatacallout using C#
//
// Description:
// Demonstrates how to add a data point callout by enabling ShowLabelAsDataCallout
// for a chart series using C# and Aspose.Slides for .NET. The example creates a
// clustered column chart, activates data callouts for the series, customizes the
// first data point's callout appearance, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Point, Callout,
// ShowLabelAsDataCallout, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding data point callouts with ShowLabelAsDataCallout.
// - Build C# utilities for PowerPoint chart customization.
// - Generate or modify PPTX files with customized chart callouts in .NET.
// - Validate chart presentation workflows before deployment.
// -----------------------------------------------------------------------------
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
