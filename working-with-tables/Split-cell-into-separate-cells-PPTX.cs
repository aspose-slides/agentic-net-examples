using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableCellSplitExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                double[] columnWidths = new double[] { 100, 100, 100 };
                double[] rowHeights = new double[] { 50, 50 };
                Aspose.Slides.ITable table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                Aspose.Slides.ICell cell = table.Rows[0][0];
                double splitWidth = cell.Width / 2;
                cell.SplitByWidth(splitWidth);

                presentation.Save("SplitCellPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}