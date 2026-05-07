using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine the directory to process
        string directoryPath;
        if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
        {
            directoryPath = args[0];
        }
        else
        {
            directoryPath = Directory.GetCurrentDirectory();
        }

        // Verify the directory exists
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Directory does not exist: " + directoryPath);
            return;
        }

        // Get all ODP files in the directory
        string[] files = Directory.GetFiles(directoryPath, "*.odp", SearchOption.TopDirectoryOnly);
        foreach (string inputPath in files)
        {
            // Ensure the file exists before processing
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                continue;
            }

            // Prepare output SWF file path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(directoryPath, fileNameWithoutExt + ".swf");

            try
            {
                // Load the ODP presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Convert to SWF using default options (rule: convert-without-xps-options)
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf);
                }

                Console.WriteLine("Converted: " + inputPath + " -> " + outputPath);
            }
            catch (InvalidOperationException)
            {
                // Format not supported
                Console.WriteLine("Conversion not supported for file: " + inputPath);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing file: " + inputPath);
                Console.WriteLine(ex.Message);
            }
        }
    }
}