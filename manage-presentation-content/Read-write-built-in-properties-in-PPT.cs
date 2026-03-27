using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DocumentPropertiesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access built‑in document properties
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Display current built‑in properties
            Console.WriteLine("Author   : " + documentProperties.Author);
            Console.WriteLine("Title    : " + documentProperties.Title);
            Console.WriteLine("Subject  : " + documentProperties.Subject);
            Console.WriteLine("Comments : " + documentProperties.Comments);

            // Modify some built‑in properties
            documentProperties.Author = "Aspose.Slides for .NET";
            documentProperties.Title = "Modified Presentation Properties";
            documentProperties.Subject = "Demo of Property Access";
            documentProperties.Comments = "Updated via Aspose.Slides API";

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}