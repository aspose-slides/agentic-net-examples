using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideNotesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string dataDir = "data";
                string inputPath = System.IO.Path.Combine(dataDir, "input.pptx");
                string outputPath = System.IO.Path.Combine(dataDir, "output.pptx");

                // Load existing presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Get the notes manager for the slide
                    INotesSlideManager notesManager = slide.NotesSlideManager;

                    // Add a notes slide (creates one if it doesn't exist)
                    INotesSlide notesSlide = notesManager.AddNotesSlide();

                    // Set the notes text (formatting is preserved)
                    notesSlide.NotesTextFrame.Text = "These are the speaker notes with formatting preserved.";

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                // Re-open the saved presentation to extract notes
                using (Presentation presentation = new Presentation(outputPath))
                {
                    ISlide slide = presentation.Slides[0];
                    INotesSlideManager notesManager = slide.NotesSlideManager;
                    INotesSlide notesSlide = notesManager.NotesSlide;

                    if (notesSlide != null)
                    {
                        string notesText = notesSlide.NotesTextFrame.Text;
                        Console.WriteLine("Extracted notes: " + notesText);
                    }
                    else
                    {
                        Console.WriteLine("No notes found on the slide.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}