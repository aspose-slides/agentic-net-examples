using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Modify built‑in properties
        documentProperties.Author = "John Doe";
        documentProperties.Title = "Updated Presentation";
        documentProperties.Subject = "Demo";

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();

        Console.WriteLine("Presentation saved to " + outputPath);
    }
}