using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define column widths and row heights for the table
        double[] columnWidths = new double[] { 50, 50, 50 };
        double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };

        // Add a table shape to the slide
        Aspose.Slides.ITable table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

        // Save the presentation to a file
        presentation.Save("table.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}