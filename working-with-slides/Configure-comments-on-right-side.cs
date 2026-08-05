// -----------------------------------------------------------------------------
// Example: Configure comments on right side using C#
//
// Description:
// Demonstrates how to configure comments to appear on the right side of slides
// using C# and Aspose.Slides for .NET. The example loads a PPTX file, sets the
// comments layout option, and saves the presentation as a SWF file. This pattern
// can be used to automate PowerPoint to SWF conversion with custom comment
// positioning.
//
// Keywords:
// C#, PowerPoint, PPTX, SWF, Aspose.Slides for .NET, Configure, Comments, Right,
// Side, Presentation Processing, Export, Office Automation
//
// Use Cases:
// - Convert PPTX presentations to SWF with comments positioned on the right.
// - Build C# tools for customizing comment layout during export.
// - Automate batch processing of presentations for web or e‑learning platforms.
// - Validate comment positioning before publishing converted files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesCommentsLayoutExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation inside a try-catch to handle unsupported formats
            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Configure SlidesLayoutOptions to place comments on the right side
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            Aspose.Slides.Export.NotesCommentsLayoutingOptions layoutOptions = new Aspose.Slides.Export.NotesCommentsLayoutingOptions();
            layoutOptions.CommentsPosition = Aspose.Slides.Export.CommentsPositions.Right;
            swfOptions.SlidesLayoutOptions = layoutOptions;

            // Save the presentation with the configured options
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
