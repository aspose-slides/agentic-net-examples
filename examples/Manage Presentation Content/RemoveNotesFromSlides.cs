using System;

class Program
{
    static void Main()
    {
        // Path to the source PPTX file
        string sourcePath = "input.pptx";
        // Path where the output PPTX will be saved
        string outputPath = "output_without_notes.pptx";

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
        {
            // Loop through all slides in the presentation
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                // Access the notes slide manager for the current slide
                Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                // Remove the notes slide (if it exists)
                notesManager.RemoveNotesSlide();
            }

            // Save the modified presentation in PPTX format
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}