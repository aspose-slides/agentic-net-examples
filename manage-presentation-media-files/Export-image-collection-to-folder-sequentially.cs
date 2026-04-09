using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportImagesFromPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found: " + inputPath);
                return;
            }

            // Define output directory for extracted images
            string outputDir = Path.Combine(Environment.CurrentDirectory, "ExportedImages");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Access the image collection
                    IImageCollection imageCollection = pres.Images;

                    // Export each image with sequential naming
                    for (int i = 0; i < imageCollection.Count; i++)
                    {
                        try
                        {
                            IPPImage img = imageCollection[i];
                            string outPath = Path.Combine(outputDir, $"image_{i + 1}.png");
                            // Save the image in PNG format
                            img.Image.Save(outPath, Aspose.Slides.ImageFormat.Png);
                        }
                        catch (NotSupportedException)
                        {
                            // Format not supported for this image; continue with next
                            Console.WriteLine($"Image {i + 1} format not supported.");
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}