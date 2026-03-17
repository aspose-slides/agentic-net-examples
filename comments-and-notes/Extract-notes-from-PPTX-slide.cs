using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string filePath = "input.pptx";
                using (Presentation presentation = new Presentation(filePath))
                {
                    int slideIndex = 0; // zero‑based index of the slide to extract notes from
                    ISlide slide = presentation.Slides[slideIndex];
                    INotesSlideManager notesManager = slide.NotesSlideManager;
                    INotesSlide notesSlide = notesManager.NotesSlide;

                    if (notesSlide != null && notesSlide.NotesTextFrame != null)
                    {
                        string notesText = notesSlide.NotesTextFrame.Text;
                        Console.WriteLine("Notes for slide {0}: {1}", slideIndex + 1, notesText);
                    }
                    else
                    {
                        Console.WriteLine("No notes found for slide {0}.", slideIndex + 1);
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}