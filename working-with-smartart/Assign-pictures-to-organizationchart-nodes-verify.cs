using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace OrganizationChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to picture files (simulating database retrieval)
            string[] picturePaths = new string[]
            {
                "Images\\CEO.jpg",
                "Images\\Assistant1.jpg",
                "Images\\Assistant2.jpg"
            };

            // Verify that picture files exist
            for (int i = 0; i < picturePaths.Length; i++)
            {
                if (!File.Exists(picturePaths[i]))
                {
                    Console.WriteLine("File not found: " + picturePaths[i]);
                    // In a real scenario you might retrieve the image from a database here
                }
            }

            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Add a Picture Organization Chart SmartArt diagram
                    Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                        0f, 0f, 500f, 400f,
                        Aspose.Slides.SmartArt.SmartArtLayoutType.PictureOrganizationChart);

                    // ----- Root node (CEO) -----
                    Aspose.Slides.SmartArt.ISmartArtNode rootNode = smartArt.Nodes[0];
                    rootNode.TextFrame.Text = "CEO";

                    // Assign picture to root node
                    if (File.Exists(picturePaths[0]))
                    {
                        byte[] imageBytes = File.ReadAllBytes(picturePaths[0]);
                        Aspose.Slides.IPPImage pictureImage = presentation.Images.AddImage(imageBytes);
                        if (rootNode.Shapes.Count > 0 && rootNode.Shapes[0] is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)rootNode.Shapes[0];
                            pictureFrame.PictureFormat.Picture.Image = pictureImage;
                        }
                    }

                    // ----- First child node (Assistant 1) -----
                    Aspose.Slides.SmartArt.ISmartArtNode childNode1 = rootNode.ChildNodes.AddNode();
                    childNode1.TextFrame.Text = "Assistant 1";

                    if (File.Exists(picturePaths[1]))
                    {
                        byte[] imageBytes = File.ReadAllBytes(picturePaths[1]);
                        Aspose.Slides.IPPImage pictureImage = presentation.Images.AddImage(imageBytes);
                        if (childNode1.Shapes.Count > 0 && childNode1.Shapes[0] is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)childNode1.Shapes[0];
                            pictureFrame.PictureFormat.Picture.Image = pictureImage;
                        }
                    }

                    // ----- Second child node (Assistant 2) -----
                    Aspose.Slides.SmartArt.ISmartArtNode childNode2 = rootNode.ChildNodes.AddNode();
                    childNode2.TextFrame.Text = "Assistant 2";

                    if (File.Exists(picturePaths[2]))
                    {
                        byte[] imageBytes = File.ReadAllBytes(picturePaths[2]);
                        Aspose.Slides.IPPImage pictureImage = presentation.Images.AddImage(imageBytes);
                        if (childNode2.Shapes.Count > 0 && childNode2.Shapes[0] is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)childNode2.Shapes[0];
                            pictureFrame.PictureFormat.Picture.Image = pictureImage;
                        }
                    }

                    // ----- Verification -----
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        if (node.Shapes.Count > 0 && node.Shapes[0] is Aspose.Slides.IPictureFrame)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)node.Shapes[0];
                            if (pictureFrame.PictureFormat.Picture.Image != null)
                            {
                                Console.WriteLine("Node '" + node.TextFrame.Text + "' displays its picture correctly.");
                            }
                            else
                            {
                                Console.WriteLine("Node '" + node.TextFrame.Text + "' is missing its picture.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Node '" + node.TextFrame.Text + "' does not contain a picture frame.");
                        }
                    }

                    // Save the presentation
                    presentation.Save("OrganizationChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}