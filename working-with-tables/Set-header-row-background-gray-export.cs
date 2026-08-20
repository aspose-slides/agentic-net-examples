// -----------------------------------------------------------------------------
// Example: Set header row background gray export using C#
//
// Description:
// Demonstrates how to set header row background gray export using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Header, Background, Gray, 
// Export, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set header row background gray export.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 40, 30, 30, 30 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Mark the first row as a header row (optional)
        table.FirstRow = true;

        // Set background color of header row cells to light gray using solid fill
        for (int col = 0; col < table.Columns.Count; col++)
        {
            Aspose.Slides.ICell headerCell = table[0, col];
            headerCell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            headerCell.CellFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.LightGray;
        }

        // Save the presentation
        presentation.Save("HeaderTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
