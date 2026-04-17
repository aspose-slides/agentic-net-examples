using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DecorativeShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "DecorativeShape.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a rectangle auto shape to the first slide
                IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
                    ShapeType.Rectangle, 100, 100, 300, 150);

                // Mark the shape as decorative for accessibility compliance
                shape.IsDecorative = true;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}