using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveEmptyCommentsAndNotes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output_cleaned.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];

                        // Remove empty comments
                        IComment[] slideComments = slide.GetSlideComments(null);
                        foreach (IComment comment in slideComments)
                        {
                            if (string.IsNullOrWhiteSpace(comment.Text))
                            {
                                comment.Remove();
                            }
                        }

                        // Remove empty notes
                        INotesSlideManager notesManager = slide.NotesSlideManager;
                        if (notesManager != null && notesManager.NotesSlide != null)
                        {
                            INotesSlide notesSlide = notesManager.NotesSlide;
                            if (notesSlide.NotesTextFrame == null ||
                                string.IsNullOrWhiteSpace(notesSlide.NotesTextFrame.Text))
                            {
                                notesManager.RemoveNotesSlide();
                            }
                        }
                    }

                    // Save the cleaned presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Format not supported
                Console.WriteLine("Unsupported file format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}