using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path (first argument or default)
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Handle external URL case
            if (inputPath.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        ExportSlides(presentation);
                        // Saving back to a URL is not applicable; skip saving.
                    }
                }
                catch (System.Net.WebException)
                {
                    // Handle network errors for external URLs
                    Console.WriteLine("Failed to download presentation from URL: " + inputPath);
                }
                return;
            }

            // Verify that the file exists on disk
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    ExportSlides(presentation);
                    // Save the presentation before exiting (overwrites original)
                    presentation.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported: " + inputPath);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static void ExportSlides(Presentation presentation)
        {
            // Iterate through each slide and export as PNG using GetImage inside a using block
            for (int index = 0; index < presentation.Slides.Count; index++)
            {
                ISlide slide = presentation.Slides[index];
                string outputPath = $"slide_{index}.png";
                using (IImage image = slide.GetImage())
                {
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }
        }
    }
}