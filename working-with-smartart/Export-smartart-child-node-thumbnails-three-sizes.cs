using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtThumbnailGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Output base directory for thumbnails
            string outputBaseDir = "Thumbnails";

            // Define subdirectories for each size
            string smallDir = Path.Combine(outputBaseDir, "Small");
            string mediumDir = Path.Combine(outputBaseDir, "Medium");
            string largeDir = Path.Combine(outputBaseDir, "Large");

            // Ensure output directories exist
            Directory.CreateDirectory(smallDir);
            Directory.CreateDirectory(mediumDir);
            Directory.CreateDirectory(largeDir);

            // Scaling factors for the three sizes
            float smallScale = 0.5f;
            float mediumScale = 1.0f;
            float largeScale = 2.0f;

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Find SmartArt shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Check if the shape is a SmartArt diagram
                            if (slide.Shapes[shapeIndex] is SmartArt smartArt)
                            {
                                // Iterate through all top‑level nodes of the SmartArt
                                for (int nodeIndex = 0; nodeIndex < smartArt.AllNodes.Count; nodeIndex++)
                                {
                                    ISmartArtNode node = smartArt.AllNodes[nodeIndex];

                                    // Each node may contain one or more shapes; use the first shape for the thumbnail
                                    if (node.Shapes.Count > 0)
                                    {
                                        ISmartArtShape nodeShape = node.Shapes[0];

                                        // Generate and save thumbnails at three sizes
                                        GenerateAndSaveThumbnail(nodeShape, smallScale, smallDir, slideIndex, nodeIndex);
                                        GenerateAndSaveThumbnail(nodeShape, mediumScale, mediumDir, slideIndex, nodeIndex);
                                        GenerateAndSaveThumbnail(nodeShape, largeScale, largeDir, slideIndex, nodeIndex);
                                    }
                                }
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    string presOutputPath = "output.pptx";
                    pres.Save(presOutputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Helper method to generate a thumbnail for a SmartArt shape and save it
        private static void GenerateAndSaveThumbnail(ISmartArtShape shape, float scale, string outputDir, int slideIdx, int nodeIdx)
        {
            // Obtain the thumbnail image using the shape's GetImage method
            IImage thumbnail = shape.GetImage(ShapeThumbnailBounds.Shape, scale, scale);

            // Build a filename that identifies the slide and node
            string fileName = $"slide{slideIdx + 1}_node{nodeIdx + 1}_{scale}x.png";
            string outputPath = Path.Combine(outputDir, fileName);

            // Save the image in PNG format
            thumbnail.Save(outputPath, Aspose.Slides.ImageFormat.Png);
        }
    }
}