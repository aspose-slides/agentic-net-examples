using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
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
        Presentation presentation = new Presentation(inputPath);

        // Access and modify built-in document properties
        IDocumentProperties documentProperties = presentation.DocumentProperties;
        documentProperties.Author = "John Doe";
        documentProperties.Title = "Updated Presentation";
        documentProperties.Subject = "Demo";
        documentProperties.Comments = "Modified using Aspose.Slides";
        documentProperties.Manager = "Jane Smith";

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}