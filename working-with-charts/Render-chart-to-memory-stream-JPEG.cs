// -----------------------------------------------------------------------------
// Example: Render chart to memory stream JPEG using C#
//
// Description:
// Demonstrates how to create a chart in a presentation, render the slide
// containing the chart to a JPEG image stored in a memory stream, and save
// the presentation using Aspose.Slides for .NET. The example includes the
// essential steps for chart creation, slide rendering, image saving to a
// MemoryStream, and cleanup.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Render, Chart, Memory,
// Stream, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate a JPEG image of a chart without writing to disk.
// - Build .NET tools that need in‑memory image processing of PowerPoint slides.
// - Automate creation and rendering of chart visuals for web or API services.
// - Validate chart rendering as part of a presentation workflow.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace RenderChartToMemoryStream
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = pres.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // (Optional) Customize chart data here if needed

            // Render the slide (which contains the chart) to an image
            IImage slideImage = pres.Slides[0].GetImage(1f, 1f);

            // Create a memory stream to hold the JPEG image
            MemoryStream jpegStream = new MemoryStream();

            try
            {
                // Save the image to the memory stream in JPEG format with quality 80
                slideImage.Save(jpegStream, Aspose.Slides.ImageFormat.Jpeg, 80);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle accordingly
            }

            // Reset stream position for further use
            jpegStream.Position = 0;

            // Save the presentation before exiting
            try
            {
                pres.Save("ChartPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception)
            {
                // Handle save errors (e.g., unsupported format)
            }

            // Clean up resources
            slideImage.Dispose();
            pres.Dispose();
        }
    }
}
