using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportToMp4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output video path
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
                    // Attempt to save as MP4 using a dynamic enum value.
                    // The SaveFormat enum does not contain Mp4 in this version,
                    // so we parse the name at runtime. If the format is unsupported,
                    // an exception will be thrown and handled below.
                    Aspose.Slides.Export.SaveFormat mp4Format = (Aspose.Slides.Export.SaveFormat)Enum.Parse(
                        typeof(Aspose.Slides.Export.SaveFormat), "Mp4", true);

                    // Save the presentation as MP4 video.
                    // This will render slide animations correctly if the format is supported.
                    presentation.Save(outputPath, mp4Format);
                }

                Console.WriteLine("Presentation exported to MP4 successfully.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported by the current Aspose.Slides version.
                Console.WriteLine("MP4 export is not supported in this version of Aspose.Slides.");
            }
            catch (NotSupportedException)
            {
                // General not supported exception.
                Console.WriteLine("MP4 export is not supported for the given presentation.");
            }
            catch (Exception ex)
            {
                // Handle any other unexpected errors.
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}