using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Update line width if the shape has a line format
                    if (shape.LineFormat != null)
                    {
                        shape.LineFormat.Width = 1.5; // Set width to 1.5 points, dash style remains unchanged
                    }
                }
            }

            // Save the updated presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported formats or I/O issues
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}