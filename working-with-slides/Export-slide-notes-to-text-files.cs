using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation file path
        string inputPath = "input.pptx";
        // Output directory for notes files
        string outputDir = "NotesOutput";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Ensure output directory exists
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
            return;
        }

        // Export notes from each slide
        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[i];
            Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
            string notesText = string.Empty;

            if (notesSlide != null && notesSlide.NotesTextFrame != null)
            {
                notesText = notesSlide.NotesTextFrame.Text;
            }

            string noteFilePath = Path.Combine(outputDir, $"Slide_{i + 1}_Notes.txt");
            File.WriteAllText(noteFilePath, notesText);
        }

        // Save the presentation before exiting
        presentation.Save(inputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}