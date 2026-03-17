using System;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string sourcePath = "InputPresentation.pptx";
        // Path to the output presentation
        string outputPath = "OutputPresentation.pptx";

        try
        {
            // Load the presentation
            using (var presentation = new Aspose.Slides.Presentation(sourcePath))
            {
                // Iterate through all slides
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    // Remove notes slide associated with the current slide
                    var notesManager = slide.NotesSlideManager;
                    notesManager.RemoveNotesSlide();
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}