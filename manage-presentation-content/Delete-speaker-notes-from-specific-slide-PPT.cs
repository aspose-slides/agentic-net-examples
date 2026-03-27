using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DeleteSpeakerNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Remove notes from the first slide (index 0)
            INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
            notesManager.RemoveNotesSlide();

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();

            Console.WriteLine("Speaker notes removed and presentation saved to: " + outputPath);
        }
    }
}