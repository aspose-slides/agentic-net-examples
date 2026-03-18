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
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50 };

            // Add a table to the slide
            ITable table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

            // Merge the first two cells of the first row
            ICell cell1 = table.Rows[0][0];
            ICell cell2 = table.Rows[0][1];
            table.MergeCells(cell1, cell2, false);

            // Add text to the merged cell
            cell1.TextFrame.Text = "Merged Cell";

            // Save the presentation
            presentation.Save("MergedTable.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}