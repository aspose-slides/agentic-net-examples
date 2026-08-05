// -----------------------------------------------------------------------------
// Example: Validate slide masters have layout before save using C#
//
// Description:
// Demonstrates how to validate that each master slide contains at least one
// layout slide before saving a presentation using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, checks each master for layout slides, adds a
// default title layout when missing, and then saves the updated presentation.
// This pattern helps ensure PPTX files meet required structure before further
// processing or distribution.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Validate, Slide, Masters, Layout,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate validation of slide master layouts before saving presentations.
// - Build C# utilities for PowerPoint file integrity checks.
// - Ensure PPTX files contain required layout slides for downstream tools.
// - Integrate slide‑master validation into .NET applications handling Office files.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Validate that each master slide contains at least one layout slide
                foreach (IMasterSlide master in presentation.Masters)
                {
                    if (master.LayoutSlides.Count == 0)
                    {
                        Console.WriteLine("Master slide '{0}' has no layout slides.", master.Name);
                        // Add a default layout slide to satisfy the validation
                        master.LayoutSlides.Add(SlideLayoutType.Title);
                    }
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException ex)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
