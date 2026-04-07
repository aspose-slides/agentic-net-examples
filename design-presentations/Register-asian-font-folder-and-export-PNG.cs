using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output folder for PNG images
            string outputFolder = "output_images";
            // Folder containing Asian typefaces
            string fontFolder = "AsianFonts";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Register external font folder before loading the presentation
                Aspose.Slides.FontsLoader.LoadExternalFonts(new string[] { fontFolder });

                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Export each slide as high‑resolution PNG
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    string slideImagePath = Path.Combine(outputFolder, $"slide_{i + 1}.png");
                    // GetImage with scaling factors for high resolution (e.g., 2x)
                    Aspose.Slides.IImage slideImage = presentation.Slides[i].GetImage(2f, 2f);
                    slideImage.Save(slideImagePath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the presentation before exiting (optional, can overwrite original)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
                Aspose.Slides.FontsLoader.ClearCache();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}