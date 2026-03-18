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
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 30, 30, 30 };

            // Add table to slide at position (100, 50)
            ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

            // Set border formatting for each cell
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int cell = 0; cell < table.Rows[row].Count; cell++)
                {
                    // Top border
                    table.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                    table.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                    table.Rows[row][cell].CellFormat.BorderTop.Width = 5;

                    // Bottom border
                    table.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                    table.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                    table.Rows[row][cell].CellFormat.BorderBottom.Width = 5;

                    // Left border
                    table.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                    table.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                    table.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

                    // Right border
                    table.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                    table.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                    table.Rows[row][cell].CellFormat.BorderRight.Width = 5;
                }
            }

            // Save the presentation
            presentation.Save("TablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}