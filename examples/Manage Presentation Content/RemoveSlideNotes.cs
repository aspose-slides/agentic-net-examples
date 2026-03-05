using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Define the directory containing the presentation files
        string dataDir = "path_to_presentation_directory\\";
        // Input PPTX file path
        string inputPath = System.IO.Path.Combine(dataDir, "AccessSlides.pptx");
        // Output PPTX file path
        string outputPath = System.IO.Path.Combine(dataDir, "RemoveNotesAtSpecificSlide_out.pptx");

        // Load the presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Access the notes slide manager for the first slide (index 0)
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
            // Remove the notes slide associated with this slide
            notesManager.RemoveNotesSlide();

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}