using System;
using System.Drawing;
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

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Format each cell with red borders
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < table.Rows[rowIndex].Count; colIndex++)
                {
                    Aspose.Slides.ICell cell = table.Rows[rowIndex][colIndex];
                    cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderTop.Width = 2;

                    cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderBottom.Width = 2;

                    cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderLeft.Width = 2;

                    cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderRight.Width = 2;
                }
            }

            // Merge cells (first row, first two columns)
            Aspose.Slides.ICell startCell = table.Rows[0][0];
            Aspose.Slides.ICell endCell = table.Rows[0][1];
            table.MergeCells(startCell, endCell, false);

            // Add text to the merged cell
            startCell.TextFrame.Text = "Merged Cell";

            // Clear text of a specific cell (row 2, column 2)
            Aspose.Slides.ICell cellToClear = table.Rows[1][1];
            cellToClear.TextFrame.Text = string.Empty;

            // Save the presentation
            presentation.Save("TableOperations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}