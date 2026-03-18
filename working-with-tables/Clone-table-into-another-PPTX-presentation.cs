using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 30, 30, 30 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Apply a built‑in table style
            table.StylePreset = Aspose.Slides.TableStylePreset.LightStyle1Accent1;

            // Set borders for each cell
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Rows[row].Count; col++)
                {
                    Aspose.Slides.ICell cell = table.Rows[row][col];

                    cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                    cell.CellFormat.BorderTop.Width = 2;

                    cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                    cell.CellFormat.BorderBottom.Width = 2;

                    cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                    cell.CellFormat.BorderLeft.Width = 2;

                    cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
                    cell.CellFormat.BorderRight.Width = 2;
                }
            }

            // Merge the first two cells of the first row
            table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
            // Add text to the merged cell
            table.Rows[0][0].TextFrame.Text = "Merged Header";

            // Save the presentation
            pres.Save("TableExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}