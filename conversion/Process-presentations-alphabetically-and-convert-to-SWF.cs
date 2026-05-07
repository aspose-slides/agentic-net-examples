using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output directories
        string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
        string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

        // Verify input directory exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine("Input directory does not exist.");
            return;
        }

        // Create output directory if it does not exist
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all files in the input directory and sort them alphabetically
        string[] inputFiles = Directory.GetFiles(inputDirectory);
        Array.Sort(inputFiles, StringComparer.OrdinalIgnoreCase);

        // Process each presentation file
        foreach (string inputFilePath in inputFiles)
        {
            // Check if the file actually exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("File not found: " + inputFilePath);
                continue;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFilePath))
                {
                    // Prepare output file path with .swf extension
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputFilePath);
                    string outputFilePath = Path.Combine(outputDirectory, fileNameWithoutExtension + ".swf");

                    // Save the presentation as SWF
                    presentation.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Swf);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The source presentation format is not supported for SWF conversion.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("Error processing file '" + inputFilePath + "': " + ex.Message);
            }
        }
    }
}