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

            // Load the existing PPTX file
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Index of the slide where the rectangle will be added
                var slideIndex = 0;
                var slide = presentation.Slides[slideIndex];

                // Insert a rectangular shape onto the slide
                var rectangle = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    50,   // X position
                    50,   // Y position
                    200,  // Width
                    100   // Height
                );

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