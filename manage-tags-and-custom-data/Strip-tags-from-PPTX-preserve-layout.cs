using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Load the presentation
            using (var presentation = new Presentation(inputPath))
            {
                // No tag removal is performed because the Tags property does not exist on ISlide or IShape.
                // Saving the presentation preserves the visual layout.
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}