using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Paths for input and output presentations
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                // Load the existing presentation
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the first slide
                    var slide = presentation.Slides[0];

                    // Access the shape collection of the slide
                    var shapes = slide.Shapes;

                    // Add a bent connector shape with specified coordinates
                    var connector = shapes.AddConnector(
                        Aspose.Slides.ShapeType.BentConnector2,
                        100f,   // x-coordinate
                        100f,   // y-coordinate
                        200f,   // width
                        0f);    // height (line)

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}