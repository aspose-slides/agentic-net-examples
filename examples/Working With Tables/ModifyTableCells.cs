using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define column widths and row heights
        double[] columnWidths = new double[] { 50, 50, 50 };
        double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(100f, 50f, columnWidths, rowHeights);

        // Set border formatting for each cell
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                Aspose.Slides.ICell cell = table.Rows[row][col];

                cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderTop.Width = 5;

                cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderBottom.Width = 5;

                cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderLeft.Width = 5;

                cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                cell.CellFormat.BorderRight.Width = 5;
            }
        }

        // Merge the first two cells of the first row
        table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);

        // Add text to the merged cell
        table.Rows[0][0].TextFrame.Text = "Merged Cells";

        // Save the presentation
        pres.Save("ModifiedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        pres.Dispose();
    }
}