using System;
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderNotePreviews
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for HTML snippets
            string outputDir = "output";

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
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        // Access notes slide manager
                        INotesSlideManager notesMgr = slide.NotesSlideManager;
                        INotesSlide notesSlide = notesMgr.NotesSlide;

                        // If there is no notes slide, skip
                        if (notesSlide == null)
                        {
                            continue;
                        }

                        // Retrieve notes text
                        string notesText = notesSlide.NotesTextFrame.Text;

                        // Encode text for HTML
                        string encodedText = WebUtility.HtmlEncode(notesText);

                        // Build simple HTML snippet
                        string htmlSnippet = $"<div class=\"note\" data-slide=\"{i + 1}\">{encodedText}</div>";

                        // Write snippet to file
                        string outputPath = Path.Combine(outputDir, $"note_{i + 1}.html");
                        File.WriteAllText(outputPath, htmlSnippet);
                    }

                    // Save presentation (even if unchanged) before exit
                    string savedPath = Path.Combine(outputDir, "saved.pptx");
                    presentation.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}