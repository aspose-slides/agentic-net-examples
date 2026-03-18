using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Define column widths for the table (in points)
            double[] columnWidths = new double[] { 100.0, 150.0, 200.0 };

            // Define row heights for the table (in points)
            double[] rowHeights = new double[] { 50.0, 50.0 };

            // Add a table shape to the slide using the specified column widths
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50.0f, 50.0f, columnWidths, rowHeights);

            // Save the presentation before exiting
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}