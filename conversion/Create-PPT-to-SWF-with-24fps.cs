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
            // Input PPT file path
            string inputPath = "input.pptx";
            // Output SWF file path
            string outputPath = "output.swf";

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

                // Create SWF options and set desired properties
                SwfOptions swfOptions = new SwfOptions();
                // Example: disable viewer if not needed
                swfOptions.ViewerIncluded = true;

                // Save as SWF (Aspose.Slides does not expose FPS for SWF directly;
                // the default frame rate is used. If specific FPS is required,
                // additional processing would be needed.)
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose presentation
                presentation.Dispose();

                Console.WriteLine("SWF file created successfully at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., network issues if external resources are used)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}