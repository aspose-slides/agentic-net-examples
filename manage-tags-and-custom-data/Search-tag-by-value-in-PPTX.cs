using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationTagExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the tag collection from custom data
                Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;

                // Add custom metadata tags
                tags["DocumentId"] = "DOC-2023-001";
                tags["Author"] = "John Doe";
                tags["Department"] = "Finance";

                // Save the presentation before exiting
                presentation.Save("TaggedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}