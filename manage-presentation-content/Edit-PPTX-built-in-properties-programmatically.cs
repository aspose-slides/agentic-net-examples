using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Access built‑in document properties
                Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

                // Modify writable built‑in properties
                docProps.Author = "John Doe";
                docProps.Title = "Updated Presentation";
                docProps.Subject = "Demo";
                docProps.Comments = "Modified using Aspose.Slides";

                // Save the presentation (must use SaveFormat from Aspose.Slides.Export)
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}