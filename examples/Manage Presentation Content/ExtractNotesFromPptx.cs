using System;
using Aspose.Slides;

namespace MyPresentationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string sourcePath = "input.pptx";
            // Path to the output presentation
            string outputPath = "output_with_notes.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Access the notes slide manager for the first slide
                Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;

                // Add a notes slide (creates one if it doesn't exist)
                Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();

                // Set the notes text
                notesSlide.NotesTextFrame.Text = "Your Notes";

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}