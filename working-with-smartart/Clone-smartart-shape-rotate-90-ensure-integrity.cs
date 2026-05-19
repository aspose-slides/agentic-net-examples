using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Get the first slide
                Aspose.Slides.ISlide sourceSlide = presentation.Slides[0];

                // Add a SmartArt diagram to the source slide (if not already present)
                Aspose.Slides.SmartArt.ISmartArt originalSmartArt = sourceSlide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

                // Add a new empty slide using the first layout slide
                Aspose.Slides.ILayoutSlide layout = presentation.LayoutSlides[0];
                Aspose.Slides.ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

                // Clone the SmartArt shape onto the new slide at a specific position
                Aspose.Slides.IShape clonedShape = newSlide.Shapes.AddClone(originalSmartArt, 100, 100);

                // Cast the cloned shape back to ISmartArt to modify its properties
                Aspose.Slides.SmartArt.ISmartArt clonedSmartArt = clonedShape as Aspose.Slides.SmartArt.ISmartArt;
                if (clonedSmartArt != null)
                {
                    // Rotate the cloned SmartArt by 90 degrees
                    clonedSmartArt.Rotation = 90;
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported formats or I/O issues
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}