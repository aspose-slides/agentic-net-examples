using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and initial row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Insert a new row at index 1 (between the two existing rows) by cloning the first row
        Aspose.Slides.IRow[] insertedRows = table.Rows.InsertClone(1, table.Rows[0], false);

        // Set text for cells in the newly inserted row
        Aspose.Slides.IRow newRow = insertedRows[0];
        newRow[0].TextFrame.Text = "New Row Cell 1";
        newRow[1].TextFrame.Text = "New Row Cell 2";
        newRow[2].TextFrame.Text = "New Row Cell 3";

        // Save the presentation
        presentation.Save("TableRowInserted.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}