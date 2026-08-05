// -----------------------------------------------------------------------------
// Example: Resize plot area using actual dimensions using C#
//
// Description:
// Demonstrates how to resize a chart's plot area to a percentage of its actual
// dimensions using Aspose.Slides for .NET. The example loads an existing PPTX,
// adds a clustered column chart, obtains the plot area's actual width and height,
// scales them to 80%, and saves the modified presentation. This pattern helps
// developers programmatically adjust chart layouts in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Resize, Plot Area, Actual Dimensions,
// Chart Layout, Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically adjust chart plot area size based on actual dimensions.
// - Automate PowerPoint chart formatting in .NET applications.
// - Create tools that fine‑tune visual presentation of data.
// - Validate and modify PPTX files before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                var presentation = new Presentation(inputPath);

                // Add a clustered column chart
                var chart = (Chart)presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);
                chart.ValidateChartLayout();

                // Get actual plot area dimensions
                var actualWidth = chart.PlotArea.ActualWidth;
                var actualHeight = chart.PlotArea.ActualHeight;

                // Resize plot area to 80% of its actual size (custom dimensions)
                chart.PlotArea.Width = (float)(actualWidth * 0.8);
                chart.PlotArea.Height = (float)(actualHeight * 0.8);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
