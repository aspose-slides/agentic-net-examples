using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set default zoom values (percentage) for slide view and notes view
        presentation.ViewProperties.SlideViewProperties.Scale = 100;
        presentation.ViewProperties.NotesViewProperties.Scale = 100;

        // Save the presentation in PPTX format
        presentation.Save("DefaultZoom_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}