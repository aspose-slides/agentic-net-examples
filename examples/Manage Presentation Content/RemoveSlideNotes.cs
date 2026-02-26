using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string dataDir = @"C:\Presentations\";
        string inputPath = Path.Combine(dataDir, "input.ppt");
        string outputPath = Path.Combine(dataDir, "output.ppt");

        // Load the presentation from the specified file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Access the first slide (index 0)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the notes slide manager for the slide
            Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;

            // Remove the notes slide associated with this slide
            notesManager.RemoveNotesSlide();

            // Save the modified presentation in PPT format
            presentation.Save(outputPath, SaveFormat.Ppt);
        }
    }
}