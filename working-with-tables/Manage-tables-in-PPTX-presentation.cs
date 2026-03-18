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
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 30, 30 };

                ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int cell = 0; cell < table.Rows[row].Count; cell++)
                    {
                        table.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
                        table.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Blue;
                        table.Rows[row][cell].CellFormat.BorderTop.Width = 2;
                    }
                }

                slide.Shapes.Remove(table);

                presentation.Save("TableDemo_out.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}