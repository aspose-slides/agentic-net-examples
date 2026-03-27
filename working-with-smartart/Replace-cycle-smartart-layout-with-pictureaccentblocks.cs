using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        using (Presentation presentation = new Presentation(inputPath))
        {
            // Iterate through all slides
            foreach (ISlide slide in presentation.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Check if the shape is a SmartArt diagram
                    if (shape is ISmartArt)
                    {
                        ISmartArt smartArt = (ISmartArt)shape;
                        // Change layout from BasicCycle to PictureAccentBlocks
                        if (smartArt.Layout == SmartArtLayoutType.BasicCycle)
                        {
                            smartArt.Layout = SmartArtLayoutType.PictureAccentBlocks;
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}