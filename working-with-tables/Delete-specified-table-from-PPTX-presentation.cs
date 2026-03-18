using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the input and output presentations
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Indices (zero‑based) of the slide and the shape that contains the table
            int slideIndex = 0;
            int shapeIndex = 0;

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the target slide
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Get the shape at the specified index
            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

            // Verify that the shape is a table
            Aspose.Slides.ITable table = shape as Aspose.Slides.ITable;
            if (table != null)
            {
                // Remove the table shape from the slide
                slide.Shapes.Remove(shape);
                Console.WriteLine("Table removed successfully.");
            }
            else
            {
                Console.WriteLine("The specified shape is not a table.");
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}