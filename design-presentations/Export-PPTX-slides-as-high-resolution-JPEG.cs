using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlidesToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path and output directory
            string inputPath = "input.pptx";
            string outputDirectory = "output";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Save the presentation before exiting (preserves any changes)
                    presentation.Save(inputPath, SaveFormat.Pptx);

                    // Export each slide as a high‑resolution JPEG image
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        // Get the slide
                        ISlide slide = presentation.Slides[index];

                        // Create a high‑resolution thumbnail (scale factor 2.0 for both axes)
                        IImage image = slide.GetImage(2f, 2f);

                        // Build the output file path
                        string outputPath = Path.Combine(outputDirectory, $"Slide_{index + 1}.jpg");

                        // Save the image as JPEG using fully‑qualified ImageFormat
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);

                        // Release the image resources
                        image.Dispose();
                    }
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported format scenario here
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}