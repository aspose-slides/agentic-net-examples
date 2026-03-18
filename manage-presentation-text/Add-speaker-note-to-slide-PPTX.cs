using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    int slideIndex = 0; // index of the slide to add note to
                    ISlide slide = presentation.Slides[slideIndex];
                    INotesSlideManager notesManager = slide.NotesSlideManager;
                    INotesSlide notesSlide = notesManager.AddNotesSlide();
                    notesSlide.NotesTextFrame.Text = "This is a speaker note.";

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