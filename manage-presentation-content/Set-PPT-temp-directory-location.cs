using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input presentation path
        var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Temporary files root directory
        var tempRoot = Path.Combine(Directory.GetCurrentDirectory(), "TempFiles");
        if (!Directory.Exists(tempRoot))
            Directory.CreateDirectory(tempRoot);

        // Output directory and file
        var outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        var outputPath = Path.Combine(outputDir, "output.pptx");

        // Configure load options with custom temporary files directory
        var loadOptions = new LoadOptions
        {
            BlobManagementOptions = new BlobManagementOptions
            {
                IsTemporaryFilesAllowed = true,
                TempFilesRootPath = tempRoot
            }
        };

        // Load presentation with the specified options
        using (var presentation = new Presentation(inputPath, loadOptions))
        {
            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}