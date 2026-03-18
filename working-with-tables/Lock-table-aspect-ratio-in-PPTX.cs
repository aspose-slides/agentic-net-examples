using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var presentation = new Aspose.Slides.Presentation();
                var slide = presentation.Slides[0];

                // Define column widths and row heights for the table
                var columnWidths = new double[] { 100, 100, 100 };
                var rowHeights = new double[] { 50, 50, 50 };

                // Add a table to the slide
                var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

                // Set fixed dimensions to maintain aspect ratio (e.g., 2:1)
                table.Width = 300;   // total width in points
                table.Height = 150;  // total height in points (maintains 2:1 ratio)

                // Save the presentation
                presentation.Save("FixedAspectTable.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}