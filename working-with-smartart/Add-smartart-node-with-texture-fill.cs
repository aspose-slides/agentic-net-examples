using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace AddSmartArtNodeWithTextureFill
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file names
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            string texturePath = Path.Combine(dataDir, "texture.jpg");
            if (!File.Exists(texturePath))
            {
                Console.WriteLine("Texture image not found at: " + texturePath);
                return;
            }

            string outputPath = Path.Combine(dataDir, "SmartArtWithTexture.pptx");

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a SmartArt diagram to the first slide
            ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                20, 20, 600, 500, SmartArtLayoutType.BasicBlockList);

            // Add a new node to the SmartArt
            ISmartArtNode newNode = smartArt.AllNodes.AddNode();

            // Access the first shape of the newly added node
            ISmartArtShape nodeShape = newNode.Shapes[0];

            // Set the shape's fill type to picture (texture)
            nodeShape.FillFormat.FillType = FillType.Picture;

            // Load the texture image and add it to the presentation's image collection
            IImage textureImage = Images.FromFile(texturePath);
            IPPImage ppTexture = presentation.Images.AddImage(textureImage);

            // Apply the texture to the shape's picture fill format
            IPictureFillFormat pictureFill = nodeShape.FillFormat.PictureFillFormat;
            pictureFill.Picture.Image = ppTexture;

            // Set the picture fill mode to Tile to repeat the texture
            pictureFill.PictureFillMode = PictureFillMode.Tile;

            // Optional: adjust tile alignment to verify repeat behavior
            pictureFill.TileAlignment = RectangleAlignment.BottomRight;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}