using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationImageComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for images
            string outputDir = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
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
                    // ---------- Convert slides to JPG without comments ----------
                    long totalSizeNoComments = 0;
                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        IImage image = slide.GetImage(1f, 1f);
                        string filePath = Path.Combine(outputDir, $"Slide_{i + 1}_noComments.jpg");
                        image.Save(filePath, ImageFormat.Jpeg);
                        totalSizeNoComments += new FileInfo(filePath).Length;
                    }

                    // ---------- Convert slides to JPG with comments ----------
                    long totalSizeWithComments = 0;
                    RenderingOptions renderingOptions = new RenderingOptions();
                    NotesCommentsLayoutingOptions notesComments = new NotesCommentsLayoutingOptions();
                    notesComments.CommentsPosition = CommentsPositions.Right;
                    renderingOptions.SlidesLayoutOptions = notesComments;

                    for (int i = 0; i < presentation.Slides.Count; i++)
                    {
                        ISlide slide = presentation.Slides[i];
                        IImage image = slide.GetImage(renderingOptions, 1f, 1f);
                        string filePath = Path.Combine(outputDir, $"Slide_{i + 1}_withComments.jpg");
                        image.Save(filePath, ImageFormat.Jpeg);
                        totalSizeWithComments += new FileInfo(filePath).Length;
                    }

                    // Output size comparison
                    Console.WriteLine($"Total size without comments: {totalSizeNoComments} bytes");
                    Console.WriteLine($"Total size with comments: {totalSizeWithComments} bytes");

                    // Save the presentation before exit
                    string presentationOutput = Path.Combine(outputDir, "output.pptx");
                    presentation.Save(presentationOutput, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}