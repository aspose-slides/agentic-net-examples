using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation from the input file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Get the document properties object
            Aspose.Slides.IDocumentProperties properties = presentation.DocumentProperties;

            // Update built‑in properties
            properties.Author = "John Doe";
            properties.Title = "Updated Presentation";
            properties.Subject = "Demo";
            properties.Comments = "Updated using Aspose.Slides";

            // Save the presentation to the output file
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}