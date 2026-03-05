using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MergeTableCellsExample
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
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50 };

            // Add a table to the slide
            ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Merge first two cells in the first row (columns 0 and 1)
            ICell mergedCellColumns = table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);

            // Merge first two cells in the first column (rows 0 and 1)
            ICell mergedCellRows = table.MergeCells(table.Rows[0][0], table.Rows[1][0], false);

            // Add text to the merged cells
            mergedCellColumns.TextFrame.Text = "Merged Across Columns";
            mergedCellRows.TextFrame.Text = "Merged Across Rows";

            // Save the presentation
            pres.Save("MergedTable.pptx", SaveFormat.Pptx);
        }
    }
}