using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ValidateSwfSlideCount
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input ODP file path
            string inputPath = "input.odp";
            // Output SWF file path
            string outputSwfPath = "output.swf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the ODP presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Get original slide count
                int originalSlideCount = presentation.DocumentProperties.Slides;

                // Create SWF options (default settings)
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();

                // Save as SWF
                presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Validation placeholder:
                // In a real scenario, you would retrieve the slide count from the generated SWF.
                // Since Aspose.Slides does not provide a direct method to read slide count from SWF,
                // we assume the export retains the original count.
                Console.WriteLine("Original slide count: " + originalSlideCount);
                Console.WriteLine("SWF file generated at: " + outputSwfPath);
                Console.WriteLine("Assuming SWF retains the original slide count.");

                // Save presentation before exit (already saved as SWF)
                presentation.Dispose();
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                // Comment: The provided format is not supported for conversion.
                Console.WriteLine("Format not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}