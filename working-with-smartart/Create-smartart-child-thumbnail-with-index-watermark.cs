using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a SmartArt diagram to the slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
            50f, 50f, 400f, 300f,
            Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Add sample child nodes to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode rootNode = smartArt.AllNodes[0];
        Aspose.Slides.SmartArt.ISmartArtNode childNode1 = rootNode.ChildNodes.AddNode();
        Aspose.Slides.SmartArt.ISmartArtNode childNode2 = rootNode.ChildNodes.AddNode();

        // Iterate through all nodes (including root) and generate thumbnails with index watermark
        for (int i = 0; i < smartArt.AllNodes.Count; i++)
        {
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[i];

            // Get the first shape associated with the node
            Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];

            // Render the shape to an Aspose.Slides image
            Aspose.Slides.IImage shapeImage = shape.GetImage();

            // Save the Aspose.Slides image to a memory stream in PNG format
            using (MemoryStream ms = new MemoryStream())
            {
                shapeImage.Save(ms, Aspose.Slides.ImageFormat.Png);
                ms.Position = 0;

                // Load the PNG into a System.Drawing bitmap for watermarking
                using (Bitmap bitmap = new Bitmap(ms))
                {
                    // Draw the index watermark onto the bitmap
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        string watermarkText = (i + 1).ToString();
                        using (Font font = new Font("Arial", 24, FontStyle.Bold, GraphicsUnit.Point))
                        {
                            using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
                            {
                                graphics.DrawString(watermarkText, font, brush, new PointF(10f, 10f));
                            }
                        }
                    }

                    // Save the watermarked thumbnail to disk
                    string outputFile = $"node_{i + 1}.png";
                    bitmap.Save(outputFile, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }

        // Save the presentation before exiting
        pres.Save("SmartArtWithThumbnails.pptx", SaveFormat.Pptx);
    }
}