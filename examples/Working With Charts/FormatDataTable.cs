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
        double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };

        // Add a table to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(100f, 50f, columnWidths, rowHeights);

        // Set border format for each cell
        for (int row = 0; row < table.Rows.Count; row++)
        {
            for (int col = 0; col < table.Rows[row].Count; col++)
            {
                // Top border
                table.Rows[row][col].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                table.Rows[row][col].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                table.Rows[row][col].CellFormat.BorderTop.Width = 5;

                // Bottom border
                table.Rows[row][col].CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                table.Rows[row][col].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                table.Rows[row][col].CellFormat.BorderBottom.Width = 5;

                // Left border
                table.Rows[row][col].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                table.Rows[row][col].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                table.Rows[row][col].CellFormat.BorderLeft.Width = 5;

                // Right border
                table.Rows[row][col].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                table.Rows[row][col].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                table.Rows[row][col].CellFormat.BorderRight.Width = 5;
            }
        }

        // Merge first two cells of the first row
        table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
        // Add text to the merged cell
        table.Rows[0][0].TextFrame.Text = "Merged Cells";

        // Save the presentation
        presentation.Save("FormattedTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}