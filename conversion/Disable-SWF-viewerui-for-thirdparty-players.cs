using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input file path
        string inputPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            Console.WriteLine("Please provide input presentation file path as argument.");
            return;
        }

        // Verify file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Determine output path
        string directory = Path.GetDirectoryName(inputPath);
        string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
        string outputPath = Path.Combine(directory ?? "", filenameWithoutExt + "_noViewer.swf");

        try
        {
            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure SWF options to disable viewer UI
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.ViewerIncluded = false;

            // Save as SWF
            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

            // Dispose presentation
            presentation.Dispose();

            Console.WriteLine("SWF saved without viewer UI to: " + outputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}