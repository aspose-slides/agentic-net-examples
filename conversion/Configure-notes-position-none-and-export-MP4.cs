// -----------------------------------------------------------------------------
// Example: Configure notes position none and export MP4 using C#
//
// Description:
// Demonstrates how to configure notes position to none and export a presentation
// as an MP4 video using C# and Aspose.Slides for .NET. The example loads a PPTX
// file, hides notes during video rendering, and saves the result as an MP4 file.
// This pattern can be used to automate video generation from PowerPoint files
// while controlling note visibility.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Configure, Notes, Position, None,
// Export, MP4, Video, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of MP4 videos from PowerPoint presentations with notes hidden.
// - Build C# tools for PowerPoint to video conversion.
// - Integrate presentation video export into .NET applications.
// - Create video assets for e‑learning, marketing, or documentation workflows.
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
        string outputPath = "output.mp4";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Configure notes to be hidden during video rendering
                VideoOptions videoOptions = new VideoOptions();
                videoOptions.NotesPosition = NotesPositions.None;

                // Export the presentation as MP4
                presentation.Save(outputPath, SaveFormat.Mp4, videoOptions);
                Console.WriteLine("Presentation exported successfully to MP4: " + outputPath);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The requested export format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
