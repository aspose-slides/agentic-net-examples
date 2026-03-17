using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Index of the slide from which to delete speaker notes (0‑based)
                int slideIndex = 0;

                if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                {
                    INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;
                    notesManager.RemoveNotesSlide();
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}