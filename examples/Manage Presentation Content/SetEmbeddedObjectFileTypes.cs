using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access document properties
        Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;

        // Set the content type for PPT format
        docProps.ContentType = "application/vnd.ms-powerpoint";

        // Set the presentation format description
        docProps.PresentationFormat = "PPT";

        // Save the presentation in PPT format
        presentation.Save("ManagedPresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);

        // Dispose the presentation
        presentation.Dispose();
    }
}