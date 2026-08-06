// -----------------------------------------------------------------------------
// Example: Remove hidden smartart shapes and save using C#
//
// Description:
// Demonstrates how to remove hidden SmartArt shapes from a PowerPoint presentation
// and save the cleaned file using C# and Aspose.Slides for .NET. The example loads
// an existing PPTX file, iterates through each slide and shape, removes any SmartArt
// diagram marked as hidden, and then saves the resulting presentation.
// This pattern can be used to automate cleanup of presentations before distribution.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Hidden, SmartArt, Shapes,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of hidden SmartArt shapes from presentations.
// - Build C# utilities for PowerPoint cleanup tasks.
// - Integrate presentation validation and transformation into .NET applications.
// - Ensure published PPTX files do not contain unintended hidden content.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHiddenSmartArt
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_cleaned.pptx";

            // Check if the input file exists
            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate backwards through shapes to allow removal
                for (int shapeIndex = slide.Shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is a SmartArt diagram
                    if (shape is Aspose.Slides.SmartArt.ISmartArt)
                    {
                        Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;

                        // Remove the shape if it is hidden
                        if (smartArt.Hidden)
                        {
                            slide.Shapes.RemoveAt(shapeIndex);
                        }
                    }
                }
            }

            // Save the cleaned presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();

            Console.WriteLine("Hidden SmartArt shapes removed and saved to: " + outputPath);
        }
    }
}
