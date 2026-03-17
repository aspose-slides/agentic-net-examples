using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load an existing presentation
            Presentation presentation = new Presentation("input.pptx");

            // Access built‑in document properties
            IDocumentProperties documentProperties = presentation.DocumentProperties;

            // Display current properties
            Console.WriteLine("Author : " + documentProperties.Author);
            Console.WriteLine("Title  : " + documentProperties.Title);
            Console.WriteLine("Subject: " + documentProperties.Subject);

            // Modify built‑in properties
            documentProperties.Author = "Aspose.Slides for .NET";
            documentProperties.Title = "Modifying Presentation Properties";
            documentProperties.Subject = "Aspose Subject";

            // Save the updated presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}