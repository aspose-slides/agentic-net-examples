using System;
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
            double[] rowHeights = new double[] { 50, 50, 50 };
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

            // Assign vertical text orientation to each cell in the second row (index 1)
            Aspose.Slides.IRow secondRow = table.Rows[1];
            foreach (Aspose.Slides.ICell cell in secondRow)
            {
                cell.TextVerticalType = Aspose.Slides.TextVerticalType.Vertical270;
            }

            presentation.Save("VerticalTextSecondRow.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}