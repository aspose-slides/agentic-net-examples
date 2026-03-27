using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace ThumbnailSmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Assume the first slide contains a SmartArt diagram
            ISlide sourceSlide = pres.Slides[0];
            ISmartArt smartArt = sourceSlide.Shapes.AddSmartArt(20, 20, 400, 300, SmartArtLayoutType.BasicBlockList);

            // Create a summary slide to hold thumbnails
            ISlide summarySlide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.TitleOnly));

            // Positioning variables for thumbnails
            float startX = 10f;
            float startY = 10f;
            float offsetX = 110f; // space between thumbnails
            int nodeIndex = 0;

            // Iterate through all SmartArt nodes
            foreach (ISmartArtNode node in smartArt.AllNodes)
            {
                // Get the first shape of the node (assumed to be the visual representation)
                IShape nodeShape = node.Shapes[0];

                // Calculate scaling factors to obtain a 100x100 pixel thumbnail
                float scaleX = 100f / nodeShape.Width;
                float scaleY = 100f / nodeShape.Height;

                // Generate the thumbnail image for the shape
                IImage shapeImage = nodeShape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);

                // Add the image to the presentation's image collection
                IPPImage ppImage = pres.Images.AddImage(shapeImage);

                // Add the thumbnail to the summary slide as a picture frame
                summarySlide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    startX + nodeIndex * offsetX,
                    startY,
                    100f,
                    100f,
                    ppImage);

                // Clean up the temporary image
                shapeImage.Dispose();

                nodeIndex++;
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}