using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtPictureAccentBlocksExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output presentation file
            string outputPath = "SmartArtPictureAccentBlocks.pptx";

            // Image files to populate SmartArt nodes
            string[] imagePaths = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Verify that each image file exists
            foreach (string imgPath in imagePaths)
            {
                if (!File.Exists(imgPath))
                {
                    Console.WriteLine($"Image file not found: {imgPath}");
                    return;
                }
            }

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a SmartArt diagram (initial layout can be any; we'll change it later)
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0f, 0f, 600f, 400f,
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Change layout to PictureAccentBlocks
            smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.PictureAccentBlocks;

            // Add a node for each image and set its picture fill
            foreach (string imgPath in imagePaths)
            {
                // Load image and add to presentation's image collection
                Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imgPath);
                Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

                // Add a new root node to the SmartArt
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.Nodes.AddNode();

                // Apply picture fill to each shape within the node
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                    shape.FillFormat.PictureFillFormat.Picture.Image = ppImg;
                }
            }

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}