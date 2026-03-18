using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace CombineAdjacentCells
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define column widths and row heights
                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50, 50, 50 };

                // Add a table to the slide
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Set borders for each cell
                foreach (Aspose.Slides.IRow row in table.Rows)
                {
                    foreach (Aspose.Slides.ICell cell in row)
                    {
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

                // Merge adjacent cells (first two rows and first two columns)
                Aspose.Slides.ICell mergedCell = table.MergeCells(table[0, 0], table[1, 1], false);
                mergedCell.TextFrame.Text = "Merged Cell";

                // Save the presentation
                presentation.Save("CombinedCells.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}