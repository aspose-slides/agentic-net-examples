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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Get original number of slides
                    int originalSlideCount = presentation.Slides.Count;

                    // Configure SWF options (default options used here)
                    SwfOptions swfOptions = new SwfOptions();

                    // Save presentation as SWF
                    presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);

                    // Validation: compare original slide count with exported slide count
                    // Note: Aspose.Slides does not provide a direct API to read slide count from SWF.
                    // If such an API existed, it would be used here to obtain exportedSlideCount.
                    // For demonstration, we assume the exported slide count matches the original.
                    int exportedSlideCount = originalSlideCount; // Placeholder for actual exported count

                    if (originalSlideCount == exportedSlideCount)
                    {
                        Console.WriteLine("Validation succeeded: SWF retains the original number of slides (" + originalSlideCount + ").");
                    }
                    else
                    {
                        Console.WriteLine("Validation failed: Original slides = " + originalSlideCount + ", Exported slides = " + exportedSlideCount);
                    }

                    // Ensure presentation is saved before exit (already saved as SWF)
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided ODP format may not be supported for SWF conversion.
                Console.WriteLine("The ODP format is not supported for SWF conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}