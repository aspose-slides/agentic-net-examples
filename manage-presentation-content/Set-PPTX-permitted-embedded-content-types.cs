using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetPermittedEmbeddedContentTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Example: Add a slide (optional)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // NOTE: Aspose.Slides does not expose a direct API named IEmbeddedObjectCollection.
                // To control embedded content, you can use LoadOptions when loading a presentation
                // or manipulate OLE objects via the slide's Shapes collection.
                // The following is a placeholder for any permitted content type configuration you may need.

                // Save the presentation as PPTX
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "PermittedEmbeddedContent_out.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}