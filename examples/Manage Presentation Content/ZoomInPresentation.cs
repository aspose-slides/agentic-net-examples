using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set zoom for slide view (percentage)
        presentation.ViewProperties.SlideViewProperties.Scale = 150;

        // Set zoom for notes view (percentage)
        presentation.ViewProperties.NotesViewProperties.Scale = 120;

        // Save the presentation to PPTX format
        presentation.Save("ZoomedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}