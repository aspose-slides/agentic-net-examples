// -----------------------------------------------------------------------------
// Example: Apply conditional formatting to pie slices using C#
//
// Description:
// Demonstrates how to apply conditional formatting to pie slices using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Conditional, Formatting, 
// Slices, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate apply conditional formatting to pie slices.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ConditionalPieChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "ConditionalPieChart.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a pie chart
            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie,
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Get the first series (the chart is created with a default series)
            Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

            // Ensure the series uses literal double values
            series.DataPoints.DataSourceTypeForValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

            // Sample data values
            double[] values = new double[] { 30.0, 70.0, 110.0 };

            // Add data points and apply conditional colors
            foreach (double val in values)
            {
                // Add the data point
                Aspose.Slides.Charts.IChartDataPoint point = series.DataPoints.AddDataPointForPieSeries(val);

                // Set fill type to solid
                point.Format.Fill.FillType = Aspose.Slides.FillType.Solid;

                // Apply color based on value thresholds
                if (val < 50.0)
                {
                    point.Format.Fill.SolidFillColor.Color = Color.Green;
                }
                else if (val < 100.0)
                {
                    point.Format.Fill.SolidFillColor.Color = Color.Orange;
                }
                else
                {
                    point.Format.Fill.SolidFillColor.Color = Color.Red;
                }
            }

            // Optional: add a title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("Sales Distribution");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;
            chart.ChartTitle.Height = 20;

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}
