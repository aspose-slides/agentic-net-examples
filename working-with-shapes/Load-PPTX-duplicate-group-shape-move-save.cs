using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CloneGroupShapeExample
{
    class Program
    {
        static void Main(string[] args)
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
                Presentation pres = new Presentation(inputPath);

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Access the shape collection of the slide
                IShapeCollection shapes = slide.Shapes;

                // Assume the first shape is a group shape; cast it accordingly
                IGroupShape originalGroup = shapes[0] as IGroupShape;
                if (originalGroup == null)
                {
                    Console.WriteLine("The first shape is not a group shape.");
                    pres.Dispose();
                    return;
                }

                // Clone the group shape and add it to the end of the shape collection
                IShape clonedShape = shapes.AddClone(originalGroup);

                // Modify the position of the cloned group shape
                clonedShape.X = originalGroup.X + 50f;
                clonedShape.Y = originalGroup.Y + 50f;

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Clean up
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to an unsupported format, handle accordingly.
            }
        }
    }
}