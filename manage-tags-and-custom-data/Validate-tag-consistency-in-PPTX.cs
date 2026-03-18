using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add a custom tag to uniquely identify the presentation content
                ITagCollection tags = presentation.CustomData.Tags;
                tags["UniqueId"] = Guid.NewGuid().ToString();

                // Save the presentation before exiting
                presentation.Save("TaggedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}