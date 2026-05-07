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
            inputPath = "input.pptx"; // default input file
        }

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Prepare output SWF file path
        string outputDirectory = Path.GetDirectoryName(inputPath) ?? "";
        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".swf";
        string outputPath = Path.Combine(outputDirectory, outputFileName);

        try
        {
            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Configure SWF options with compression enabled
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.Compressed = true; // enable compression

            // Save as SWF
            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            presentation.Dispose();

            // Verify that the SWF file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("SWF file created successfully: " + outputPath);
                // Manual verification: open the file in Adobe Flash Player
            }
            else
            {
                Console.WriteLine("Failed to create SWF file.");
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported for SWF conversion.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}