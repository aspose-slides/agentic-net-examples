// -----------------------------------------------------------------------------
// Example: Export animated chart to highresolution PNG using C#
//
// Description:
// Demonstrates how to export an animated chart from a PowerPoint presentation
// to a high‑resolution PNG image using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, locates the first chart on the first slide, renders the
// chart at double the default resolution, saves the image, and then saves the
// (potentially modified) presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Export, Animated, Chart,
// Highresolution, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of animated chart to high‑resolution PNG.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ExportAnimatedChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPresentationPath = "input.pptx";
            string outputChartImagePath = "chart.png";
            string outputPresentationPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPresentationPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPresentationPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPresentationPath);

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Find the first chart on the slide
                IChart chart = null;
                for (int i = 0; i < slide.Shapes.Count; i++)
                {
                    if (slide.Shapes[i] is IChart)
                    {
                        chart = (IChart)slide.Shapes[i];
                        break;
                    }
                }

                if (chart == null)
                {
                    Console.WriteLine("No chart found on the first slide.");
                }
                else
                {
                    // Export the chart as a high‑resolution PNG image
                    // Using ShapeThumbnailBounds.Shape with scaling factors for high resolution
                    IImage chartImage = chart.GetImage(ShapeThumbnailBounds.Shape, 2f, 2f);
                    chartImage.Save(outputChartImagePath, ImageFormat.Png);
                }

                // Save the (potentially modified) presentation
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
