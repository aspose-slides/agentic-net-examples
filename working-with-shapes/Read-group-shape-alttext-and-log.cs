using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle loading errors (e.g., unsupported format)
            // Format not supported.
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape is a group shape
                if (shape is IGroupShape)
                {
                    IGroupShape groupShape = (IGroupShape)shape;

                    // Iterate through shapes inside the group
                    for (int innerIndex = 0; innerIndex < groupShape.Shapes.Count; innerIndex++)
                    {
                        IShape innerShape = groupShape.Shapes[innerIndex];
                        string altText = innerShape.AlternativeText;

                        if (!string.IsNullOrEmpty(altText))
                        {
                            Console.WriteLine("Slide {0}, Group {1}, Shape {2} Alternative Text: {3}",
                                slideIndex, shapeIndex, innerIndex, altText);
                        }
                    }
                }
            }
        }

        // Save the presentation before exiting
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors (e.g., format not supported)
            // Format not supported.
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}