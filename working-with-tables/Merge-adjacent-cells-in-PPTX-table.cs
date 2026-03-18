using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            double[] dblCols = new double[] { 100, 100, 100 };
            double[] dblRows = new double[] { 50, 50, 50 };

            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, dblCols, dblRows);

            foreach (Aspose.Slides.IRow row in table.Rows)
            {
                foreach (Aspose.Slides.ICell cell in row)
                {
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

            table.MergeCells(table[0, 0], table[1, 1], false);
            table[0, 0].TextFrame.Text = "Merged Cells";

            presentation.Save("MergedTable.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}