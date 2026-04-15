using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the texture image file
            string texturePath = "texture.png";

            // Verify that the texture image exists
            if (!File.Exists(texturePath))
            {
                Console.WriteLine("Texture image file not found: " + texturePath);
                return;
            }

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    50f, 50f, 400f, 300f, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Add a new node to the SmartArt
                Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.Nodes.AddNode();

                // Load the texture image into the presentation
                byte[] textureBytes = File.ReadAllBytes(texturePath);
                Aspose.Slides.IPPImage textureImage = presentation.Images.AddImage(textureBytes);

                // Get the shape associated with the newly added node (first shape in the node)
                Aspose.Slides.SmartArt.ISmartArtShape nodeShape = newNode.Shapes[0];

                // Set the picture fill mode to Tile (repeat)
                nodeShape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

                // Assign the texture image to the shape's picture fill
                nodeShape.FillFormat.PictureFillFormat.Picture.Image = textureImage;

                // Optionally set tile alignment to verify repeat behavior (default is TopLeft)
                nodeShape.FillFormat.PictureFillFormat.TileAlignment = Aspose.Slides.RectangleAlignment.TopLeft;

                // Verify that the fill mode and tile alignment are set correctly
                if (nodeShape.FillFormat.PictureFillFormat.PictureFillMode == Aspose.Slides.PictureFillMode.Tile &&
                    nodeShape.FillFormat.PictureFillFormat.TileAlignment == Aspose.Slides.RectangleAlignment.TopLeft)
                {
                    Console.WriteLine("Texture fill applied with tiling enabled.");
                }

                // Save the presentation
                try
                {
                    presentation.Save("SmartArtTexture.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}