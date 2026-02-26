using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace TableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths and row heights
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50, 50 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Set border for each cell
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Rows[row].Count; col++)
                    {
                        Aspose.Slides.ICell cell = table.Rows[row][col];
                        cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Blue;
                        cell.CellFormat.BorderTop.Width = 2;

                        cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Blue;
                        cell.CellFormat.BorderBottom.Width = 2;

                        cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Blue;
                        cell.CellFormat.BorderLeft.Width = 2;

                        cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Blue;
                        cell.CellFormat.BorderRight.Width = 2;
                    }
                }

                // Merge cells (first row, first two columns)
                Aspose.Slides.ICell startCell = table.Rows[0][0];
                Aspose.Slides.ICell endCell = table.Rows[0][1];
                table.MergeCells(startCell, endCell, false);

                // Add text to merged cell
                startCell.TextFrame.Text = "Merged Cell";

                // Save the presentation
                presentation.Save("TableExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}