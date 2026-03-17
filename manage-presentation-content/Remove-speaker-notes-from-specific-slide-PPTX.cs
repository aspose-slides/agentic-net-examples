using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteSpeakerNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string inputPath = "input.pptx";
                // Path to save the modified presentation
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Index of the slide from which to delete speaker notes (0‑based)
                    int slideIndex = 0;

                    // Obtain the notes slide manager for the specified slide
                    INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;

                    // Remove the notes slide (if it exists)
                    notesManager.RemoveNotesSlide();

                    // Save the updated presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}