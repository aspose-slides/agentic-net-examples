using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 100, 100, 100 };
        double[] rowHeights = new double[] { 50, 50, 50 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

        // Set background color of a specific cell (row 0, column 0)
        Aspose.Slides.ICell cell = table[0, 0];
        cell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

        // Set background color for all cells
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                Aspose.Slides.ICell curCell = table.Rows[row][col];
                curCell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                curCell.CellFormat.FillFormat.SolidFillColor.Color = Color.LightBlue;
            }
        }

        // Save the presentation
        presentation.Save("TableCellBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}