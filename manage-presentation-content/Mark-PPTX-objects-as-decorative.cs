using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output files
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through each slide
                foreach (var slide in presentation.Slides)
                {
                    // Iterate through each shape on the slide
                    foreach (var shape in slide.Shapes)
                    {
                        // Mark the shape as decorative for accessibility
                        shape.IsDecorative = true;
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}