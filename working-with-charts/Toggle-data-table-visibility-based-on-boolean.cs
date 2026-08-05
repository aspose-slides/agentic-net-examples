// -----------------------------------------------------------------------------
// Example: Toggle data table visibility based on boolean using C#
//
// Description:
// Demonstrates how to toggle the visibility of a chart data table in a PowerPoint
// presentation based on a boolean value supplied via command‑line arguments. The
// example creates a new presentation, adds a clustered column chart, sets the
// HasDataTable property according to the parsed boolean, and saves the file as
// a PPTX using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Toggle, Data Table, Visibility,
// Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically show or hide chart data tables based on runtime conditions.
// - Build command‑line utilities for PowerPoint chart customization.
// - Integrate chart visibility logic into larger .NET automation workflows.
// - Generate PPTX files with dynamic chart configurations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine whether to show the data table based on a command‑line argument
        bool showDataTable = false;
        if (args.Length > 0)
        {
            Boolean.TryParse(args[0], out showDataTable);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.ClusteredColumn,
            0f, 0f, 500f, 400f);

        // Toggle the data table visibility
        chart.HasDataTable = showDataTable;

        // Save the presentation
        try
        {
            presentation.Save("ToggleDataTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}
