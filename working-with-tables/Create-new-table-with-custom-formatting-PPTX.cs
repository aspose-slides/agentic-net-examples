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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            double[] columnWidths = new double[] { 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 30, 30, 30 };

            Aspose.Slides.ITable table = slide.Shapes.AddTable(50f, 50f, columnWidths, rowHeights);

            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Rows[row].Count; col++)
                {
                    Aspose.Slides.ICell cell = table.Rows[row][col];

                    cell.CellFormat.BorderTop.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderTop.Width = 5;

                    cell.CellFormat.BorderBottom.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderBottom.Width = 5;

                    cell.CellFormat.BorderLeft.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderLeft.Width = 5;

                    cell.CellFormat.BorderRight.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
                    cell.CellFormat.BorderRight.Width = 5;
                }
            }

            table.MergeCells(table.Rows[0][0], table.Rows[0][1], false);
            table.Rows[0][0].TextFrame.Text = "Merged Cells";

            Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
            Aspose.Slides.Export.IPptxOptions options = optionsFactory.CreatePptxOptions();

            presentation.Save("TablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}