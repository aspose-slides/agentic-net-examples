using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Get the notes slide manager for the first slide
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
            // Remove the notes slide from the first slide
            notesManager.RemoveNotesSlide();
            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}