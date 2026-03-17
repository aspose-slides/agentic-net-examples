using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace OptimizePresentationMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                var sourcePath = "large_presentation.pptx";

                // Load the presentation inside a using block to ensure resources are released promptly
                using (var presentation = new Presentation(sourcePath))
                {
                    // Process each slide individually to keep memory usage low
                    for (var index = 0; index < presentation.Slides.Count; index++)
                    {
                        // Access the current slide
                        var slide = presentation.Slides[index];

                        // Generate a full‑scale image for the slide and dispose it immediately after saving
                        using (var image = slide.GetImage(1f, 1f))
                        {
                            var imagePath = $"slide_{index + 1}.png";
                            image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the (potentially modified) presentation before exiting
                    presentation.Save("optimized_output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Log or handle exceptions as needed
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}