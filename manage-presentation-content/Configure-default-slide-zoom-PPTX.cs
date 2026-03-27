using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set default zoom level for slide view and notes view (percentage)
        presentation.ViewProperties.SlideViewProperties.Scale = 150;
        presentation.ViewProperties.NotesViewProperties.Scale = 150;

        // Define output file path
        string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ZoomedPresentation.pptx");

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}