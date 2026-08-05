// -----------------------------------------------------------------------------
// Example: Export chart as highresolution TIFF archival using C#
//
// Description:
// Demonstrates how to export a chart as a high‑resolution TIFF archival image 
// using C# and Aspose.Slides for .NET. The example creates a presentation, adds 
// a clustered column chart, renders the slide containing the chart to a TIFF 
// image with 300 DPI, and saves both the image and the presentation.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Chart, Highresolution, 
// TIFF, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of chart visuals as high‑resolution TIFF archival files.
// - Build C# tools for PowerPoint presentation processing and image extraction.
// - Generate or transform PPTX files in .NET applications with chart rendering.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a clustered column chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Define high‑resolution TIFF options (300 DPI)
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.DpiX = 300u;
            tiffOptions.DpiY = 300u;

            // Render the slide (which contains the chart) to a TIFF image
            IImage slideImage = presentation.Slides[0].GetImage(tiffOptions);

            // Save the TIFF image to disk
            slideImage.Save("ChartHighRes.tiff", ImageFormat.Tiff);

            // Save the presentation (optional, but required before exit)
            presentation.Save("ChartPresentation.pptx", SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}
