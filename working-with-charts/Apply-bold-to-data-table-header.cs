// -----------------------------------------------------------------------------
// Example: Apply bold to data table header using C#
//
// Description:
// Demonstrates how to apply bold to data table header using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Bold, Data, Table, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate apply bold to data table header.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Get the chart's data table
            IDataTable dataTable = chart.ChartDataTable;

            // Apply bold style to the header row (using TextFormat.PortionFormat)
            dataTable.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

            // Save the presentation
            try
            {
                pres.Save("ChartDataTableBoldHeader.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}
