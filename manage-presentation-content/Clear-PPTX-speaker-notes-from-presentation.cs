using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ClearSpeakerNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string sourcePath = "input.pptx";
                // Path to the output presentation
                string outputPath = "output.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Remove notes slide if it exists
                        INotesSlideManager notesManager = slide.NotesSlideManager;
                        if (notesManager != null && notesManager.NotesSlide != null)
                        {
                            notesManager.RemoveNotesSlide();
                        }
                    }

                    // Save the modified presentation
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