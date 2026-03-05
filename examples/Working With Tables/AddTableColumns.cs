using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define initial column widths and row heights
        double[] columnWidths = new double[] { 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Get the column collection of the table
        Aspose.Slides.IColumnCollection columns = table.Columns;

        // Use the first column as a template for the new column
        Aspose.Slides.IColumn templateColumn = columns[0];

        // Insert a new column at index 2 (after the existing columns)
        columns.InsertClone(2, templateColumn, true);

        // Set the width of the newly added column
        columns[2].Width = 120;

        // Save the presentation
        pres.Save("AddColumns.pptx", SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}