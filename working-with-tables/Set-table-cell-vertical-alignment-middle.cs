// -----------------------------------------------------------------------------
// Example: Set table cell vertical alignment middle using C#
//
// Description:
// Demonstrates how to set a table cell's vertical alignment to middle using 
// C# and Aspose.Slides for .NET. The example creates a presentation, adds a 
// table, inserts text into a cell, and configures the cell's text anchor to 
// center (vertical middle). It then saves the presentation as a PPTX file. 
// This pattern can be used to automate PPTX workflows, validate results, or 
// integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Cell, Vertical Alignment, 
// Text Anchor, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting table cell vertical alignment to middle.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "VerticallyAlignedTable.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] cols = new double[] { 100, 100, 100 };
        double[] rows = new double[] { 50, 50, 50 };

        // Add a table to the slide
        ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

        // Add text to the first cell
        table[0, 0].TextFrame.Text = "Centered Text";

        // Vertically align text to middle
        ICell cell = table[0, 0];
        cell.TextAnchorType = TextAnchorType.Center;
        cell.TextVerticalType = TextVerticalType.Vertical270;

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}
