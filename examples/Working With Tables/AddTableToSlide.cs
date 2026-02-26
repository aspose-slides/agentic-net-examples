using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths and row heights
            double[] columnWidths = new double[] { 50, 50, 50 };
            double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };

            // Add a table to the slide
            Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

            // Save the presentation
            pres.Save("table.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}