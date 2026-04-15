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

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // List of image files to use for picture fill
            string[] imageFiles = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg",
                "image4.jpg"
            };

            // Apply picture fill to each node
            for (int i = 0; i < imageFiles.Length; i++)
            {
                // Check if image file exists
                if (!File.Exists(imageFiles[i]))
                {
                    Console.WriteLine("Image file not found: " + imageFiles[i]);
                    continue;
                }

                // Ensure the node index is within the SmartArt node collection
                if (i >= smartArt.AllNodes.Count)
                {
                    break;
                }

                // Get the node
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[i];

                // Ensure the node has at least one shape
                if (node.Shapes.Count == 0)
                {
                    continue;
                }

                // Get the first shape of the node
                Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];

                // Set picture fill for the shape
                shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imageFiles[i]);
                Aspose.Slides.IPPImage ppImg = presentation.Images.AddImage(img);
                shape.FillFormat.PictureFillFormat.Picture.Image = ppImg;
                shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}