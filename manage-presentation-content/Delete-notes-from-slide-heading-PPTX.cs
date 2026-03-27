using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
        string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation presentation = new Presentation(inputPath);

        // Remove notes from the first slide
        INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
        notesManager.RemoveNotesSlide();

        // Save the modified presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        presentation.Dispose();

        Console.WriteLine("Notes removed. Presentation saved to: " + outputPath);
    }
}