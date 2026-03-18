using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];

            double[] columnWidths = { 100, 100, 100 };
            double[] rowHeights = { 50, 50, 50 };

            var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Populate cells with text
            table.Rows[0][0].TextFrame.Text = "Cell 0,0";
            table.Rows[0][1].TextFrame.Text = "Cell 0,1";
            table.Rows[0][2].TextFrame.Text = "Cell 0,2";

            table.Rows[1][0].TextFrame.Text = "Cell 1,0";
            table.Rows[1][1].TextFrame.Text = "Cell 1,1";
            table.Rows[1][2].TextFrame.Text = "Cell 1,2";

            table.Rows[2][0].TextFrame.Text = "Cell 2,0";
            table.Rows[2][1].TextFrame.Text = "Cell 2,1";
            table.Rows[2][2].TextFrame.Text = "Cell 2,2";

            // Merge first two cells of the first row
            table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
            table.Rows[0][0].TextFrame.Text = "Merged Cells";

            // Clear content of the third row (simulating row deletion)
            for (int col = 0; col < table.Columns.Count; col++)
            {
                table.Rows[2][col].TextFrame.Text = string.Empty;
            }

            // Save the presentation
            presentation.Save("TableDemo.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}