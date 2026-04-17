using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DuplicateNotesMerger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file does not exist: " + inputFilePath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation presentation = new Presentation(inputFilePath))
                {
                    // Iterate through slides and compare notes of consecutive slides
                    for (int i = 0; i < presentation.Slides.Count - 1; i++)
                    {
                        // Get notes text of current slide
                        INotesSlideManager currentManager = presentation.Slides[i].NotesSlideManager;
                        INotesSlide currentNotesSlide = currentManager.NotesSlide;
                        string currentNotesText = string.Empty;
                        if (currentNotesSlide != null && currentNotesSlide.NotesTextFrame != null)
                        {
                            currentNotesText = currentNotesSlide.NotesTextFrame.Text;
                        }

                        // Get notes text of next slide
                        INotesSlideManager nextManager = presentation.Slides[i + 1].NotesSlideManager;
                        INotesSlide nextNotesSlide = nextManager.NotesSlide;
                        string nextNotesText = string.Empty;
                        if (nextNotesSlide != null && nextNotesSlide.NotesTextFrame != null)
                        {
                            nextNotesText = nextNotesSlide.NotesTextFrame.Text;
                        }

                        // If notes are identical and not empty, remove notes from the next slide
                        if (!string.IsNullOrEmpty(currentNotesText) &&
                            currentNotesText.Equals(nextNotesText, StringComparison.Ordinal))
                        {
                            // Remove duplicate notes slide
                            nextManager.RemoveNotesSlide();
                            Console.WriteLine($"Removed duplicate notes from slide {i + 2}");
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputFilePath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}