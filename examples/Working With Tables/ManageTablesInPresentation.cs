using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Define column widths and row heights (in points)
                double[] columnWidths = new double[] { 50, 50, 50 };
                double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

                // Set border format for each cell
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Rows[row].Count; col++)
                    {
                        Aspose.Slides.ICell cell = table.Rows[row][col];

                        // Top border
                        cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                        cell.CellFormat.BorderTop.Width = 5;

                        // Bottom border
                        cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                        cell.CellFormat.BorderBottom.Width = 5;

                        // Left border
                        cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                        cell.CellFormat.BorderLeft.Width = 5;

                        // Right border
                        cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                        cell.CellFormat.BorderRight.Width = 5;
                    }
                }

                // Merge cells (first two cells of the first row)
                table.MergeCells(table.Rows[0][0], table.Rows[1][1], false);

                // Add text to the merged cell
                table.Rows[0][0].TextFrame.Text = "Merged Cells";

                // Save the presentation
                pres.Save("table.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}