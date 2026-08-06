// -----------------------------------------------------------------------------
// Example: Apply pictureaccentblocks layout fill nodes from folder using C#
//
// Description:
// Demonstrates how to apply the PictureAccentBlocks SmartArt layout and fill its
// nodes with images loaded from a folder using C# and Aspose.Slides for .NET.
// The example creates a new presentation, adds a SmartArt diagram, changes its
// layout to PictureAccentBlocks, populates each node with picture fills from
// image files in the Data folder, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, PictureAccentBlocks,
// Layout, Fill, SmartArt, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying PictureAccentBlocks layout and filling nodes with images.
// - Build C# tools for PowerPoint SmartArt processing and customization.
// - Generate or transform PPTX files with image-filled SmartArt in .NET apps.
// - Validate SmartArt workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtPictureAccentBlocksExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define data directory and ensure it exists
                string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                if (!Directory.Exists(dataDir))
                    Directory.CreateDirectory(dataDir);

                // Define output file path
                string outputPath = Path.Combine(dataDir, "SmartArtPictureAccentBlocks.pptx");

                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a SmartArt diagram with a basic layout
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                // Change the layout to PictureAccentBlocks
                smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.PictureAccentBlocks;

                // Load image files from the data directory (supports common image formats)
                string[] imageFiles = Directory.GetFiles(dataDir);
                int nodeIndex = 0;

                foreach (string imgPath in imageFiles)
                {
                    // Stop if there are no more nodes to populate
                    if (nodeIndex >= smartArt.Nodes.Count)
                        break;

                    // Load image and add it to the presentation's image collection
                    IImage img = Aspose.Slides.Images.FromFile(imgPath);
                    IPPImage ppImg = pres.Images.AddImage(img);

                    // Get the corresponding SmartArt node
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.Nodes[nodeIndex];

                    // Each node may contain one or more shapes; use the first shape
                    if (node.Shapes.Count > 0)
                    {
                        Aspose.Slides.IShape shape = node.Shapes[0];

                        // Set picture fill for the shape
                        shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                        shape.FillFormat.PictureFillFormat.Picture.Image = ppImg;
                    }

                    nodeIndex++;
                }

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, missing files, etc.)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
