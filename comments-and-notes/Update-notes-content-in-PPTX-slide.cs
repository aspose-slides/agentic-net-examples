using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the notes slide manager for the slide
            Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;

            // Add a notes slide (creates one if it doesn't exist)
            Aspose.Slides.INotesSlide notesSlide = notesManager.AddNotesSlide();

            // Update the notes text
            notesSlide.NotesTextFrame.Text = "Updated notes content.";

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}