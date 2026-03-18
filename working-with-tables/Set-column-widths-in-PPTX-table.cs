using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths (in points) and row heights
            double[] columnWidths = new double[] { 100.0, 150.0, 200.0 };
            double[] rowHeights = new double[] { 50.0, 50.0 };

            // Add a table to the slide with the specified dimensions
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50.0f, 50.0f, columnWidths, rowHeights);

            // Optionally adjust the width of the first column after creation
            Aspose.Slides.IColumn firstColumn = table.Columns[0];
            firstColumn.Width = 120.0;

            // Save the presentation
            presentation.Save("TableColumnWidth.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}