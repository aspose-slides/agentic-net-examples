using System;
using System.IO;
using Aspose.Slides.Export;

namespace CloneSmartArtExample
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the source slide containing the SmartArt shape
            var sourceSlide = presentation.Slides[0];
            var sourceShapes = sourceSlide.Shapes;

            // Assume the first shape is the SmartArt to be cloned
            var smartArtShape = sourceShapes[0];

            // Create a blank slide to host the cloned SmartArt
            var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);
            var destinationShapes = destinationSlide.Shapes;

            // Clone the SmartArt shape onto the new slide, preserving formatting
            destinationShapes.AddClone(smartArtShape, 100f, 100f);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}