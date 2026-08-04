// -----------------------------------------------------------------------------
// Example: Export chart as high resolution JPEG using C#
//
// Description:
// Demonstrates how to create a PowerPoint presentation, add a clustered column
// chart, extract the chart as an image, and save it as a high‑resolution JPEG
// (quality = 100) using Aspose.Slides for .NET. The example also saves the
// generated presentation file. This pattern can be used to automate chart
// extraction and high‑quality image generation from PPTX files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Chart, High,
// Resolution, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of charts as high resolution JPEG images.
// - Build C# tools for PowerPoint presentation processing and image extraction.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file paths
            string presentationPath = "output.pptx";
            string chartImagePath = "chart_highres.jpg";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a clustered column chart to the first slide
                IChart chart = presentation.Slides[0].Shapes.AddChart(
                    ChartType.ClusteredColumn,
                    50f,   // X position
                    50f,   // Y position
                    500f,  // Width
                    400f   // Height
                );

                // Obtain the chart image (default size)
                IImage chartImage = chart.GetImage();

                // Save the chart image as a high‑resolution JPEG (quality = 100)
                chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Jpeg, 100);

                // Save the presentation
                presentation.Save(presentationPath, SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
