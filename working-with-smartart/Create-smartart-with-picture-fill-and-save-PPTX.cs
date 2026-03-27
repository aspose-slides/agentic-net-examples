using System;
using System.IO;
using Aspose.Slides.Export;

namespace SmartArtPictureFillExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "SmartArtPictureFill.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a SmartArt diagram to the first slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // List of image files to use for picture fill
            string[] imageFiles = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg",
                "image4.jpg"
            };

            // Verify that each image file exists
            for (int i = 0; i < imageFiles.Length; i++)
            {
                if (!File.Exists(imageFiles[i]))
                {
                    Console.WriteLine("Image file not found: " + imageFiles[i]);
                    return;
                }
            }

            // Apply picture fill to each SmartArt node (up to the number of available images)
            int nodeCount = smartArt.AllNodes.Count;
            int fillCount = Math.Min(nodeCount, imageFiles.Length);
            for (int i = 0; i < fillCount; i++)
            {
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[i];
                // Each node contains at least one shape
                Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];
                shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imageFiles[i]);
                Aspose.Slides.IPPImage pptImg = presentation.Images.AddImage(img);
                shape.FillFormat.PictureFillFormat.Picture.Image = pptImg;
                shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}