// -----------------------------------------------------------------------------
// Example: Move slide and verify new index using C#
//
// Description:
// Demonstrates how to load a PPTX file, move a slide to a new position,
// verify the slide's new index, and save the updated presentation using
// Aspose.Slides for .NET. The example includes basic error handling for missing
// files and unsupported formats, making it suitable for console applications
// that automate PowerPoint slide reordering.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Move Slide, Verify Index,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Reorder slides programmatically in a PowerPoint file.
// - Validate slide positions after manipulation.
// - Build .NET tools for automated PPTX editing and quality checks.
// - Integrate slide management into larger presentation workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideReorderExample
{
    class Program
    {
        static void Main(string[] args)
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

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception)
            {
                // Handle unsupported file format or other loading errors
                // Format not supported
                Console.WriteLine("Failed to load the presentation. The file format may not be supported.");
                return;
            }

            // Get the slide to move (first slide in this example)
            Aspose.Slides.ISlide slideToMove = presentation.Slides[0];

            // Move the slide to the desired position (e.g., index 2)
            presentation.Slides.Reorder(2, slideToMove);

            // Verify the new index of the moved slide
            int newIndex = presentation.Slides.IndexOf(slideToMove);
            Console.WriteLine("Slide moved to index: " + newIndex);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
