using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.odp";
        string outputPath = "output.swf";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the ODP presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure SWF options with JPEG quality set to 50
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.JpegQuality = 50;

            // Save the presentation as SWF
            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}