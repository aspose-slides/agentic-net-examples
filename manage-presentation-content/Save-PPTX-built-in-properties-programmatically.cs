using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access built‑in document properties
                Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

                // Update properties
                documentProperties.Author = "Aspose.Slides for .NET";
                documentProperties.Title = "Modifying Presentation Properties";
                documentProperties.Subject = "Aspose Subject";

                // Save the updated presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}