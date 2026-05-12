using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlideNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output text file path (fallback since DOCX is not supported)
            string outputPath = "SlideNotes.txt";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // StringBuilder to collect notes
                StringBuilder notesBuilder = new StringBuilder();

                // Iterate through slides and extract notes
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    INotesSlideManager notesManager = presentation.Slides[i].NotesSlideManager;
                    INotesSlide notesSlide = notesManager.NotesSlide;
                    if (notesSlide != null && notesSlide.NotesTextFrame != null && notesSlide.NotesTextFrame.Text != null)
                    {
                        notesBuilder.AppendLine("Slide " + (i + 1) + " Notes:");
                        notesBuilder.AppendLine(notesSlide.NotesTextFrame.Text);
                        notesBuilder.AppendLine();
                    }
                }

                // Write notes to a text file (DOCX export is not supported by Aspose.Slides)
                File.WriteAllText(outputPath, notesBuilder.ToString(), Encoding.UTF8);
                Console.WriteLine("Slide notes exported to: " + outputPath);

                // Save the presentation before exiting (using a supported format)
                presentation.Save("SavedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Format not supported comment
                Console.WriteLine("The requested format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}