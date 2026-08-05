// -----------------------------------------------------------------------------
// Example: Add callout with custom fill to scatter using C#
//
// Description:
// Demonstrates how to add a callout with a custom fill to a scatter chart using
// C# and Aspose.Slides for .NET. The example creates a presentation, inserts a
// scatter chart, adds data points, enables callouts for data labels, and applies
// custom fill and line colors to a specific outlier point's callout.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Callout, Custom Fill, Scatter Chart,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding callouts with custom styling to scatter charts.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify PPTX files with customized chart annotations.
// - Validate chart appearance programmatically before distribution.
// -----------------------------------------------------------------------------

using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddCalloutToScatterChart
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add a scatter chart with markers
                    Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                        Aspose.Slides.Charts.ChartType.ScatterWithMarkers,
                        50f, 50f, 500f, 400f);

                    // Prepare the chart data workbook
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    int defaultWorksheetIndex = 0;

                    // Clear any default series and categories
                    chart.ChartData.Series.Clear();
                    chart.ChartData.Categories.Clear();

                    // Add a new series
                    Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                        workbook.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"),
                        chart.Type);

                    // Add data points (X, Y)
                    series.DataPoints.AddDataPointForScatterSeries(1.0, 2.0);
                    series.DataPoints.AddDataPointForScatterSeries(2.0, 3.0);
                    // Outlier point
                    series.DataPoints.AddDataPointForScatterSeries(5.0, 8.0);

                    // Enable callouts for data labels in the series
                    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

                    // Customize the outlier point's callout appearance
                    Aspose.Slides.Charts.IChartDataPoint outlierPoint = series.DataPoints[2];
                    outlierPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
                    outlierPoint.Format.Fill.SolidFillColor.Color = Color.Red;
                    outlierPoint.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    outlierPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.Black;

                    // Save the presentation
                    presentation.Save("ScatterChartWithCallout.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other exception: ex.Message
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
