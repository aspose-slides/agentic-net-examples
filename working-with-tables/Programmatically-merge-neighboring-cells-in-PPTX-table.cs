using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths and row heights for the table
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Get the cells to merge (first row, first two columns)
            Aspose.Slides.ICell firstCell = table.Rows[0][0];
            Aspose.Slides.ICell secondCell = table.Rows[0][1];

            // Merge the selected cells
            table.MergeCells(firstCell, secondCell, false);

            // Add text to the merged cell
            firstCell.TextFrame.Text = "Merged Cells";

            // Save the presentation
            pres.Save("MergedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}