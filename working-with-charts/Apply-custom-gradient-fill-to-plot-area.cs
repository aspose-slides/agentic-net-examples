// -----------------------------------------------------------------------------
// Example: Apply custom gradient fill to plot area using C#
//
// Description:
// Demonstrates how to apply a custom gradient fill to a chart's plot area using
// C# and Aspose.Slides for .NET. The example creates a new presentation, adds a
// clustered column chart, configures a gradient fill with defined gradient stops,
// and saves the result as a PPTX file. This pattern can be used to automate
// PowerPoint chart styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Custom, Gradient, Fill,
// Chart Plot Area, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying custom gradient fills to chart plot areas.
// - Build C# tools for styling PowerPoint charts programmatically.
// - Generate or transform PPTX files with customized chart appearances.
// - Validate chart formatting workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ApplyCustomGradientFillToPlotArea
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

                // Apply a gradient fill to the chart's plot area
                chart.PlotArea.Format.Fill.FillType = FillType.Gradient;
                chart.PlotArea.Format.Fill.GradientFormat.GradientDirection = GradientDirection.FromCorner1;
                chart.PlotArea.Format.Fill.GradientFormat.GradientShape = GradientShape.Rectangle;

                // Define gradient stops
                chart.PlotArea.Format.Fill.GradientFormat.GradientStops.Clear();
                chart.PlotArea.Format.Fill.GradientFormat.GradientStops.Add(0f, Color.LightBlue);
                chart.PlotArea.Format.Fill.GradientFormat.GradientStops.Add(1f, Color.DarkBlue);

                // Save the presentation
                try
                {
                    pres.Save("CustomGradientPlotArea.pptx", SaveFormat.Pptx);
                }
                catch (ArgumentException ex)
                {
                    // Handle unsupported format exception
                    Console.WriteLine("The specified format is not supported: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("An error occurred while saving the presentation: " + ex.Message);
                }
            }
        }
    }
}
