using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50, 50 };

        // Add a table shape to the slide
        ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Remove the second row (index 1) without deleting attached rows
        table.Rows.RemoveAt(1, false);

        // Remove the first column (index 0) without deleting attached columns
        table.Columns.RemoveAt(0, false);

        // Save the modified presentation
        presentation.Save("TableModified.pptx", SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}