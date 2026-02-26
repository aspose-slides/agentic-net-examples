using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Set the zoom level for slide view (percentage)
            presentation.ViewProperties.SlideViewProperties.Scale = 150;
            // Set the zoom level for notes view (percentage)
            presentation.ViewProperties.NotesViewProperties.Scale = 150;

            // Save the modified presentation in PPT format
            presentation.Save("ZoomedPresentation.ppt", SaveFormat.Ppt);
        }
    }
}