using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Default input and output paths
        string inputPath = "input.pptx";
        string outputPath = "output.swf";
        // Default viewer inclusion
        bool includeViewer = true;

        // Override with command line arguments if provided
        if (args.Length >= 2)
        {
            inputPath = args[0];
            outputPath = args[1];
        }
        if (args.Length >= 3)
        {
            // Third argument determines whether to include the viewer ("true" or "false")
            includeViewer = !string.Equals(args[2], "false", StringComparison.OrdinalIgnoreCase);
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
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Configure SWF options
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ViewerIncluded = includeViewer;

                // Save as SWF with the specified options
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}