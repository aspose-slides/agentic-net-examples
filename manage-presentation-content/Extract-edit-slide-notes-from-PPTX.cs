using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideNotesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "InputPresentation.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "OutputPresentation.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Access the first slide
                ISlide firstSlide = presentation.Slides[0];

                // Add a notes slide (creates one if it does not exist)
                INotesSlideManager notesManager = firstSlide.NotesSlideManager;
                INotesSlide notesSlide = notesManager.AddNotesSlide();

                // Set notes text while preserving formatting
                notesSlide.NotesTextFrame.Text = "These are the notes for the first slide.";

                // Extract and display the notes text from the first slide
                INotesSlide existingNotes = notesManager.NotesSlide;
                if (existingNotes != null && existingNotes.NotesTextFrame != null)
                {
                    string extractedText = existingNotes.NotesTextFrame.Text;
                    Console.WriteLine("Extracted notes: " + extractedText);
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}