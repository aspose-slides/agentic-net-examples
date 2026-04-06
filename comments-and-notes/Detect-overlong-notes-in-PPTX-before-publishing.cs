using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DetectOverlongNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Maximum allowed number of lines in a notes slide
            int maxLines = 5;

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        // Access the notes slide (if any)
                        Aspose.Slides.INotesSlide notesSlide = slide.NotesSlideManager.NotesSlide;
                        if (notesSlide != null)
                        {
                            // Retrieve the notes text
                            string notesText = notesSlide.NotesTextFrame.Text;

                            // Count the number of lines in the notes
                            int lineCount = notesText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Length;

                            // Flag slides with notes exceeding the maximum line count
                            if (lineCount > maxLines)
                            {
                                Console.WriteLine($"Slide {i + 1} has {lineCount} lines in notes (exceeds {maxLines}).");
                            }
                        }
                    }

                    // Save the (potentially modified) presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            // Handle unsupported file format
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            // General exception handling
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}