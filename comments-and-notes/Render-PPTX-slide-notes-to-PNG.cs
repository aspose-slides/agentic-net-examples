using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RenderNotesToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            // Output folder for notes images
            string outputDir = Path.Combine(Environment.CurrentDirectory, "NotesImages");
            // Output presentation path (saved after processing)
            string outputPresentationPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

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

            // Load presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Desired image dimensions for notes (high‑resolution)
                int desiredWidth = 1200;
                int desiredHeight = 800;

                // Calculate scaling factors based on slide size
                float scaleX = (float)desiredWidth / pres.SlideSize.Size.Width;
                float scaleY = (float)desiredHeight / pres.SlideSize.Size.Height;

                // Configure rendering options to include notes (bottom truncated)
                RenderingOptions renderingOpts = new RenderingOptions();
                renderingOpts.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
                {
                    NotesPosition = NotesPositions.BottomTruncated
                };

                // Iterate through each slide and render its notes
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    // Generate image with notes using rendering options and scaling
                    using (IImage img = slide.GetImage(renderingOpts, scaleX, scaleY))
                    {
                        string noteImagePath = Path.Combine(outputDir, $"Slide_{i + 1}_Notes.png");
                        img.Save(noteImagePath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the (potentially modified) presentation before exit
                try
                {
                    pres.Save(outputPresentationPath, SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported – handle accordingly
                }
            }
        }
    }
}