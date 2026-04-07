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
            string inputPath = "input.pptx";
            string notesOutputPath = "SlideNotes.docx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    StringBuilder notesBuilder = new StringBuilder();

                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        INotesSlide notesSlide = presentation.Slides[slideIndex].NotesSlideManager.NotesSlide;
                        if (notesSlide != null && notesSlide.NotesTextFrame != null)
                        {
                            notesBuilder.AppendLine("Slide " + (slideIndex + 1) + ":");
                            notesBuilder.AppendLine(notesSlide.NotesTextFrame.Text);
                            notesBuilder.AppendLine();
                        }
                    }

                    File.WriteAllText(notesOutputPath, notesBuilder.ToString());

                    // Save the presentation before exiting as required
                    presentation.Save("SavedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O, unexpected errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}