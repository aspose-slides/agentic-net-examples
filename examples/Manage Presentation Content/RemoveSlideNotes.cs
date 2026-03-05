using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Define the directory containing the presentation file
        string dataDir = "path_to_pptx_directory/";

        // Load the existing PPTX presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(dataDir + "AccessSlides.pptx"))
        {
            // Access the notes slide manager for the first slide (index 0)
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;

            // Remove the notes slide associated with this slide
            notesManager.RemoveNotesSlide();

            // Save the modified presentation to a new file
            presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}