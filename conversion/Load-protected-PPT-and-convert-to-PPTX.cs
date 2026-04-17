using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputFileName = "protected.ppt";
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        string outputFileName = "converted.pptx";
        string outputPath = Path.Combine(outputDir, outputFileName);
        string password = "myPassword";

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Load password‑protected presentation
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.Password = password;
            Presentation presentation = new Presentation(inputPath, loadOptions);

            // Convert and save as PPTX
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation converted and saved to: " + outputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}