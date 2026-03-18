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

            // Define column widths and row heights
            double[] cols = new double[] { 100, 100, 100 };
            double[] rows = new double[] { 50, 50, 50, 50 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, cols, rows);

            // Apply solid black borders to all cells
            foreach (Aspose.Slides.IRow row in table.Rows)
            {
                foreach (Aspose.Slides.ICell cell in row)
                {
                    cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Black;
                    cell.CellFormat.BorderTop.Width = 1;

                    cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Black;
                    cell.CellFormat.BorderBottom.Width = 1;

                    cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Black;
                    cell.CellFormat.BorderLeft.Width = 1;

                    cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Black;
                    cell.CellFormat.BorderRight.Width = 1;
                }
            }

            // Merge cells to create merged regions (using merge-cells rule)
            // Merge first two rows of the first column
            table.MergeCells(table[0, 0], table[1, 0], false);
            // Merge first two rows of the second column
            table.MergeCells(table[0, 1], table[1, 1], false);

            // Sequentially number cells, assigning the same number to the top‑left cell of each merged region
            int number = 1;
            for (int r = 0; r < table.Rows.Count; r++)
            {
                for (int c = 0; c < table.Columns.Count; c++)
                {
                    Aspose.Slides.ICell currentCell = table[c, r];

                    // Determine if this cell is the top‑left cell of a merged region or a regular cell
                    bool isTopLeft = (!currentCell.IsMergedCell) ||
                                     (currentCell.FirstRowIndex == r && currentCell.FirstColumnIndex == c);

                    if (isTopLeft)
                    {
                        currentCell.TextFrame.Text = number.ToString();
                        number++;
                    }
                }
            }

            // Save the presentation
            string outputPath = "NumberedMergedTable.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}