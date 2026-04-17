using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Directory containing images
        string dataDir = "SmartArtImages";
        if (!Directory.Exists(dataDir))
        {
            Console.WriteLine("Directory does not exist: " + dataDir);
            return;
        }

        string[] imageFiles = Directory.GetFiles(dataDir);
        if (imageFiles.Length == 0)
        {
            Console.WriteLine("No images found in directory.");
            return;
        }

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];

            // Add SmartArt with PictureAccentBlocks layout
            ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureAccentBlocks);
            smartArt.Layout = SmartArtLayoutType.PictureAccentBlocks;

            // Populate SmartArt nodes with images
            foreach (string imgPath in imageFiles)
            {
                // Add a new node to the SmartArt
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.Nodes.AddNode();

                // Load image and add to presentation
                IImage img = Images.FromFile(imgPath);
                IPPImage ppImg = pres.Images.AddImage(img);

                // Apply picture fill to the first shape of the node
                if (node.Shapes.Count > 0)
                {
                    IShape shape = node.Shapes[0];
                    shape.FillFormat.FillType = FillType.Picture;
                    IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                    picFill.Picture.Image = ppImg;
                    picFill.PictureFillMode = PictureFillMode.Stretch;
                }
            }

            // Save the presentation
            string outPath = Path.Combine(dataDir, "SmartArtPictureAccentBlocks.pptx");
            pres.Save(outPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported formats
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}