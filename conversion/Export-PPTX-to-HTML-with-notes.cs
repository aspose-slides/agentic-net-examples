using System;
using System.IO;
using System.Text;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HtmlFromPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            var inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                // Load presentation
                var presentation = new Aspose.Slides.Presentation(inputPath);

                // Build HTML content
                var sb = new StringBuilder();
                sb.AppendLine("<html><body>");

                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    var slide = presentation.Slides[i];
                    sb.AppendLine($"<h2>Slide {i + 1}</h2>");

                    // Retrieve or create notes slide
                    var notesManager = slide.NotesSlideManager;
                    var notesSlide = notesManager.NotesSlide;
                    if (notesSlide == null)
                    {
                        notesSlide = notesManager.AddNotesSlide();
                    }

                    var notesText = notesSlide?.NotesTextFrame?.Text ?? string.Empty;
                    sb.AppendLine("<div class=\"notes\">");
                    sb.AppendLine(WebUtility.HtmlEncode(notesText));
                    sb.AppendLine("</div>");
                }

                sb.AppendLine("</body></html>");

                // Write HTML to file
                var outputPath = Path.Combine(Environment.CurrentDirectory, "output.html");
                File.WriteAllText(outputPath, sb.ToString());

                // Save presentation before exit
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("HTML generated at " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // format not supported
            }
        }
    }
}