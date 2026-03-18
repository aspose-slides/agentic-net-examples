using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            double[] columnWidths = { 100, 100, 100 };
            double[] rowHeights = { 50, 30, 30 };

            var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

            // Mark the first row as the header row
            table.FirstRow = true;

            // Example: add header text
            table.Rows[0][0].TextFrame.Text = "Header 1";
            table.Rows[0][1].TextFrame.Text = "Header 2";
            table.Rows[0][2].TextFrame.Text = "Header 3";

            presentation.Save("HeaderTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}