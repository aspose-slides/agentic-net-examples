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
            double[] columnWidths = new double[] { 100, 100 };
            double[] rowHeights = new double[] { 50, 50 };
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
            Aspose.Slides.ICell cell = table[0, 1];
            cell.CellFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            cell.CellFormat.FillFormat.SolidFillColor.Color = Color.LightBlue;
            presentation.Save("TableCellBackground.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}