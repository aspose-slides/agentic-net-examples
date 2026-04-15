using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
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
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the first slide
                    Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

                    // Add a SmartArt shape to the source slide
                    Aspose.Slides.SmartArt.ISmartArt smartArt = sourceSlide.Shapes.AddSmartArt(
                        50, 50, 400, 300,
                        Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                    // Add a new empty slide using the first layout slide
                    Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides[0];
                    Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

                    // Clone the SmartArt shape onto the new slide at position (100,100)
                    Aspose.Slides.IShape clonedShape = newSlide.Shapes.AddClone(smartArt, 100, 100);

                    // Apply a rotation of 45 degrees to the cloned shape
                    clonedShape.Rotation = 45f;

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}