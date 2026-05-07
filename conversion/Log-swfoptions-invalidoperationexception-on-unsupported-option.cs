using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Create SWF options
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ViewerIncluded = true;

                try
                {
                    // Attempt to set an unsupported SlidesLayoutOptions value
                    // This should throw InvalidOperationException
                    swfOptions.SlidesLayoutOptions = new HandoutLayoutingOptions();
                }
                catch (InvalidOperationException ex)
                {
                    // Log the exception when an unsupported option is set
                    Console.WriteLine("InvalidOperationException caught: " + ex.Message);
                }

                // Save the presentation as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                // Save presentation before exit (already saved)
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}