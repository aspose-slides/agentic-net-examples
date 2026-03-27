using System;
using System.IO;
using Aspose.Slides.Export;

namespace UpdatePresentationProperties
{
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

            // Access built-in document properties
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;
            documentProperties.Author = "John Doe";
            documentProperties.Title = "Updated Presentation";
            documentProperties.Subject = "Demo Subject";
            documentProperties.Comments = "Updated using Aspose.Slides";
            documentProperties.Manager = "Jane Smith";

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation properties updated and saved to: " + outputPath);
        }
    }
}