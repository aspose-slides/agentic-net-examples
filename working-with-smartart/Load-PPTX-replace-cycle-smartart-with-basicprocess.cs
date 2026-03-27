using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
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

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Iterate through all shapes on the slide
            foreach (IShape shape in slide.Shapes)
            {
                // Check if the shape is a SmartArt diagram
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                    // Replace layout type Cycle with BasicProcess
                    if (smartArt.Layout == Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle)
                    {
                        smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}