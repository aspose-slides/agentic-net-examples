using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the first slide
            var sourceSlide = presentation.Slides[0];

            // Add a SmartArt shape to the source slide
            var smartArt = sourceSlide.Shapes.AddSmartArt(0, 0, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Create a new blank slide
            var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);
            var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

            // Clone the SmartArt shape to the new slide at a specific position
            var clonedShape = destinationSlide.Shapes.AddClone(smartArt, 100, 100);

            // Apply a 90-degree rotation to the cloned SmartArt shape
            if (clonedShape is Aspose.Slides.SmartArt.ISmartArt clonedSmartArt)
            {
                clonedSmartArt.Rotation = 90;
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}