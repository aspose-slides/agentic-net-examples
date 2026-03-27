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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Access document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Modify built‑in properties
        documentProperties.Author = "Aspose.Slides for .NET";
        documentProperties.Title = "Modifying Presentation Properties";
        documentProperties.Subject = "Aspose Subject";

        // Retrieve and display some properties
        Console.WriteLine("Author: " + documentProperties.Author);
        Console.WriteLine("Title: " + documentProperties.Title);
        Console.WriteLine("Subject: " + documentProperties.Subject);
        Console.WriteLine("Created Time (UTC): " + documentProperties.CreatedTime);

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}