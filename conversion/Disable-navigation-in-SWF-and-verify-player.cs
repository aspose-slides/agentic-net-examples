using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSwfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure SWF options: disable integrated viewer (no navigation controls)
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ViewerIncluded = false;

                // Save as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Verify player compatibility (placeholder - actual verification depends on player)
                Console.WriteLine("SWF file saved without navigation controls: " + outputPath);
                Console.WriteLine("Please verify compatibility with your SWF player.");

                // Dispose presentation
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for conversion to SWF.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}