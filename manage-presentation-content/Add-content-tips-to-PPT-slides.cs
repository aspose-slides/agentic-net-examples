using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ContentTipsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // ---------- Add a notes slide (content tip) to the first slide ----------
            INotesSlideManager notesManagerFirst = presentation.Slides[0].NotesSlideManager;
            INotesSlide notesSlideFirst = notesManagerFirst.AddNotesSlide();
            notesSlideFirst.NotesTextFrame.Text = "This is a newly added content tip for the first slide.";

            // ---------- Edit the notes (content tip) of the second slide, if it exists ----------
            if (presentation.Slides.Count > 1)
            {
                INotesSlideManager notesManagerSecond = presentation.Slides[1].NotesSlideManager;
                // If a notes slide already exists, edit its text; otherwise, create one and set text
                if (notesManagerSecond.NotesSlide != null)
                {
                    notesManagerSecond.NotesSlide.NotesTextFrame.Text = "Edited content tip for the second slide.";
                }
                else
                {
                    INotesSlide notesSlideSecond = notesManagerSecond.AddNotesSlide();
                    notesSlideSecond.NotesTextFrame.Text = "Added content tip for the second slide.";
                }
            }

            // ---------- Remove the notes slide (content tip) from the third slide, if it exists ----------
            if (presentation.Slides.Count > 2)
            {
                INotesSlideManager notesManagerThird = presentation.Slides[2].NotesSlideManager;
                notesManagerThird.RemoveNotesSlide();
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation processing completed. Output saved to: " + outputPath);
        }
    }
}