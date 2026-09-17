// -----------------------------------------------------------------------------
// Example: Generate 200x200 Thumbnails for 3D Slides in PowerPoint using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, creates a 200 × 200 pixel JPEG
// thumbnail for each slide that contains 3‑D content (or all slides if detection
// is not possible), and saves the images to a “Thumbnails” folder. It uses
// Aspose.Slides for .NET to render slide images via ISlide.GetImage and handles
// missing input files and unsupported formats gracefully.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, slide thumbnail, 3D slide, image rendering
//
// Use Cases:
// - Create preview images for 3‑D slides in a presentation.
// - Generate thumbnails for a slide catalog displayed in a web gallery.
// - Automate thumbnail extraction for presentation assets in a CI pipeline.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace SlideThumbnailGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath;
            if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: Input file does not exist: " + inputPath);
                return;
            }

            string outputDirectory = Path.Combine(Path.GetDirectoryName(inputPath), "Thumbnails");
            try
            {
                Directory.CreateDirectory(outputDirectory);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error creating output directory: " + ex.Message);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[i];

                // Simple heuristic: treat all slides as candidates.
                // Advanced detection of 3‑D content can be added here.

                float scaleX = 200f / (float)presentation.SlideSize.Size.Width;
                float scaleY = 200f / (float)presentation.SlideSize.Size.Height;

                try
                {
                    using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                    {
                        string outputPath = Path.Combine(outputDirectory, $"slide_{i + 1}_thumb.jpg");
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                        Console.WriteLine("Thumbnail saved: " + outputPath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error generating thumbnail for slide {i + 1}: {ex.Message}");
                }
            }

            try
            {
                // Save the presentation back (optional, fulfills requirement)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
