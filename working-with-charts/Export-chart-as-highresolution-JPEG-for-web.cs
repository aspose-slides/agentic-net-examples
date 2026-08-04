// -----------------------------------------------------------------------------
// Example: Export chart as highresolution JPEG for web using C#
//
// Description:
// Demonstrates how to export a chart as a high‑resolution JPEG for web using C# 
// and Aspose.Slides for .NET. The example creates a presentation, adds a clustered 
// column chart, extracts the chart image, saves it as a JPEG with maximum quality, 
// and finally saves the presentation. This pattern can be used to automate PPTX 
// workflows, validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Chart, 
// Highresolution, Jpeg, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export of chart as high‑resolution JPEG for web.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a clustered column chart to the first slide
        IChart chart = presentation.Slides[0].Shapes.AddChart(
            ChartType.ClusteredColumn,
            50f, 50f, 500f, 400f);

        // Get the chart image (default size)
        IImage chartImage = chart.GetImage();

        // Save the chart image as a high‑resolution JPEG (quality 100)
        try
        {
            chartImage.Save("ChartImage.jpg", ImageFormat.Jpeg, 100);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Save the presentation before exiting
        presentation.Save("ChartPresentation.pptx", SaveFormat.Pptx);
        presentation.Dispose();
    }
}
