using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define output file path
        string outPath = Path.Combine(Directory.GetCurrentDirectory(), "GetCellOutput.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Access a cell using the table indexer (column 0, row 0)
        Aspose.Slides.ICell cell = table[0, 0];

        // Set text in the cell
        cell.TextFrame.Text = "Hello Aspose.Slides";

        // Retrieve the same cell (demonstrating GetCell functionality)
        Aspose.Slides.ICell retrievedCell = table[0, 0];
        Console.WriteLine(retrievedCell.TextFrame.Text);

        // Save the presentation before exiting
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}