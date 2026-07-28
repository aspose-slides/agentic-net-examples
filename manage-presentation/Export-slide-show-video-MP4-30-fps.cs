// -----------------------------------------------------------------------------
// Example: Export slide show video MP4 30 fps using C#
//
// Description:
// Demonstrates how to export a PowerPoint slide show as an MP4 video at a
// frame rate of 30 frames per second using C# and Aspose.Slides for .NET.
// The example loads a presentation, configures video export options, and
// saves the result as an MP4 file in a standalone console application.
// Developers can adapt this pattern to automate PPTX to video conversion
// workflows, integrate video generation into .NET solutions, or validate
// presentation processing logic.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Slide Show, Video, MP4,
// 30 fps, VideoExportOptions, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate conversion of PowerPoint presentations to MP4 video at 30 fps.
// - Build C# tools for generating slide show videos from PPTX files.
// - Integrate slide show video export into .NET applications or services.
// - Validate and test presentation-to-video workflows before deployment.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.mp4";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure video export options: 30 frames per second
                var options = new Mp4VideoExportOptions
                {
                    FrameRate = 30
                };

                // Export the slide show as an MP4 video with the specified frame rate
                pres.Save(outputPath, SaveFormat.Mp4, options);
            }

            Console.WriteLine("Presentation exported to MP4 successfully.");
        }
        catch (NotSupportedException)
        {
            // Thrown by Presentation.Save if the format is unsupported.
            Console.WriteLine("Saving to MP4 is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling (e.g., I/O errors, library errors).
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
