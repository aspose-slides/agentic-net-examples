// -----------------------------------------------------------------------------
// Example: Reorder table columns alphabetically by header using C#
//
// Description:
// Demonstrates how to reorder table columns alphabetically by header using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reorder, Table, Columns, 
// Alphabetically, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate reorder table columns alphabetically by header.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableColumnReorderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50 };

            // Add a table to the slide
            ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Fill header row with unsorted values
            string[] headers = new string[] { "Banana", "Apple", "Cherry", "Date" };
            for (int col = 0; col < headers.Length; col++)
            {
                ICell headerCell = table[col, 0];
                headerCell.TextFrame.Text = headers[col];
            }

            // Fill some sample data for remaining rows
            for (int row = 1; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    ICell dataCell = table[col, row];
                    dataCell.TextFrame.Text = $"R{row}C{col}";
                }
            }

            // Collect header texts with their original column indexes
            List<Tuple<string, int>> headerList = new List<Tuple<string, int>>();
            for (int col = 0; col < table.Columns.Count; col++)
            {
                ICell headerCell = table[col, 0];
                string text = headerCell.TextFrame.Text;
                headerList.Add(new Tuple<string, int>(text, col));
            }

            // Sort headers alphabetically
            headerList.Sort((a, b) => string.Compare(a.Item1, b.Item1, StringComparison.Ordinal));

            // Create a new table to hold reordered columns
            ITable newTable = slide.Shapes.AddTable(50, 150, columnWidths, rowHeights);

            // Copy cells from original table to new table based on sorted order
            for (int newCol = 0; newCol < headerList.Count; newCol++)
            {
                int originalCol = headerList[newCol].Item2;
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    ICell sourceCell = table[originalCol, row];
                    ICell targetCell = newTable[newCol, row];
                    targetCell.TextFrame.Text = sourceCell.TextFrame.Text;
                }
            }

            // Remove the original table shape from the slide
            IShape originalShape = table as IShape;
            if (originalShape != null)
            {
                slide.Shapes.Remove(originalShape);
            }

            // Save the presentation
            try
            {
                pres.Save("ReorderedTable.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            finally
            {
                pres.Dispose();
            }
        }
    }
}
