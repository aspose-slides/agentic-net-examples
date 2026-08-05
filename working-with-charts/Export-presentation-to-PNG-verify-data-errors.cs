// -----------------------------------------------------------------------------
// Example: Export presentation to PNG verify data errors using C#
//
// Description:
// Demonstrates how to export a PowerPoint presentation to PNG images while
// verifying data error bars in charts using C# and Aspose.Slides for .NET.
// The example loads or creates a presentation, adds a bubble chart with X and Y
// error bars, exports each slide as a PNG image, and saves the updated
// presentation. This pattern helps developers automate slide image generation
// and validate chart error data in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Presentation,
// Verify, Data Errors, Error Bars, Charts, Image Export, Office Automation
//
// Use Cases:
// - Automate export of presentation slides to PNG while checking chart error bars.
// - Build C# tools for PowerPoint chart validation and image generation.
// - Generate or transform PPTX files with chart data verification in .NET apps.
// - Validate presentation workflows before publishing or integration.
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
        static void Main()
        {
            // Paths
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string outputImagesFolder = "Images";

            // Ensure the images folder exists
            if (!Directory.Exists(outputImagesFolder))
            {
                Directory.CreateDirectory(outputImagesFolder);
            }

            // Load existing presentation if it exists, otherwise create a new one
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                try
                {
                    presentation = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Format not supported or other loading error
                    Console.WriteLine("Failed to load presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                // Create a new presentation with a default slide
                presentation = new Presentation();

                // Add a chart with error bars and a data table to the first slide
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.Bubble, 50f, 50f, 400f, 300f, true);

                // Enable data table visibility
                chart.HasDataTable = true;

                // Access the first series (sample data is already present)
                IChartSeries series = chart.ChartData.Series[0];

                // Configure X error bars
                IErrorBarsFormat errorBarsX = series.ErrorBarsXFormat;
                errorBarsX.IsVisible = true;
                errorBarsX.ValueType = ErrorBarValueType.Fixed;
                errorBarsX.Value = 5f; // Fixed length
                errorBarsX.Type = ErrorBarType.Plus;
                errorBarsX.HasEndCap = true;

                // Configure Y error bars
                IErrorBarsFormat errorBarsY = series.ErrorBarsYFormat;
                errorBarsY.IsVisible = true;
                errorBarsY.ValueType = ErrorBarValueType.Percentage;
                errorBarsY.Value = 10f; // 10 percent
                errorBarsY.Type = ErrorBarType.Both;
                errorBarsY.HasEndCap = true;
                errorBarsY.Format.Line.Width = 2;
            }

            // Export each slide to PNG using GetImage (replaces GetThumbnail)
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                ISlide slide = presentation.Slides[i];
                IImage slideImage = slide.GetImage(1f, 1f);
                string imagePath = Path.Combine(outputImagesFolder, $"Slide_{i + 1}.png");
                try
                {
                    slideImage.Save(imagePath, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    // Handle image saving errors (e.g., unsupported format)
                    Console.WriteLine("Failed to save slide image: " + ex.Message);
                }
            }

            // Save the presentation before exiting
            try
            {
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle presentation saving errors
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
