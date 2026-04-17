using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");

        // Check if the input file exists
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file not found: " + inputFilePath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputFilePath);

            // Configure SWF options to exclude the integrated viewer (no navigation controls)
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.ViewerIncluded = false;

            // Save the presentation as SWF
            presentation.Save(outputFilePath, SaveFormat.Swf, swfOptions);

            // Verify player compatibility (implementation depends on external player)
            Console.WriteLine("SWF file saved without navigation controls. Verify with a compatible player.");

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format
            // Format not supported
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}