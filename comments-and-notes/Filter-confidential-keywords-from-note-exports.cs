using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace FilterConfidentialNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Define confidential keywords to filter
                    string[] confidentialKeywords = new string[] { "secret", "confidential", "proprietary" };

                    // Iterate through all slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        // Get the slide
                        Aspose.Slides.ISlide slide = presentation.Slides[i];

                        // Access the notes slide manager
                        Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;

                        // Retrieve the notes slide (may be null)
                        Aspose.Slides.INotesSlide notesSlide = notesManager.NotesSlide;

                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            // Get the current notes text
                            string notesText = notesSlide.NotesTextFrame.Text;

                            // Check for any confidential keyword
                            bool containsKeyword = false;
                            foreach (string keyword in confidentialKeywords)
                            {
                                if (notesText.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    containsKeyword = true;
                                    break;
                                }
                            }

                            // Replace confidential notes with a placeholder
                            if (containsKeyword)
                            {
                                notesSlide.NotesTextFrame.Text = "[REDACTED]";
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // format not supported
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}