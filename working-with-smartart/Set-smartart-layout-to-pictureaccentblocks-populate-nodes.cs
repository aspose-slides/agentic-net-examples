using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "SmartArtPictureAccentBlocks.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add SmartArt with a temporary layout and then set to PictureAccentBlocks
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
        smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.PictureAccentBlocks;

        // Image file paths to populate nodes
        string[] imagePaths = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };

        // Add a node for each image and set the picture fill
        for (int i = 0; i < imagePaths.Length; i++)
        {
            string imgPath = imagePaths[i];
            if (!File.Exists(imgPath))
            {
                Console.WriteLine("Image file not found: " + imgPath);
                continue;
            }

            try
            {
                // Add a new node to the SmartArt
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();

                // Load the image and add it to the presentation's image collection
                Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imgPath);
                Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

                // Apply picture fill to each shape within the node
                foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
                {
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                    Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                    picFill.Picture.Image = ppImg;
                    picFill.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing image " + imgPath + ": " + ex.Message);
            }
        }

        // Save the presentation
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Dispose the presentation
        pres.Dispose();
    }
}