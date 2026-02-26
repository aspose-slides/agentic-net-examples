using System;
using Aspose.Slides;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (var pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            var slide = pres.Slides[0];

            // Define column widths and row heights
            var colWidths = new double[] { 100, 100, 100 };
            var rowHeights = new double[] { 50, 50 };

            // Add a table to the slide
            var table = slide.Shapes.AddTable(50, 50, colWidths, rowHeights);

            // Change the background color of the first cell (row 0, column 0)
            table.Rows[0][0].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            table.Rows[0][0].CellFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

            // Save the presentation
            pres.Save("TableCellBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}