using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape is a group shape
                if (shape is Aspose.Slides.IGroupShape)
                {
                    Aspose.Slides.IGroupShape groupShape = (Aspose.Slides.IGroupShape)shape;

                    // Iterate through shapes inside the group
                    for (int innerIndex = 0; innerIndex < groupShape.Shapes.Count; innerIndex++)
                    {
                        Aspose.Slides.IShape innerShape = groupShape.Shapes[innerIndex];
                        string altText = innerShape.AlternativeText;

                        if (!string.IsNullOrEmpty(altText))
                        {
                            Console.WriteLine("Slide {0}, Group {1}, Shape {2}: {3}",
                                slideIndex, shapeIndex, innerIndex, altText);
                        }
                    }
                }
            }
        }

        // Save the presentation before exiting
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}