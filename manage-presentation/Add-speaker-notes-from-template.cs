using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddSpeakerNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input presentation, notes template and output presentation
            string inputPath = "input.pptx";
            string notesTemplatePath = "notes.txt";
            string outputPath = "output.pptx";

            // Verify that input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist.");
                return;
            }

            if (!File.Exists(notesTemplatePath))
            {
                Console.WriteLine("Notes template file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Read notes template (one line per slide)
                string[] notesLines = File.ReadAllLines(notesTemplatePath);

                // Add speaker notes to each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    INotesSlideManager notesManager = slide.NotesSlideManager;
                    INotesSlide notesSlide = notesManager.AddNotesSlide();

                    // Use corresponding line from template or a default note
                    string noteText = i < notesLines.Length ? notesLines[i] : "Speaker notes not provided.";
                    notesSlide.NotesTextFrame.Text = noteText;
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to unsupported format, the format is not supported.
            }
        }
    }
}