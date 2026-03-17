using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access built‑in document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Display current properties
            Console.WriteLine("Author   : " + docProps.Author);
            Console.WriteLine("Title    : " + docProps.Title);
            Console.WriteLine("Subject  : " + docProps.Subject);
            Console.WriteLine("Comments : " + docProps.Comments);

            // Modify writable built‑in properties
            docProps.Author = "Aspose.Slides for .NET";
            docProps.Title = "Modifying Presentation Properties";
            docProps.Subject = "Aspose Subject";
            docProps.Comments = "Updated via code";

            // Save the updated presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}