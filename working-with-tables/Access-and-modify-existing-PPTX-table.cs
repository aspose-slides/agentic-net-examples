using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Locate the first table on the slide
            Aspose.Slides.ITable table = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                table = shape as Aspose.Slides.ITable;
                if (table != null)
                {
                    break;
                }
            }

            if (table != null)
            {
                // Update text in the first cell
                table.Rows[0][0].TextFrame.Text = "Updated Text";

                // Apply red solid borders to all cells
                int rowCount = table.Rows.Count;
                int colCount = table.Columns.Count;
                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < colCount; col++)
                    {
                        table.Rows[row][col].CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        table.Rows[row][col].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                        table.Rows[row][col].CellFormat.BorderTop.Width = 2;

                        table.Rows[row][col].CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        table.Rows[row][col].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                        table.Rows[row][col].CellFormat.BorderBottom.Width = 2;

                        table.Rows[row][col].CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        table.Rows[row][col].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                        table.Rows[row][col].CellFormat.BorderLeft.Width = 2;

                        table.Rows[row][col].CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                        table.Rows[row][col].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                        table.Rows[row][col].CellFormat.BorderRight.Width = 2;
                    }
                }

                // Merge the first two cells of the first row
                table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}