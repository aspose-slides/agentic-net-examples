using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output folder paths
        string inputFolder;
        string outputFolder;
        if (args.Length > 1 && !String.IsNullOrEmpty(args[0]) && !String.IsNullOrEmpty(args[1]))
        {
            inputFolder = args[0];
            outputFolder = args[1];
        }
        else
        {
            Console.WriteLine("Usage: program <inputFolder> <outputFolder>");
            return;
        }

        // Verify input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist.");
            return;
        }

        // Ensure output folder exists
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Process each file in the input folder
        string[] files = Directory.GetFiles(inputFolder);
        foreach (string filePath in files)
        {
            try
            {
                // Determine output SWF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(filePath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".swf");

                // Skip conversion if SWF already exists
                if (File.Exists(outputPath))
                {
                    continue;
                }

                // Load presentation and convert to SWF
                using (Presentation presentation = new Presentation(filePath))
                {
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.Compressed = true; // Example option
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("Error processing file: " + filePath);
                Console.WriteLine(ex.Message);
            }
        }
    }
}