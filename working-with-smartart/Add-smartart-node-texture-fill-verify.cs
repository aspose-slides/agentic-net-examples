using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtTextureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imagePath = Path.Combine(dataDir, "texture.jpg");
            string outputPath = Path.Combine(dataDir, "SmartArtTexture.pptx");

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Verify that the texture image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Texture image file not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram to the slide
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                    10, 10, 800, 200, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Add a new node to the SmartArt
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
                node.TextFrame.Text = "Node with texture fill";

                // Load the texture image
                Aspose.Slides.IImage textureImage = Aspose.Slides.Images.FromFile(imagePath);
                Aspose.Slides.IPPImage pptImage = presentation.Images.AddImage(textureImage);

                // Apply picture (texture) fill to each shape within the node
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    // Set fill type to picture
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

                    // Assign the image to the picture fill format
                    shape.FillFormat.PictureFillFormat.Picture.Image = pptImage;

                    // Set the picture fill mode to Tile to repeat the texture
                    shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

                    // Optional: set tile alignment (default is TopLeft)
                    shape.FillFormat.PictureFillFormat.TileAlignment = Aspose.Slides.RectangleAlignment.TopLeft;
                }

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}