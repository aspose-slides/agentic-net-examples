// -----------------------------------------------------------------------------
// Example: Handle out of range column removal using C#
//
// Description:
// Demonstrates how to safely attempt removal of a table column that may be
// outside the valid range using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a table, checks the column index, and either
// reports an out‑of‑range condition or removes the column. The resulting PPTX
// is saved to disk.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Column Removal, Out of Range,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Validate column indices before modifying tables in PowerPoint files.
// - Build .NET utilities that manipulate PPTX tables safely.
// - Automate presentation workflows that involve dynamic table adjustments.
// - Prevent runtime errors when removing columns from tables.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define table dimensions
        double[] colWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, colWidths, rowHeights);

        // Index of the column to remove (intentionally out of range)
        int columnIndexToRemove = 5;

        try
        {
            // Validate column index before removal
            if (columnIndexToRemove < 0 || columnIndexToRemove >= table.Columns.Count)
            {
                Console.WriteLine("Column index out of range. Table has " + table.Columns.Count + " columns.");
            }
            else
            {
                // Remove the column
                table.Columns.RemoveAt(columnIndexToRemove, false);
                Console.WriteLine("Column removed successfully.");
            }
        }
        catch (Exception ex)
        {
            // Handle any unexpected errors
            Console.WriteLine("Error removing column: " + ex.Message);
        }

        // Save the presentation
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
