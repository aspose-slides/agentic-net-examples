using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a notes slide (speaker note) if it doesn't exist
            Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;
            Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();

            // Set the speaker note text
            notesSlide.NotesTextFrame.Text = "This is a speaker note added via Aspose.Slides.";

            // Save the presentation with the new note
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}