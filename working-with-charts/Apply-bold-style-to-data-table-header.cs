// -----------------------------------------------------------------------------
// Example: Apply bold style to chart data table header using C#
//
// Description:
// Demonstrates how to apply a bold font style to the header row of a chart's
// data table using C# and Aspose.Slides for .NET. The example creates a simple
// clustered column chart, enables its data table, sets the header text to bold,
// and saves the presentation as a PPTX file. This pattern can be used to
// customize chart data tables in automated PowerPoint generation scenarios.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Data Table, Header, Bold,
// Font Style, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying bold style to chart data table headers.
// - Build C# tools for customizing chart appearance in PowerPoint files.
// - Generate or modify PPTX presentations with styled chart data tables.
// - Ensure consistent visual formatting of chart data across presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ChartDataTableBoldHeader.pptx";

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);
        chart.HasDataTable = true;

        // Apply bold style to the header row of the data table
        chart.ChartDataTable.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
