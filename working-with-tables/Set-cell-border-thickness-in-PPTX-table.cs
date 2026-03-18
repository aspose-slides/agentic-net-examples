using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Define table dimensions
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50, 50 };

            // Add table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Set border thickness and color for each cell
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < table.Columns.Count; colIndex++)
                {
                    Aspose.Slides.ICell cell = table[rowIndex, colIndex];

                    // Border width
                    cell.CellFormat.BorderTop.Width = 3;
                    cell.CellFormat.BorderBottom.Width = 3;
                    cell.CellFormat.BorderLeft.Width = 3;
                    cell.CellFormat.BorderRight.Width = 3;

                    // Border fill type
                    cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                    // Border color
                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Blue;
                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Blue;
                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Blue;
                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Blue;
                }
            }

            // Add text to the first cell
            Aspose.Slides.ICell firstCell = table[0, 0];
            firstCell.TextFrame.Text = "Hello Aspose";

            // Merge cells in the second row and add text
            table.MergeCells(table[1, 0], table[1, 2], false);
            table[1, 0].TextFrame.Text = "Merged cells";

            // Save the presentation
            presentation.Save("TableDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}