// -----------------------------------------------------------------------------
// Example: Load presentation change cycle to pictureaccentblocks using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, locate SmartArt diagrams 
// with the BasicCycle layout, and change their layout to PictureAccentBlocks 
// using Aspose.Slides for .NET. The example shows the required steps for 
// processing SmartArt objects and saving the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, SmartArt, 
// Layout Change, BasicCycle, PictureAccentBlocks, Office Automation
//
// Use Cases:
// - Automate conversion of SmartArt cycle diagrams to picture accent blocks.
// - Build C# tools for batch updating SmartArt layouts in PPTX files.
// - Integrate SmartArt processing into .NET applications.
// - Ensure consistent visual styles across presentations before publishing.
// -----------------------------------------------------------------------------

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

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Check if the shape is a SmartArt diagram
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                        // Change layout from BasicCycle to PictureAccentBlocks
                        if (smartArt.Layout == Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle)
                        {
                            smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.PictureAccentBlocks;
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
