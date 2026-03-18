using System;
using Aspose.Slides;
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

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Iterate through each cell, set text, and align it to center
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Aspose.Slides.ICell cell = table.Rows[row][col];
                    cell.TextFrame.Text = $"R{row + 1}C{col + 1}";

                    // Get the first paragraph of the cell
                    Aspose.Slides.IParagraph paragraph = cell.TextFrame.Paragraphs[0];

                    // Align text to center
                    paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
                }
            }

            // Save the presentation
            presentation.Save("AlignedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}