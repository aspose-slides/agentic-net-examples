using System;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            System.String inputPath = "input.pptx";
            System.String outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Access built‑in document properties
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

            // Retrieve and display title, author, and slide count
            System.Console.WriteLine("Title: " + docProps.Title);
            System.Console.WriteLine("Author: " + docProps.Author);
            System.Console.WriteLine("Slide Count: " + presentation.Slides.Count);

            // Save the presentation before exiting (required by authoring rules)
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
    }
}