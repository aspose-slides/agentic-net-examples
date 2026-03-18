using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define row heights and column widths for the table
            double[] rowHeights = new double[] { 50.0, 30.0, 30.0 };
            double[] columnWidths = new double[] { 100.0, 100.0 };

            // Add a table to the first slide using the specified dimensions
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.ITable table = slide.Shapes.AddTable(50f, 50f, columnWidths, rowHeights);

            // Set slide size with correct enum reference
            presentation.SlideSize.SetSize(Aspose.Slides.SlideSizeType.A4Paper, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}