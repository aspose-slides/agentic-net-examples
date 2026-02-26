using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Clone the first row to use as a template for the new row
        Aspose.Slides.IRow templateRow = table.Rows[0];

        // Insert the cloned row at position 2 (after the second existing row)
        table.Rows.InsertClone(2, templateRow, false);

        // Set text for each cell in the newly inserted row
        for (int col = 0; col < table.Columns.Count; col++)
        {
            table.Rows[2][col].TextFrame.Text = "New Row";
        }

        // Save the presentation
        presentation.Save("InsertRowTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}