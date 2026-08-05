// -----------------------------------------------------------------------------
// Example: Reset first slide number after removal using C#
//
// Description:
// Demonstrates how to remove the first slide from a presentation and reset
// the first slide number to maintain correct slide numbering using Aspose.Slides
// for .NET. The example loads a PPTX file, deletes its first slide, sets the
// FirstSlideNumber property, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Reset, First Slide Number,
// Slide Removal, Presentation Processing, Office Automation
//
// Use Cases:
// - Remove an unwanted introductory slide and adjust slide numbering.
// - Build C# utilities for PowerPoint slide management.
// - Automate PPTX transformations that require renumbering after deletions.
// - Ensure correct slide numbers in generated presentations.
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
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Remove the first slide using reference
                ISlide firstSlide = pres.Slides[0];
                pres.Slides.Remove(firstSlide);

                // Reset the first slide number to maintain correct numbering sequence
                pres.FirstSlideNumber = 2;

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            // Format not supported: {ex.Message}
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
