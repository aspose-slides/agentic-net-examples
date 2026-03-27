using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace GenerateSmartArtThumbnails
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Add a SmartArt diagram to the first slide
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
            Aspose.Slides.SmartArt.ISmartArt smartArt = firstSlide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Example modifications to some nodes (using the provided rule)
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[1];
            Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];
            shape.X += (shape.Width * 2);
            shape.Y -= (shape.Height / 2);
            node = smartArt.AllNodes[2];
            shape = node.Shapes[0];
            shape.Width += (shape.Width / 2);
            node = smartArt.AllNodes[3];
            shape = node.Shapes[0];
            shape.Height += (shape.Height / 2);
            node = smartArt.AllNodes[4];
            shape = node.Shapes[0];
            shape.Rotation = 90;

            // Create a summary slide to hold thumbnails
            Aspose.Slides.ISlide summarySlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

            // Layout parameters for thumbnails
            int thumbnailsPerRow = 5;
            float thumbnailWidth = 100f;
            float thumbnailHeight = 100f;
            float margin = 20f;

            // Iterate through all SmartArt nodes and generate thumbnails
            int nodeCount = smartArt.AllNodes.Count;
            for (int i = 0; i < nodeCount; i++)
            {
                Aspose.Slides.SmartArt.ISmartArtNode currentNode = smartArt.AllNodes[i];
                // Use the first shape of the node for thumbnail generation
                Aspose.Slides.SmartArt.ISmartArtShape nodeShape = currentNode.Shapes[0];

                // Calculate scaling factors to achieve 100x100 pixel thumbnails
                float scaleX = thumbnailWidth / nodeShape.Width;
                float scaleY = thumbnailHeight / nodeShape.Height;

                // Generate the thumbnail image
                Aspose.Slides.IImage thumbnailImage = nodeShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);

                // Save thumbnail to a memory stream
                using (MemoryStream imageStream = new MemoryStream())
                {
                    thumbnailImage.Save(imageStream, Aspose.Slides.ImageFormat.Png);
                    imageStream.Position = 0;

                    // Add the image to the presentation's image collection
                    Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);

                    // Calculate position on the summary slide
                    int row = i / thumbnailsPerRow;
                    int column = i % thumbnailsPerRow;
                    float posX = margin + column * (thumbnailWidth + margin);
                    float posY = margin + row * (thumbnailHeight + margin);

                    // Insert the thumbnail as a picture frame
                    summarySlide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, posX, posY, thumbnailWidth, thumbnailHeight, ppImage);
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}