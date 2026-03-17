using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Index of the slide whose speaker notes should be removed
                int slideIndex = 0;

                if (slideIndex >= 0 && slideIndex < presentation.Slides.Count)
                {
                    Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;
                    notesManager.RemoveNotesSlide();
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}