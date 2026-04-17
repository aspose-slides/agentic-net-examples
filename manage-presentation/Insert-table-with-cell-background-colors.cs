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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            double[] columnWidths = new double[] { 100, 100, 100, 100 };
            double[] rowHeights = new double[] { 50, 50, 50, 50, 50 };
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
            // Apply background colors to each cell
            for (int row = 0; row < table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    table[row, col].CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    if ((row + col) % 2 == 0)
                    {
                        table[row, col].CellFormat.FillFormat.SolidFillColor.Color = Color.LightBlue;
                    }
                    else
                    {
                        table[row, col].CellFormat.FillFormat.SolidFillColor.Color = Color.LightCoral;
                    }
                }
            }
            string outputPath = "TableWithColors.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}