using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "presentation.pptx";
            string outputPath = "notes.txt";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    StringBuilder notesBuilder = new StringBuilder();

                    // Iterate through all slides and extract notes
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            string notesText = notesSlide.NotesTextFrame.Text;
                            notesBuilder.AppendLine("Slide " + (slideIndex + 1) + " Notes:");
                            notesBuilder.AppendLine(notesText);
                            notesBuilder.AppendLine(); // Preserve line break between slides
                        }
                    }

                    // Write the collected notes to a plain‑text file
                    File.WriteAllText(outputPath, notesBuilder.ToString());

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Notes exported successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
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