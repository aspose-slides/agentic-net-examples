using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddCustomProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = "Data" + Path.DirectorySeparatorChar;
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the document properties object
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Add custom document properties
            documentProperties["ProjectId"] = 12345;
            documentProperties["AuthorNotes"] = "Reviewed by QA team";
            documentProperties["Revision"] = 2;

            // Optionally modify built‑in properties
            documentProperties.Author = "John Doe";
            documentProperties.Title = "Quarterly Report";

            // Save the presentation with the new properties
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}