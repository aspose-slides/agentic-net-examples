using System;
using Aspose.Slides.Export;

namespace InsertSpeakerNotes
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Paths for input and output files
                var sourcePath = "input.pptx";
                var outputPath = "output.pptx";

                // Load the presentation
                var presentation = new Aspose.Slides.Presentation(sourcePath);

                // Index of the slide to add notes (0‑based)
                var slideIndex = 0;

                // Get the notes slide manager for the target slide
                var notesManager = presentation.Slides[slideIndex].NotesSlideManager;

                // Add a notes slide (creates if it doesn't exist)
                var notesSlide = notesManager.AddNotesSlide();

                // Set the speaker notes text
                notesSlide.NotesTextFrame.Text = "These are speaker notes for slide " + (slideIndex + 1);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}