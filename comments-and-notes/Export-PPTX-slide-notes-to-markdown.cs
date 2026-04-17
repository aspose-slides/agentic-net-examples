using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideNotesToMarkdown
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            // Output directory for markdown files
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "NotesMarkdown");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    Aspose.Slides.INotesSlideManager notesManager = slide.NotesSlideManager;
                    Aspose.Slides.INotesSlide notesSlide = notesManager.NotesSlide;

                    if (notesSlide == null || notesSlide.NotesTextFrame == null)
                    {
                        continue; // No notes for this slide
                    }

                    Aspose.Slides.ITextFrame notesTextFrame = notesSlide.NotesTextFrame;
                    System.Text.StringBuilder markdownBuilder = new System.Text.StringBuilder();

                    // Process each paragraph in notes
                    foreach (Aspose.Slides.Paragraph paragraph in notesTextFrame.Paragraphs)
                    {
                        int depth = paragraph.ParagraphFormat.Depth;
                        string indent = new string(' ', depth * 2);
                        string bullet = "- ";
                        string line = indent + bullet + paragraph.Text;
                        markdownBuilder.AppendLine(line);
                    }

                    // Write markdown to file
                    string markdownFilePath = Path.Combine(outputDir, $"Slide_{slideIndex + 1}_Notes.md");
                    File.WriteAllText(markdownFilePath, markdownBuilder.ToString());
                }

                // Save presentation before exit (optional, preserving original format)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}