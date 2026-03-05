using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 150, 150, 150, 150 };
        double[] rowHeights = new double[] { 100, 100, 100, 100, 90 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Access a cell using the ICell interface (avoid casting to Cell)
        Aspose.Slides.ICell cell = table[0, 0];

        // Modify cell properties (example: set top and bottom margins)
        cell.MarginTop = 5;
        cell.MarginBottom = 5;

        // Save the presentation before exiting
        presentation.Save("ManagedTableCells.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}