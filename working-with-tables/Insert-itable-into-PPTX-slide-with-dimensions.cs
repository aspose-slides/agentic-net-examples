using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TableExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();
                var slide = presentation.Slides[0];

                var columnWidths = new double[] { 100, 100, 100 };
                var rowHeights = new double[] { 50, 50, 50, 50 };

                var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Example: set text in the first cell
                table.Rows[0][0].TextFrame.Text = "Header";

                presentation.Save("TablePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}