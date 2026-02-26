using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation file
        string sourcePath = "input.pptx";
        // Path to the output presentation file
        string outputPath = "output.pptx";

        // Obtain presentation information using PresentationFactory
        Aspose.Slides.IPresentationInfo presentationInfo = Aspose.Slides.PresentationFactory.Instance.GetPresentationInfo(sourcePath);
        // Read the document properties of the binded presentation
        Aspose.Slides.IDocumentProperties documentProperties = presentationInfo.ReadDocumentProperties();

        // Display some built‑in properties
        Console.WriteLine("Title: " + documentProperties.Title);
        Console.WriteLine("Author: " + documentProperties.Author);
        Console.WriteLine("Created Time: " + documentProperties.CreatedTime);
        Console.WriteLine("Subject: " + documentProperties.Subject);

        // Load the presentation to be able to save it
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}