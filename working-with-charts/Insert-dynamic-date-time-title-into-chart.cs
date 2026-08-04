// -----------------------------------------------------------------------------
// Example: Insert dynamic date time title into chart using C#
//
// Description:
// Demonstrates how to insert a dynamic date and time title into a chart using C# 
// and Aspose.Slides for .NET. The example shows the required presentation‑processing 
// steps for PowerPoint files and produces the requested output in a standalone 
// console application. Developers can use this pattern to automate PPTX workflows, 
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Dynamic, Date, Time, 
// Chart Title, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of a dynamic date‑time title into a chart.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a chart to the slide
            IChart chart = slide.Shapes.AddChart(
                ChartType.ClusteredColumn,
                50f, 50f, 500f, 400f);

            // Set chart title with current date and time
            chart.HasTitle = true;
            string titleText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            chart.ChartTitle.AddTextFrameForOverriding(titleText);
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
            chart.ChartTitle.Height = 30f;
            chart.ChartTitle.Width = 500f;
            chart.ChartTitle.Y = 10f;
            chart.ChartTitle.X = 50f;

            // Save the presentation
            string outputPath = "ChartWithDateTimeTitle.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
        }
    }
}
