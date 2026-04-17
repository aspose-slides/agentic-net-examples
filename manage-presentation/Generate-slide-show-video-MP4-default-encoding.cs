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
                    // Attempt to obtain the MP4 SaveFormat value via reflection.
                    // MP4 is not defined in the SaveFormat enum, so this will fail.
                    Aspose.Slides.Export.SaveFormat mp4Format;
                    try
                    {
                        mp4Format = (Aspose.Slides.Export.SaveFormat)Enum.Parse(typeof(Aspose.Slides.Export.SaveFormat), "Mp4");
                    }
                    catch (ArgumentException)
                    {
                        // MP4 format is not supported by the SaveFormat enumeration.
                        Console.WriteLine("MP4 format is not supported by Aspose.Slides. Unable to generate slide show video in MP4.");
                        return;
                    }

                    // Save the presentation as a video (MP4) using default encoding settings.
                    // This may throw NotSupportedException if the format is not supported at runtime.
                    try
                    {
                        presentation.Save(outputPath, mp4Format);
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