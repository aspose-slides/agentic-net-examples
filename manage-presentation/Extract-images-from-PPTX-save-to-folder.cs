// -----------------------------------------------------------------------------
// Example: Extract images from PPTX and save to folder using C#
//
// Description:
// Demonstrates how to extract all embedded images from a PPTX file and save
// them as PNG files into a specified folder using C# and Aspose.Slides for .NET.
// The example loads a presentation, iterates through its image collection,
// writes each image to disk, and handles basic error conditions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract Images, Save Images, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of images from PowerPoint presentations.
// - Build tools that archive or analyze PPTX embedded media.
// - Integrate image extraction into .NET workflows or services.
// - Validate and preprocess presentation assets before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractImagesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation
            string inputPath = "input.pptx";
            // Folder where extracted images will be saved
            string outputDir = "ExtractedImages";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all embedded images
                    int imageCount = pres.Images.Count;
                    for (int i = 0; i < imageCount; i++)
                    {
                        // Get the embedded image
                        IPPImage embeddedImage = pres.Images[i];

                        // Define output file path
                        string outPath = Path.Combine(outputDir, $"image_{i}.png");

                        // Save the image using the IImage wrapper
                        using (IImage iImg = embeddedImage.Image)
                        {
                            iImg.Save(outPath, ImageFormat.Png);
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
