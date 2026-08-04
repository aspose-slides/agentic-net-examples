// -----------------------------------------------------------------------------
// Example: Set legend entry three font size ten using C#
//
// Description:
// Demonstrates how to set the font size of the third legend entry to ten points
// using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a clustered column chart, accesses the legend entry at index two, and
// modifies its text format. The presentation is then saved as a PPTX file.
// This pattern can be used to automate chart legend formatting in PowerPoint
// files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Legend, Entry, Font Size,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting specific legend entry font sizes in charts.
// - Build C# tools for customizing PowerPoint chart legends.
// - Generate or modify PPTX files with precise formatting requirements.
// - Validate chart appearance programmatically before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a clustered column chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Set the font size of the third legend entry (index 2) to 10 points
        Aspose.Slides.Charts.ILegendEntryProperties entry = chart.Legend.Entries[2];
        entry.TextFormat.PortionFormat.FontHeight = 10f;

        // Save the presentation
        try
        {
            presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format
            // (Comment: format not supported)
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
