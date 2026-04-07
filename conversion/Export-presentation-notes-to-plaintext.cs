using System;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportNotes
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "notes.txt";

            // Verify that the input file exists
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
                    // StringBuilder to accumulate notes text
                    StringBuilder notesBuilder = new StringBuilder();

                    // Iterate through each slide and extract notes
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        INotesSlideManager notesManager = presentation.Slides[slideIndex].NotesSlideManager;
                        INotesSlide notesSlide = notesManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            string notesText = notesSlide.NotesTextFrame.Text;
                            notesBuilder.AppendLine("Slide " + (slideIndex + 1) + ":");
                            notesBuilder.AppendLine(notesText);
                            notesBuilder.AppendLine(); // Preserve line break between slides
                        }
                    }

                    // Write the accumulated notes to a plain‑text file
                    File.WriteAllText(outputPath, notesBuilder.ToString());

                    // Save the presentation (unchanged) before exiting
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Notes exported successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}