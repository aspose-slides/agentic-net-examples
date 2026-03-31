using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InkCopyExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide (source slide)
            Aspose.Slides.ISlide srcSlide = pres.Slides[0];

            // Find the first Ink shape on the source slide
            Aspose.Slides.IShape sourceInkShape = null;
            foreach (Aspose.Slides.IShape shape in srcSlide.Shapes)
            {
                if (shape is Aspose.Slides.Ink.Ink)
                {
                    sourceInkShape = shape;
                    break;
                }
            }

            if (sourceInkShape == null)
            {
                Console.WriteLine("No Ink shape found on the source slide.");
                pres.Dispose();
                return;
            }

            // Create a blank layout slide to host the cloned shape
            Aspose.Slides.ILayoutSlide blankLayout = pres.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

            // Add a new empty slide using the blank layout
            Aspose.Slides.ISlide destSlide = pres.Slides.AddEmptySlide(blankLayout);

            // Clone the Ink shape to the destination slide, preserving brush settings
            destSlide.Shapes.AddClone(sourceInkShape);

            // Save the modified presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}