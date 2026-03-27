using System;
using System.IO;
using Aspose.Slides.Export;

namespace RemoveNotesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output_without_notes.pptx");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides and remove notes
            for (int i = 0; i < presentation.Slides.Count; i++)
            {
                Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                notesManager.RemoveNotesSlide();
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Notes removed and presentation saved to: " + outputPath);
        }
    }
}