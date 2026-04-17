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
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure SWF options: enable compression and include viewer UI
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.Compressed = true;          // compression flag
                swfOptions.ViewerIncluded = true;      // viewer UI flag

                // Save the presentation as SWF with the specified options
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose the presentation object
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario here
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}