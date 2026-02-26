using System;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("demo.pptx");
        // Set default zoom (scale) for slide view in percentages
        presentation.ViewProperties.SlideViewProperties.Scale = 100;
        // Set default zoom (scale) for notes view in percentages
        presentation.ViewProperties.NotesViewProperties.Scale = 100;
        // Save the presentation in PPT format
        presentation.Save("Zoom_out.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
    }
}