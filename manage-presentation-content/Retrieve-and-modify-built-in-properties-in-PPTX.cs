using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationPropertiesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "sample.pptx";
            string outputPath = "sample_modified.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access built‑in document properties
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Modify built‑in properties
            documentProperties.Author = "Aspose.Slides for .NET";
            documentProperties.Title = "Modifying Presentation Properties";
            documentProperties.Subject = "Aspose Subject";

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}