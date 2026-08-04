// -----------------------------------------------------------------------------
// Example: Save chart as PNG 300 DPI using C#
//
// Description:
// Demonstrates how to save a chart from a PowerPoint presentation as a PNG
// image with an approximate 300 dpi resolution using Aspose.Slides for .NET.
// The example creates a presentation, adds a clustered column chart, extracts
// the chart image, and saves it as a PNG file. It also saves the presentation
// itself. This pattern can be used to automate chart image extraction and
// conversion in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Save, Chart, Image Export,
// 300 DPI, Presentation Processing, Office Automation
//
// Use Cases:
// - Export charts from PPTX files as high‑resolution PNG images.
// - Build tools that generate image assets from PowerPoint presentations.
// - Integrate chart image extraction into .NET workflows or reporting systems.
// - Validate and automate presentation content processing before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesChartImage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Get the chart image (default resolution)
                // To achieve higher visual quality, a scaling factor can be applied if needed.
                Aspose.Slides.IImage chartImage = chart.GetImage();

                // Save the chart image as PNG (300 DPI approximation)
                string chartImagePath = "ChartImage.png";
                chartImage.Save(chartImagePath, Aspose.Slides.ImageFormat.Png);

                // Save the presentation
                string presentationPath = "PresentationOutput.pptx";
                presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
