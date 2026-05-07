using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the source presentation
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
                // Save SWF with default JPEG quality (default is 95)
                string outputDefault = "output_default.swf";
                presentation.Save(outputDefault, SaveFormat.Swf);

                // Save SWF with manually set JPEG quality of 90
                string outputCustom = "output_quality90.swf";
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.JpegQuality = 90;
                presentation.Save(outputCustom, SaveFormat.Swf, swfOptions);
            }

            // At this point you can manually compare output_default.swf and output_quality90.swf
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}