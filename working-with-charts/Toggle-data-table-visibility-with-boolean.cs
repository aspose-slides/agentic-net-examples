// -----------------------------------------------------------------------------
// Example: Toggle data table visibility with boolean using C#
//
// Description:
// Demonstrates how to toggle the visibility of a chart data table using a
// boolean command‑line argument with C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a clustered column chart, sets the
// HasDataTable property according to the supplied value, and saves the result.
// This pattern helps automate PPTX workflows that require conditional data
// table display.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Toggle, Data, Table,
// Visibility, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate toggling of chart data table visibility based on runtime input.
// - Build .NET tools that generate or modify PowerPoint charts conditionally.
// - Integrate presentation logic into applications that need dynamic chart
//   configurations.
// - Validate chart settings before publishing or further processing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine whether to show the data table from the first command‑line argument
        bool showDataTable = false;
        if (args.Length > 0)
        {
            bool parsed;
            if (bool.TryParse(args[0], out parsed))
            {
                showDataTable = parsed;
            }
        }

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a clustered column chart
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Toggle the data table visibility based on the parameter
        chart.HasDataTable = showDataTable;

        // Save the presentation
        string outputPath = "ToggleDataTable.pptx";
        pres.Save(outputPath, SaveFormat.Pptx);
    }
}
