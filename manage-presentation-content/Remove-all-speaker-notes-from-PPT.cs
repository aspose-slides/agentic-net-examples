using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define data directory and file paths
        string dataDir = Path.Combine(Environment.CurrentDirectory, "Data");
        string inputPath = Path.Combine(dataDir, "input.pptx");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Remove notes from each slide
        for (int index = 0; index < presentation.Slides.Count; index++)
        {
            INotesSlideManager notesManager = presentation.Slides[index].NotesSlideManager;
            notesManager.RemoveNotesSlide();
        }

        // Save the modified presentation
        presentation.Save(outputPath, SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}