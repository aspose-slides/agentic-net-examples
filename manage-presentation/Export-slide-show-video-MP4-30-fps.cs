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
                // Attempt to obtain the MP4 SaveFormat value dynamically.
                // If the enum does not contain "Mp4", an exception will be thrown.
                SaveFormat mp4Format = (SaveFormat)Enum.Parse(typeof(SaveFormat), "Mp4");

                // Export the slide show as an MP4 video.
                // Note: Aspose.Slides uses the default frame rate for video export.
                // If a specific frame rate is required, it can be set via video export options
                // (not shown here because such options are not part of the provided rules).
                pres.Save(outputPath, mp4Format);
            }

            // Presentation has been saved; no further action required.
        }
        catch (ArgumentException)
        {
            // Thrown by Enum.Parse when "Mp4" is not a valid enum name.
            // MP4 format is not supported by the current Aspose.Slides version.
            Console.WriteLine("MP4 format is not supported for saving.");
        }
        catch (NotSupportedException)
        {
            // Thrown by Presentation.Save if the format is unsupported.
            Console.WriteLine("Saving to MP4 is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling (e.g., I/O errors, web service failures).
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}