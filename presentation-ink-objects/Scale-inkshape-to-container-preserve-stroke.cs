// -----------------------------------------------------------------------------
// Example: Scale inkshape to container preserve stroke using C#
//
// Description:
// Demonstrates how to scale an Ink shape to fill its container (the slide) while preserving the original stroke appearance using C# and Aspose.Slides for .NET. The example loads a PPTX file, resizes the first Ink shape to match the slide dimensions, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ink shape, Scale, Preserve stroke, Presentation processing, Office automation
//
// Use Cases:
// - Resize Ink shapes to fit slide dimensions without altering stroke style.
// - Automate PowerPoint content adjustments in .NET applications.
// - Build tools for batch processing of PPTX files containing Ink annotations.
// - Ensure visual consistency of Ink strokes after scaling operations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InkScalingExample
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                Presentation pres = new Presentation(inputPath);

                // Assume the first shape on the first slide is an Ink shape
                IShape shape = pres.Slides[0].Shapes[0];
                Aspose.Slides.Ink.Ink inkShape = shape as Aspose.Slides.Ink.Ink;

                if (inkShape != null)
                {
                    // Scale the Ink shape to match the slide dimensions
                    float slideWidth = pres.SlideSize.Size.Width;
                    float slideHeight = pres.SlideSize.Size.Height;

                    inkShape.Width = slideWidth;
                    inkShape.Height = slideHeight;

                    // Stroke appearance is preserved by not modifying line format properties
                }
                else
                {
                    Console.WriteLine("The first shape is not an Ink shape.");
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
