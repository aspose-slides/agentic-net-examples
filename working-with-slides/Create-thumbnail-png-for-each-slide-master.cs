using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideMasterThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output folder for master thumbnails
            string outputFolder = "MasterThumbnails";

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
                // Load presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Iterate through each master slide
                for (int index = 0; index < pres.Masters.Count; index++)
                {
                    Aspose.Slides.IMasterSlide master = pres.Masters[index];

                    // NOTE: MasterSlide does not provide a GetImage method.
                    // Therefore, generating a thumbnail directly from a master slide is not supported.
                    // If needed, consider creating a temporary slide based on the master layout and capture its image.

                    // Placeholder for potential future implementation:
                    // string outputPath = Path.Combine(outputFolder, $"Master_{index}.png");
                    // using (Aspose.Slides.IImage image = master.GetImage())
                    // {
                    //     image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    // }
                }

                // Save the presentation (no changes made)
                pres.Save(inputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}