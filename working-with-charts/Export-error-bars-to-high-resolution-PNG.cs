// -----------------------------------------------------------------------------
// Example: Export error bars to high resolution PNG using C#
//
// Description:
// Demonstrates how to create a chart with error bars and export the presentation
// slides to high‑resolution PNG images using C# and Aspose.Slides for .NET. The
// example shows the required steps for adding a scatter chart with X and Y error
// bars, saving the presentation, and rendering each slide at 2× scaling.
// Developers can use this pattern to automate PPTX workflows, generate
// high‑quality chart images, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Error Bars, High
// Resolution, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of charts with error bars to high‑resolution PNG.
// - Build C# tools for PowerPoint presentation processing and image generation.
// - Generate or transform PPTX files containing error‑bar charts in .NET
//   applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ErrorBarsPngExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for output files
            string outputPresentationPath = "ErrorBarsPresentation.pptx";
            string outputImagePathPattern = "Slide_{0}.png";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a chart with error bars on the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 50f, 50f, 500f, 400f);
                IChartSeries series = chart.ChartData.Series[0];

                // Configure X error bars
                series.ErrorBarsXFormat.Type = ErrorBarType.Plus;
                series.ErrorBarsXFormat.Value = 0.5f;

                // Configure Y error bars
                series.ErrorBarsYFormat.Type = ErrorBarType.Plus;
                series.ErrorBarsYFormat.Value = 0.5f;

                // Save the presentation (required before exporting images)
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);

                // Export each slide to a high‑resolution PNG image (2x scaling)
                float scaleX = 2f;
                float scaleY = 2f;
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide currentSlide = presentation.Slides[i];
                    IImage image = currentSlide.GetImage(scaleX, scaleY);
                    string imagePath = string.Format(outputImagePathPattern, i + 1);
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                }

                // Dispose resources
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, rendering issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
