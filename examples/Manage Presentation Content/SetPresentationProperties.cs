using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            System.String inputPath = "input.pptx";
            System.String outputPath = "output.pptx";

            // Load the presentation from the input file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the built-in document properties
            Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Modify built-in properties
            documentProperties.Author = "John Doe";
            documentProperties.Title = "Sample Title";
            documentProperties.Subject = "Sample Subject";
            documentProperties.Comments = "Sample Comments";
            documentProperties.Manager = "Jane Manager";

            // Save the presentation in PPTX format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}