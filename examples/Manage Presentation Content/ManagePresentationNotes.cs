using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string dataDir = "Data";
        string inputFile = System.IO.Path.Combine(dataDir, "Input.pptx");
        string outputFile = System.IO.Path.Combine(dataDir, "Output.pptx");

        // Load an existing presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputFile))
        {
            // Add notes to the first slide
            Aspose.Slides.INotesSlideManager firstSlideNotesMgr = presentation.Slides[0].NotesSlideManager;
            Aspose.Slides.INotesSlide firstNotesSlide = firstSlideNotesMgr.AddNotesSlide();
            firstNotesSlide.NotesTextFrame.Text = "Speaker notes for the first slide.";

            // Remove notes from the second slide if it exists
            if (presentation.Slides.Count > 1)
            {
                Aspose.Slides.INotesSlideManager secondSlideNotesMgr = presentation.Slides[1].NotesSlideManager;
                secondSlideNotesMgr.RemoveNotesSlide();
            }

            // Save the modified presentation
            presentation.Save(outputFile, SaveFormat.Pptx);
        }
    }
}