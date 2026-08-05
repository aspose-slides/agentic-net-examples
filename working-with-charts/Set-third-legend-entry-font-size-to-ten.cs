// -----------------------------------------------------------------------------
// Example: Set third legend entry font size to ten using C#
//
// Description:
// Demonstrates how to set the font size of the third legend entry in a chart
// to ten points using C# and Aspose.Slides for .NET. The example creates a
// presentation, adds a clustered column chart, modifies the legend entry, and
// saves the result as a PPTX file. This pattern can be used to automate
// PowerPoint presentation processing, customize chart legends, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Third, Legend, Entry, Font,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting the font size of a specific legend entry in charts.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with customized chart legends.
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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);
        // Set the font size of the third legend entry (index 2) to 10 points
        Aspose.Slides.Charts.ILegendEntryProperties entry = chart.Legend.Entries[2];
        entry.TextFormat.PortionFormat.FontHeight = 10f;
        // Save the presentation
        presentation.Save("LegendFontSize.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose the presentation
        presentation.Dispose();
    }
}
