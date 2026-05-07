using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // If an argument is provided, use it as the input file
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Enable media controls in the slide show (optional, improves JS control)
                presentation.SlideShowSettings.ShowMediaControls = true;

                // Configure SWF options to allow JavaScript links (script access)
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.SkipJavaScriptLinks = false; // ensure JavaScript hyperlinks are preserved

                // Save the presentation as SWF
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose the presentation before exiting
                presentation.Dispose();

                Console.WriteLine("SWF file created successfully: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported for SWF conversion.
            }
        }
    }
}