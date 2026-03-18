using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (var slide in presentation.Slides)
                {
                    // Find all shapes that are Title placeholders
                    var titleShapes = Aspose.Slides.Util.SlideUtil.FindShapesByPlaceholderType(
                        slide,
                        Aspose.Slides.PlaceholderType.Title);

                    foreach (var shape in titleShapes)
                    {
                        // Output the name of each found placeholder shape
                        Console.WriteLine($"Found Title placeholder: {shape.Name}");
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}