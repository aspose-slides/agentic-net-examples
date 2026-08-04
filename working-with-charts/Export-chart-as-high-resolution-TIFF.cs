// -----------------------------------------------------------------------------
// Example: Export chart as high resolution TIFF using C#
//
// Description:
// Demonstrates how to export a chart from a PowerPoint slide to a high
// resolution TIFF image using C# and Aspose.Slides for .NET. The example creates
// a presentation, adds a chart, configures TIFF DPI settings, renders the slide
// containing the chart to an image, and saves both the presentation and the
// TIFF file. Developers can use this pattern to automate chart export, build
// .NET tools for PowerPoint processing, or validate presentation workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Chart, High,
// Resolution, TIFF, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of chart as high resolution TIFF.
// - Build C# utilities for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartToTiffExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for output files
            string presentationPath = "ChartPresentation.pptx";
            string chartTiffPath = "ChartImage.tiff";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a chart to the first slide
            IChart chart = presentation.Slides[0].Shapes.AddChart(
                ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // (Optional) Customize chart data here if needed

            // Define high‑resolution TIFF options
            TiffOptions tiffOptions = new TiffOptions();
            tiffOptions.DpiX = 300U; // Horizontal DPI
            tiffOptions.DpiY = 300U; // Vertical DPI

            try
            {
                // Render the slide (which contains the chart) to a TIFF image
                IImage chartImage = presentation.Slides[0].GetImage(tiffOptions);

                // Save the chart image as TIFF
                chartImage.Save(chartTiffPath, ImageFormat.Tiff);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Save the presentation before exiting
            presentation.Save(presentationPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}
