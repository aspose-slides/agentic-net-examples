using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights (in points)
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Set text for a specific cell (row 0, column 1)
        Aspose.Slides.ICell cell = table.Rows[0][1];
        cell.TextFrame.Text = "Hello, Aspose!";

        // Save the presentation to disk
        presentation.Save("TableCellText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}