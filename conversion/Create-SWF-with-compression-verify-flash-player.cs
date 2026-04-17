using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "input.pptx"; // replace with actual file path
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        string outputPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? "", Path.GetFileNameWithoutExtension(inputPath) + ".swf");

        try
        {
            Presentation presentation = new Presentation(inputPath);
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.Compressed = true; // enable compression
            presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
            presentation.Dispose();

            // Verify that the SWF file was created
            if (File.Exists(outputPath))
            {
                Console.WriteLine("SWF file created successfully: " + outputPath);
                // Additional verification (e.g., checking file header) can be added here
            }
            else
            {
                Console.WriteLine("Failed to create SWF file.");
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The provided file format is not supported for conversion to SWF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}