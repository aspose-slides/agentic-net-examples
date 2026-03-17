using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide (created by default)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a notes slide for the first slide
            Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.AddNotesSlide();

            // Set the notes text
            notesSlide.NotesTextFrame.Text = "This is a sample note.";

            // Apply formatting to the first portion of the notes text
            Aspose.Slides.IPortion portion = notesSlide.NotesTextFrame.Paragraphs[0].Portions[0];
            portion.PortionFormat.FontHeight = 24f;
            portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

            // Save the presentation
            presentation.Save("NotesStyleExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}