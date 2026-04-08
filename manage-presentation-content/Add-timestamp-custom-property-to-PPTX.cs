using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        var inputPath = "input.pptx";
        var outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            var presentation = new Presentation(inputPath);

            // Access document properties
            var documentProperties = presentation.DocumentProperties;

            // Add a custom property with the current UTC timestamp
            documentProperties["ExportedOn"] = DateTime.UtcNow;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: The provided file format is not supported by Aspose.Slides.
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., I/O errors)
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}