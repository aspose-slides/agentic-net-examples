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

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide at position (50, 50)
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50f, 50f, columnWidths, rowHeights);

        // Insert a new row (clone of the first row) at index 1
        Aspose.Slides.IRow firstRow = table.Rows[0];
        table.Rows.InsertClone(1, firstRow, false);

        // Remove the last row (index 3 after insertion)
        table.Rows.RemoveAt(3, false);

        // Save the presentation
        presentation.Save("ManagedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}