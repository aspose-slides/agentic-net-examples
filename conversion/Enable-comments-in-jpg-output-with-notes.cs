using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesCommentNotesToJpg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            // Output folder for JPG images
            string outputPath = args.Length > 1 ? args[1] : "output";

            try
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file does not exist: " + inputPath);
                    return;
                }

                // Ensure output directory exists
                if (!Directory.Exists(outputPath))
                {
                    Directory.CreateDirectory(outputPath);
                }

                // Load presentation
                Presentation pres = new Presentation(inputPath);

                // Configure rendering options to include notes and comments
                RenderingOptions renderingOptions = new RenderingOptions();
                NotesCommentsLayoutingOptions notesCommentsOptions = new NotesCommentsLayoutingOptions();
                notesCommentsOptions.NotesPosition = NotesPositions.BottomFull;          // Include speaker notes
                notesCommentsOptions.CommentsPosition = CommentsPositions.Right;        // Include comments
                notesCommentsOptions.ShowCommentsByNoAuthor = true;                     // Show comments without author
                renderingOptions.SlidesLayoutOptions = notesCommentsOptions;

                // Export each slide as JPG with the configured options
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    IImage image = pres.Slides[i].GetImage(renderingOptions, 1f, 1f);
                    string outFile = Path.Combine(outputPath, $"Slide_{i + 1}.jpg");
                    image.Save(outFile, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save presentation (required by lifecycle rule)
                pres.Save(inputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}