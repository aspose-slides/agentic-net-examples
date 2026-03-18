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
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Define column widths and row heights (double arrays)
            double[] cols = new double[] { 100, 100, 100 };
            double[] rows = new double[] { 50, 50, 50 };

            // Add a table to the slide
            ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

            // Apply solid red borders to all cells
            foreach (IRow rowItem in table.Rows)
            {
                foreach (ICell cell in rowItem)
                {
                    cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderTop.Width = 2;

                    cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderBottom.Width = 2;

                    cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderLeft.Width = 2;

                    cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderRight.Width = 2;
                }
            }

            // Merge the first two cells of the first row
            table.MergeCells(table[0, 0], table[0, 1], false);

            // Add text to the merged cell
            table[0, 0].TextFrame.Text = "Merged Cells";

            // Save the presentation
            presentation.Save("CombinedCells.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}