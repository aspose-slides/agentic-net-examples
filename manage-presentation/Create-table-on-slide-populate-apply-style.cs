// -----------------------------------------------------------------------------
// Example: Create table on slide populate apply style using C#
//
// Description:
// Demonstrates how to create a table on a slide, populate it with data, and
// apply a built‑in style using C# and Aspose.Slides for .NET. The example shows
// the required presentation‑processing steps for PowerPoint files and produces
// the requested output in a standalone console application. Developers can use
// this pattern to automate PPTX workflows, validate results, or integrate
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Table, Slide, Populate, Apply,
// Style, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of a styled table on a slide.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesTableExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths and row heights
                double[] columnWidths = { 100, 100, 100 };
                double[] rowHeights = { 50, 50, 50, 50 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Populate the table with sample data
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        // Retrieve the cell using the correct indexing (row first, then column) via Rows collection
                        Aspose.Slides.ICell cell = table.Rows[row][col];
                        cell.TextFrame.Text = $"R{row + 1}C{col + 1}";
                    }
                }

                // Apply a built‑in table style
                table.StylePreset = Aspose.Slides.TableStylePreset.LightStyle1Accent1;

                // Save the presentation with exception handling for unsupported formats
                try
                {
                    presentation.Save("TablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
            }
        }
    }
}
