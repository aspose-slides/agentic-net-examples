using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            double[] colWidths = { 100, 100, 100 };
            double[] rowHeights = { 50, 50, 50 };

            var table = slide.Shapes.AddTable(50, 50, colWidths, rowHeights);

            // Update individual cell text
            table[0, 0].TextFrame.Text = "Header";
            table[0, 1].TextFrame.Text = "Value 1";

            // Change fill color of a cell
            table[0, 2].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            table[0, 2].CellFormat.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Save the presentation
            presentation.Save("UpdatedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}