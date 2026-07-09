using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PlainLineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "PlainLine.pptx";

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a plain line shape to the slide (x, y, width, height)
                slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 150f, 300f, 0f);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}