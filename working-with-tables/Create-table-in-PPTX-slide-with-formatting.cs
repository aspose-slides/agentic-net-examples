using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 30, 30, 30 };

            Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int cell = 0; cell < table.Rows[row].Count; cell++)
                {
                    table.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    table.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                    table.Rows[row][cell].CellFormat.BorderTop.Width = 5;

                    table.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    table.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                    table.Rows[row][cell].CellFormat.BorderBottom.Width = 5;

                    table.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    table.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                    table.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

                    table.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    table.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                    table.Rows[row][cell].CellFormat.BorderRight.Width = 5;
                }
            }

            // Merge first two cells of the first row
            table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
            table.Rows[0][0].TextFrame.Text = "Merged Cells";

            presentation.Save("TableExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}