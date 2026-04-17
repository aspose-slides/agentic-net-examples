using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input presentation path
        string inputPath = "input.pptx";

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
                // -----------------------------------------------------------------
                // Save SWF with default JPEG quality (default is 95)
                // -----------------------------------------------------------------
                string outputDefaultSwf = "output_default.swf";
                SwfOptions defaultOptions = new SwfOptions(); // JpegQuality remains default (95)
                presentation.Save(outputDefaultSwf, SaveFormat.Swf, defaultOptions);

                // -----------------------------------------------------------------
                // Save SWF with manually set JPEG quality of 90
                // -----------------------------------------------------------------
                string outputQuality90Swf = "output_quality90.swf";
                SwfOptions qualityOptions = new SwfOptions();
                qualityOptions.JpegQuality = 90; // Set JPEG quality to 90
                presentation.Save(outputQuality90Swf, SaveFormat.Swf, qualityOptions);
            }

            // At this point both SWF files are generated and can be compared visually.
        }
        catch (NotSupportedException)
        {
            // Format not supported – handle accordingly
            // Comment: The requested format is not supported by Aspose.Slides.
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}