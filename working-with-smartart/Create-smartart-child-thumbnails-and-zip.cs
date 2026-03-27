using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path
        string inputPath = "input.pptx";
        // Output presentation path (saved after processing)
        string outputPath = "output.pptx";
        // Path for the zip archive that will contain thumbnails
        string zipPath = "thumbnails.zip";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        // Load the presentation
        using (Presentation pres = new Presentation(inputPath))
        {
            // Assume the SmartArt diagram is on the first slide
            ISlide slide = pres.Slides[0];

            // Locate the first SmartArt shape on the slide
            ISmartArt smartArt = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is ISmartArt)
                {
                    smartArt = (ISmartArt)shape;
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt diagram found on the first slide.");
                // Save the (unchanged) presentation before exiting
                pres.Save(outputPath, SaveFormat.Pptx);
                return;
            }

            // Desired thumbnail dimensions
            int desiredWidth = 200;
            int desiredHeight = 200;

            // Create a zip archive to store the thumbnails
            using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Update))
            {
                int nodeIndex = 0;
                // Iterate through all child nodes of the SmartArt diagram
                foreach (ISmartArtNode node in smartArt.AllNodes)
                {
                    // Each node may contain shapes; use the first shape for the thumbnail
                    if (node.Shapes.Count == 0)
                        continue;

                    IShape nodeShape = node.Shapes[0];

                    // Calculate scaling factors based on the desired thumbnail size
                    float scaleX = (float)desiredWidth / nodeShape.Width;
                    float scaleY = (float)desiredHeight / nodeShape.Height;

                    // Generate the thumbnail using the overload that requires bounds and both scales
                    IImage thumbnail = nodeShape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);

                    // Add the thumbnail to the zip archive
                    string entryName = $"node_{nodeIndex}.png";
                    ZipArchiveEntry entry = archive.CreateEntry(entryName);
                    using (Stream entryStream = entry.Open())
                    {
                        thumbnail.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                    }

                    nodeIndex++;
                }
            }

            // Save the presentation before exiting
            pres.Save(outputPath, SaveFormat.Pptx);
        }
    }
}