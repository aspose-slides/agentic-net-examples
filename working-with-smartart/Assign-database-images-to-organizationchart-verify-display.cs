using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace PictureOrganizationChart
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the folder containing images (simulating a database)
            string imagesFolder = "Images";
            // Verify the folder exists
            if (!Directory.Exists(imagesFolder))
            {
                Console.WriteLine("Images folder does not exist: " + imagesFolder);
                return;
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an Organization Chart SmartArt diagram
                ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, SmartArtLayoutType.OrganizationChart);

                // Example: add three root nodes (you can adjust as needed)
                ISmartArtNode rootNode1 = smartArt.Nodes.AddNode();
                rootNode1.TextFrame.Text = "CEO";
                ISmartArtNode rootNode2 = smartArt.Nodes.AddNode();
                rootNode2.TextFrame.Text = "CTO";
                ISmartArtNode rootNode3 = smartArt.Nodes.AddNode();
                rootNode3.TextFrame.Text = "CFO";

                // Collect all nodes to assign images
                ISmartArtNodeCollection allNodes = smartArt.AllNodes;

                // Iterate over each node and assign an image
                for (int i = 0; i < allNodes.Count; i++)
                {
                    ISmartArtNode node = allNodes[i];

                    // Determine image file name (e.g., "image0.png", "image1.png", ...)
                    string imagePath = Path.Combine(imagesFolder, $"image{i}.png");

                    // Verify the image file exists
                    if (!File.Exists(imagePath))
                    {
                        Console.WriteLine("Image file not found: " + imagePath);
                        continue;
                    }

                    // Load image bytes
                    byte[] imageBytes = File.ReadAllBytes(imagePath);

                    // Add image to the presentation and obtain an IPPImage reference
                    IPPImage ippImage = presentation.Images.AddImage(imageBytes);

                    // Each SmartArt node has at least one shape; get the first shape
                    if (node.Shapes.Count > 0)
                    {
                        ISmartArtShape smartArtShape = node.Shapes[0];

                        // Assign the image to the shape's picture fill
                        smartArtShape.FillFormat.PictureFillFormat.Picture.Image = ippImage;

                        // Verify assignment (simple check)
                        if (smartArtShape.FillFormat.PictureFillFormat.Picture.Image != null)
                        {
                            Console.WriteLine($"Image assigned to node \"{node.TextFrame.Text}\" successfully.");
                        }
                    }
                }

                // Save the presentation
                string outputPath = "PictureOrganizationChart.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
        }
    }
}