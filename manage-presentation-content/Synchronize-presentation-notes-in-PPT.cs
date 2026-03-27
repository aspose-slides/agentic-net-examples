using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation from the input file
        Presentation presentation = new Presentation(inputPath);

        // Iterate through all slides to ensure each has a notes slide and edit its text
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            // Access the notes slide manager for the current slide
            INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;

            // Retrieve existing notes slide; create one if it does not exist
            INotesSlide notesSlide = notesManager.NotesSlide;
            if (notesSlide == null)
            {
                notesSlide = notesManager.AddNotesSlide();
            }

            // Prepend slide index to the existing notes text
            string existingText = notesSlide.NotesTextFrame.Text;
            notesSlide.NotesTextFrame.Text = "Slide " + (i + 1) + ": " + existingText;
        }

        // Synchronize notes: copy notes from the first slide to all other slides
        INotesSlideManager firstNotesManager = presentation.Slides[0].NotesSlideManager;
        INotesSlide firstNotesSlide = firstNotesManager.NotesSlide;
        if (firstNotesSlide != null)
        {
            string masterNotes = firstNotesSlide.NotesTextFrame.Text;
            for (int i = 1; i < presentation.Slides.Count; i++)
            {
                INotesSlideManager mgr = presentation.Slides[i].NotesSlideManager;
                INotesSlide ns = mgr.NotesSlide;
                if (ns == null)
                {
                    ns = mgr.AddNotesSlide();
                }
                ns.NotesTextFrame.Text = masterNotes;
            }
        }

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}