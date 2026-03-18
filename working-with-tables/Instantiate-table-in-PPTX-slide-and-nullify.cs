using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            double[] columnWidths = new double[] { 100, 100 };
            double[] rowHeights = new double[] { 50, 50 };
            var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
            // Release the table reference
            table = null;
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}