using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a notes slide to the first slide
                INotesSlideManager notesManager = slide.NotesSlideManager;
                INotesSlide notesSlide = notesManager.AddNotesSlide();
                notesSlide.NotesTextFrame.Text = "Initial notes";

                // Read and display the notes text
                string currentNotes = notesSlide.NotesTextFrame.Text;
                Console.WriteLine("Current notes: " + currentNotes);

                // Update the notes text
                notesSlide.NotesTextFrame.Text = "Updated notes";

                // Remove the notes slide
                notesManager.RemoveNotesSlide();

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}