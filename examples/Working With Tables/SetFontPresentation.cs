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

        // Set text and font for each cell in the table
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                Aspose.Slides.ICell cell = table.Rows[row][col];
                cell.TextFrame.Text = "Cell " + row + "," + col;

                // Ensure the cell has a paragraph and a portion to format
                if (cell.TextFrame.Paragraphs.Count > 0 && cell.TextFrame.Paragraphs[0].Portions.Count > 0)
                {
                    Aspose.Slides.IPortion portion = cell.TextFrame.Paragraphs[0].Portions[0];
                    portion.PortionFormat.LatinFont = new Aspose.Slides.FontData("Arial");
                }
            }
        }

        // Save the presentation
        presentation.Save("TableWithFont.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}