using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace OrgChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add an organization chart SmartArt diagram
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.OrganizationChart);

                // Simulated database: node name -> image file path
                Dictionary<string, string> imageDatabase = new Dictionary<string, string>()
                {
                    { "CEO", "ceo.png" },
                    { "CTO", "cto.png" },
                    { "CFO", "cfo.png" }
                };

                // Iterate through all nodes in the SmartArt
                foreach (ISmartArtNode node in smartArt.AllNodes)
                {
                    // Use the node's text as the key to fetch the image path
                    string nodeName = node.TextFrame.Text.Trim();

                    if (imageDatabase.ContainsKey(nodeName))
                    {
                        string imagePath = imageDatabase[nodeName];

                        // Verify that the image file exists
                        if (File.Exists(imagePath))
                        {
                            try
                            {
                                // Load image bytes and add to presentation's image collection
                                byte[] imageData = File.ReadAllBytes(imagePath);
                                IPPImage ippImage = pres.Images.AddImage(imageData);

                                // Assign the image to the first shape of the node
                                if (node.Shapes.Count > 0)
                                {
                                    ISmartArtShape shape = node.Shapes[0];
                                    // Ensure FillFormat and PictureFillFormat are available
                                    if (shape.FillFormat != null && shape.FillFormat.PictureFillFormat != null && shape.FillFormat.PictureFillFormat.Picture != null)
                                    {
                                        shape.FillFormat.PictureFillFormat.Picture.Image = ippImage;
                                        Console.WriteLine($"Assigned image to node '{nodeName}'.");
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Handle any errors related to image loading or assignment
                                Console.WriteLine($"Error processing image for node '{nodeName}': {ex.Message}");
                            }
                        }
                        else
                        {
                            // Image file not found
                            Console.WriteLine($"Image file not found for node '{nodeName}': {imagePath}");
                        }
                    }
                }

                // Verify that each node's shape has an image assigned
                foreach (ISmartArtNode node in smartArt.AllNodes)
                {
                    if (node.Shapes.Count > 0)
                    {
                        ISmartArtShape shape = node.Shapes[0];
                        bool hasImage = shape.FillFormat != null &&
                                        shape.FillFormat.PictureFillFormat != null &&
                                        shape.FillFormat.PictureFillFormat.Picture != null &&
                                        shape.FillFormat.PictureFillFormat.Picture.Image != null;

                        Console.WriteLine($"Node '{node.TextFrame.Text.Trim()}' image assigned: {hasImage}");
                    }
                }

                // Save the presentation
                try
                {
                    pres.Save("OrgChart.pptx", SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved as OrgChart.pptx");
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine($"Failed to save presentation: {ex.Message}");
                }
            }
        }
    }
}