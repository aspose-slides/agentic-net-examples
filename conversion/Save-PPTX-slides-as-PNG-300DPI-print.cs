using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input file path and output folder as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: SlidesToPng <input-pptx> <output-folder>");
                return;
            }

            string inputPath = args[0];
            string outputFolder = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output folder exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Scale factor to achieve ~300 DPI (default DPI is 96)
                float scaleFactor = 300f / 96f;

                // Export each slide as PNG with the calculated scale
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    using (IImage image = slide.GetImage(scaleFactor, scaleFactor))
                    {
                        string outputFile = Path.Combine(outputFolder, $"slide_{index + 1}.png");
                        image.Save(outputFile, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation before exiting (as a copy)
                string savedPresentationPath = Path.Combine(outputFolder, "presentation_copy.pptx");
                presentation.Save(savedPresentationPath, SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}