using System;
using Aspose.Slides.Export;

namespace ContentTipsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths for input and output presentations
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                // Load the presentation
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // ---------- Add a note (content tip) to the first slide ----------
                    var notesManager0 = presentation.Slides[0].NotesSlideManager;
                    var notesSlide0 = notesManager0.AddNotesSlide();
                    notesSlide0.NotesTextFrame.Text = "Initial tip for slide 1";

                    // ---------- Edit the note on the first slide ----------
                    notesSlide0.NotesTextFrame.Text = "Edited tip for slide 1";

                    // ---------- Remove the note from the second slide (if it exists) ----------
                    var notesManager1 = presentation.Slides[1].NotesSlideManager;
                    notesManager1.RemoveNotesSlide();

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}