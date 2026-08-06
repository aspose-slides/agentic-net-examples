// -----------------------------------------------------------------------------
// Example: Insert picture org chart into new slide using C#
//
// Description:
// Demonstrates how to create a new presentation, add a Picture Organization
// Chart SmartArt diagram, load image files from a specified folder, assign
// those images to the SmartArt nodes, and save the result as a PPTX file using
// Aspose.Slides for .NET. The example shows the required presentation‑processing
// steps for PowerPoint files and produces the requested output in a standalone
// console application. Developers can use this pattern to automate PPTX
// workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Picture, SmartArt,
// Organization Chart, Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of picture organization chart into a new slide.
// - Build C# tools for PowerPoint presentation processing with image assets.
// - Generate or transform PPTX files in .NET applications using SmartArt.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace PictureOrgChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the folder containing pictures
            string imagesFolder = @"C:\Images";

            // Verify that the folder exists
            if (!Directory.Exists(imagesFolder))
            {
                Console.WriteLine("The specified images folder does not exist: " + imagesFolder);
                return;
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add a new blank slide
                ISlide slide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

                // Add a Picture Organization Chart SmartArt diagram
                ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 600, 400, SmartArtLayoutType.PictureOrganizationChart);

                // Get the root nodes collection
                ISmartArtNodeCollection rootNodes = smartArt.AllNodes;

                // Get image files from the folder (limit to first 5 for demo)
                string[] imageFiles = Directory.GetFiles(imagesFolder);
                int nodeIndex = 0;

                foreach (string imagePath in imageFiles)
                {
                    if (nodeIndex >= rootNodes.Count)
                        break; // No more nodes to assign images

                    // Load image into presentation's image collection
                    IPPImage pictureImage;
                    try
                    {
                        using (FileStream imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                        {
                            pictureImage = presentation.Images.AddImage(imgStream, LoadingStreamBehavior.KeepLocked);
                        }
                    }
                    catch (Exception ex) when (ex is NotSupportedException)
                    {
                        // Format not supported – skip this file
                        Console.WriteLine("Unsupported image format: " + imagePath);
                        continue;
                    }

                    // Get the current node
                    ISmartArtNode node = rootNodes[nodeIndex];

                    // Each node contains a shape placeholder for the picture.
                    // Assign the loaded image to the first shape of the node.
                    if (node.Shapes.Count > 0)
                    {
                        // The shape is a picture placeholder; set its image.
                        // Cast to IPictureFrame to access the Image property.
                        Aspose.Slides.IPictureFrame pictureFrame = node.Shapes[0] as Aspose.Slides.IPictureFrame;
                        if (pictureFrame != null)
                        {
                            pictureFrame.PictureFormat.Picture.Image = pictureImage;
                        }
                    }

                    nodeIndex++;
                }

                // Save the presentation
                try
                {
                    presentation.Save("PictureOrgChart.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex) when (ex is NotSupportedException)
                {
                    // Format not supported – comment for clarity
                    // Save format not supported
                }
            }
        }
    }
}
