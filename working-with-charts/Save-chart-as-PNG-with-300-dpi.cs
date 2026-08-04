// -----------------------------------------------------------------------------
// Example: Save chart as PNG with 300 dpi using C#
//
// Description:
// Demonstrates how to create a chart in a new presentation, render the chart
// to a PNG image at approximately 300 DPI, and save both the image and the
// presentation file using Aspose.Slides for .NET. The example shows the
// required presentation‑processing steps for PowerPoint files and produces
// the requested high‑resolution output in a standalone console application.
// Developers can use this pattern to automate PPTX workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Save, Chart, 300 DPI,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate saving a chart as a high‑resolution PNG (≈300 dpi).
// - Build C# tools for PowerPoint presentation processing and image extraction.
// - Generate or transform PPTX files in .NET applications while preserving chart quality.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string chartImagePath = "chart.png";
            string presentationPath = "chartPresentation.pptx";

            Presentation presentation = new Presentation();
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                0f, 0f, 500f, 400f);

            // Scale factor to achieve approximately 300 DPI (default is 96 DPI)
            float scale = 300f / 96f;

            IImage chartImage = chart.GetImage(
                ShapeThumbnailBounds.Shape,
                scale,
                scale);

            chartImage.Save(chartImagePath, ImageFormat.Png);
            presentation.Save(presentationPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs or I/O errors)
        }
    }
}
