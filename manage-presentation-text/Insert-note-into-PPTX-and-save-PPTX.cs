using System;
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

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Access the notes manager for the first slide and add a notes slide
                    Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
                    Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();

                    // Set the note text
                    notesSlide.NotesTextFrame.Text = "This is a note added via Aspose.Slides.";

                    // Save the modified presentation as PPTX
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}