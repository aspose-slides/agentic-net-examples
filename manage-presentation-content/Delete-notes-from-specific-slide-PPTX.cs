using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteNotesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
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

            // Get the notes slide manager for the first slide (index 0)
            INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;

            // Remove the notes slide from the specific slide
            notesManager.RemoveNotesSlide();

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Notes removed and presentation saved to: " + outputPath);
        }
    }
}