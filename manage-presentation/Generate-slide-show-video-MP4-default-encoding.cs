// -----------------------------------------------------------------------------
// Example: Generate slide show video MP4 default encoding using C#
//
// Description:
// Demonstrates how to generate a slide show video in MP4 format using the
// default encoding settings with Aspose.Slides for .NET. The example loads a
// PowerPoint presentation, converts it to an MP4 video, and saves the output
// file. This pattern can be used to automate PPTX to video conversion in
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, Slide Show, Video,
// MP4, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate generation of slide show videos in MP4 format.
// - Build C# tools for converting PowerPoint presentations to video.
// - Integrate slide show video creation into .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation file path
            string inputPath = "input.pptx";
            // Output video file path
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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save the presentation as a video (MP4) using default encoding settings.
                    // Aspose.Slides supports MP4 via the SaveFormat.Mp4 enumeration value.
                    try
                    {
                        presentation.Save(outputPath, SaveFormat.Mp4);
                        Console.WriteLine("Slide show video saved successfully to: " + outputPath);
                    }
                    catch (NotSupportedException)
                    {
                        // Handle the case where MP4 saving is not supported.
                        Console.WriteLine("Saving as MP4 is not supported for this presentation.");
                    }
                }
            }
            catch (Exception ex)
            {
                // General exception handling for unexpected errors.
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
