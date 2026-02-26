using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation instance
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the content type to indicate a PPT file
        presentation.DocumentProperties.ContentType = "application/vnd.ms-powerpoint";

        // Optionally specify the intended presentation format
        presentation.DocumentProperties.PresentationFormat = "PPT";

        // Save the presentation in PPT format
        presentation.Save("ManagedPresentation.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}