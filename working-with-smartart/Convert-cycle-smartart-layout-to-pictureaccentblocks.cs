// -----------------------------------------------------------------------------
// Example: Convert cycle smartart layout to pictureaccentblocks using C#
//
// Description:
// Demonstrates how to convert a BasicCycle SmartArt layout to a PictureAccentBlocks
// layout in a PowerPoint presentation using Aspose.Slides for .NET. The example
// loads an existing PPTX file, iterates through its slides and shapes, identifies
// SmartArt diagrams with the BasicCycle layout, changes them to PictureAccentBlocks,
// and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Convert, Cycle, Layout,
// PictureAccentBlocks, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of BasicCycle SmartArt diagrams to PictureAccentBlocks.
// - Build tools for bulk updating SmartArt layouts in existing presentations.
// - Integrate SmartArt layout transformations into .NET applications.
// - Prepare presentations for consistent visual styling before distribution.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SmartArtLayoutChanger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

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
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the file format is not supported, the exception will be caught here.
            }
        }
    }
}
