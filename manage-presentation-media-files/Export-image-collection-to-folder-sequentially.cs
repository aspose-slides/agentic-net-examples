// -----------------------------------------------------------------------------
// Example: Export image collection to folder sequentially using C#
//
// Description:
// Demonstrates how to extract all images from a PowerPoint presentation and
// save them sequentially to a specified folder using Aspose.Slides for .NET.
// The example loads a PPTX file, iterates through its image collection, and
// writes each image as a PNG file with a numeric suffix. This pattern is
// useful for batch image extraction, content analysis, or migration of media
// assets from presentations.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, Export Images, Image Collection,
// Folder Export, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of embedded images from PPTX files.
// - Build tools that archive or analyze presentation media assets.
// - Integrate image export functionality into .NET applications.
// - Prepare presentation resources for reuse in other media or web contexts.
// -----------------------------------------------------------------------------

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
