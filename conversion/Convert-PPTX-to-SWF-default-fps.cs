using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";

        // Verify that the input PPTX file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation from the specified file
            Presentation presentation = new Presentation(inputPath);

            // Initialize SWF options with default settings
            SwfOptions swfOptions = new SwfOptions();

            // Save the presentation as SWF using default frame rate
            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Conversion to SWF completed successfully.");
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}