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

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Adjust margins for each cell in the table
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Columns.Count; col++)
            {
                Aspose.Slides.ICell cell = table[row, col];
                cell.MarginTop = 5;
                cell.MarginBottom = 5;
                cell.MarginLeft = 5;
                cell.MarginRight = 5;
            }
        }

        // Save the presentation
        presentation.Save("AdjustedCellMargins.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}