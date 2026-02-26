using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableMergeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths and row heights
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50, 50 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Merge first two cells in the first row (columns 0 and 1)
                Aspose.Slides.ICell mergedCell1 = table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
                mergedCell1.TextFrame.Text = "Merged Columns";

                // Merge cells spanning the first column across the first two rows
                Aspose.Slides.ICell mergedCell2 = table.MergeCells(table.Rows[0][2], table.Rows[1][2], false);
                mergedCell2.TextFrame.Text = "Merged Rows";

                // Save the presentation
                presentation.Save("MergedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}