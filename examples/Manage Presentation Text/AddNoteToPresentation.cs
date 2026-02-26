using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define directories and file paths
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Load the existing presentation
        Presentation presentation = new Presentation(inputPath);

        // Add a notes slide to the first slide and set its text
        INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
        INotesSlide notesSlide = notesManager.AddNotesSlide();
        notesSlide.NotesTextFrame.Text = "Your notes here";

        // Save the modified presentation as PPTX
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}