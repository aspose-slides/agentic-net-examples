using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveNotesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Remove notes from the first slide (index 0)
            Aspose.Slides.INotesSlideManager notesManager = presentation.Slides[0].NotesSlideManager;
            notesManager.RemoveNotesSlide();

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            presentation.Dispose();

            Console.WriteLine($"Notes removed and presentation saved to: {outputPath}");
        }
    }
}