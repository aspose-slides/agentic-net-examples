using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Access the first slide
        var slide = pres.Slides[0];

        // Define column widths and row heights (in points)
        double[] colWidths = { 100, 100, 100 };
        double[] rowHeights = { 50, 50, 50 };

        // Add a table to the slide
        var table = slide.Shapes.AddTable(50, 50, colWidths, rowHeights);

        // Merge first two cells in the first row (horizontal merge)
        table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);

        // Merge cells vertically: first cell of column 2 in rows 0 and 1
        table.MergeCells(table.Rows[0][2], table.Rows[1][2], false);

        // Add text to the merged cells
        table.Rows[0][0].TextFrame.Text = "Merged horizontally";
        table.Rows[0][2].TextFrame.Text = "Merged vertically";

        // Save the presentation
        pres.Save("MergedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}