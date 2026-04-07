using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.pptx");
        string outputSwfPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.swf");
        string archiveDirectory = Path.Combine(Directory.GetCurrentDirectory(), "archive");
        string archivedPath = Path.Combine(archiveDirectory, Path.GetFileName(inputPath));

        // Ensure archive directory exists
        Directory.CreateDirectory(archiveDirectory);

        // Check if input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Set SWF options
            SwfOptions swfOptions = new SwfOptions();
            swfOptions.Compressed = true; // optional setting

            // Save as SWF
            presentation.Save(outputSwfPath, SaveFormat.Swf, swfOptions);

            // Archive original file after successful conversion
            File.Move(inputPath, archivedPath);

            // Dispose presentation
            presentation.Dispose();

            Console.WriteLine("Conversion successful. Original file archived.");
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // format not supported
            Console.WriteLine("The file format is not supported for SWF conversion.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}