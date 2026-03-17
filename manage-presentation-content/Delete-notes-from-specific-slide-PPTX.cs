using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var dataDir = "C:\\Presentations\\";
            var inputPath = System.IO.Path.Combine(dataDir, "AccessSlides.pptx");
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slideIndex = 0; // index of the slide to modify
                var notesManager = presentation.Slides[slideIndex].NotesSlideManager;
                notesManager.RemoveNotesSlide();

                var outputPath = System.IO.Path.Combine(dataDir, "RemoveNotesAtSpecificSlide_out.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}