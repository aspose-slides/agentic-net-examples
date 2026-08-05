// -----------------------------------------------------------------------------
// Example: Export chart as EMF vector using C#
//
// Description:
// Demonstrates how to create a PowerPoint presentation, add a chart, save the
// presentation, and export the slide containing the chart as an EMF vector file
// using Aspose.Slides for .NET. The example illustrates the required steps for
// chart creation, presentation saving, and EMF export in a console application.
// Developers can adapt this pattern to automate chart extraction or generate
// vector graphics from PPTX files.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, EMF, Vector Export, Presentation
// Processing, Office Automation
//
// Use Cases:
// - Automate conversion of PowerPoint chart slides to EMF vector graphics.
// - Build tools that extract high‑resolution chart images from presentations.
// - Integrate chart export functionality into .NET applications.
// - Generate vector assets for documentation or publishing workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            var presentation = new Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a sample chart to the slide
            var chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Save the presentation (required before exit)
            var pptxPath = "ChartPresentation.pptx";
            presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Export the slide containing the chart as a vector EMF file
            var emfPath = "ChartSlide.emf";
            using (var emfStream = File.Create(emfPath))
            {
                slide.WriteAsEmf(emfStream);
            }

            // Clean up resources
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions as needed
        }
    }
}
