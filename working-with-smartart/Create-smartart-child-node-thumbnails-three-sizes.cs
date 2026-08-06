// -----------------------------------------------------------------------------
// Example: Create SmartArt child node thumbnails in three sizes using C#
//
// Description:
// Demonstrates how to add an Organization Chart SmartArt diagram to a slide,
// create child nodes, and generate PNG thumbnails for each child node at three
// different scales (small, medium, large). The example uses Aspose.Slides for
// .NET to load a presentation, manipulate SmartArt, export shape images, and
// save the modified presentation.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, SmartArt, OrganizationChart,
// ChildNode, Thumbnail, PNG, Scale, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate small, medium, and large thumbnails for SmartArt child nodes.
// - Automate PowerPoint presentation processing and image extraction.
// - Build C# utilities for extracting visual assets from SmartArt diagrams.
// - Integrate SmartArt thumbnail generation into .NET applications.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Load the presentation
        Presentation pres = null;
        try
        {
            pres = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a SmartArt diagram (Organization Chart) to the slide
        ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

        // Ensure there are child nodes – add two sample child nodes
        ISmartArtNode rootNode = smartArt.AllNodes[0];
        ISmartArtNode childNode1 = rootNode.ChildNodes.AddNode();
        ISmartArtNode childNode2 = rootNode.ChildNodes.AddNode();

        // Define output folders for three thumbnail sizes
        string baseOutput = "SmartArtThumbnails";
        string[] sizeFolders = new string[] { "Small", "Medium", "Large" };
        float[] scales = new float[] { 0.5f, 1.0f, 2.0f }; // Scale factors for Small, Medium, Large

        for (int i = 0; i < sizeFolders.Length; i++)
        {
            string folderPath = Path.Combine(baseOutput, sizeFolders[i]);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        // Iterate through each child node and generate thumbnails at three sizes
        for (int nodeIndex = 0; nodeIndex < rootNode.ChildNodes.Count; nodeIndex++)
        {
            ISmartArtNode childNode = rootNode.ChildNodes[nodeIndex];

            // Each node may contain one or more shapes; use the first shape for thumbnail generation
            if (childNode.Shapes.Count == 0)
            {
                continue;
            }

            IShape shape = childNode.Shapes[0];

            for (int sizeIndex = 0; sizeIndex < scales.Length; sizeIndex++)
            {
                float scale = scales[sizeIndex];
                // Generate thumbnail image for the shape
                IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scale, scale);

                // Build the output file name and path
                string fileName = string.Format("Node_{0}_{1}.png", nodeIndex + 1, sizeFolders[sizeIndex]);
                string filePath = Path.Combine(baseOutput, sizeFolders[sizeIndex], fileName);

                // Save the thumbnail as PNG
                shapeImage.Save(filePath, Aspose.Slides.ImageFormat.Png);
            }
        }

        // Save the modified presentation
        try
        {
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported – comment added as required
        }
        finally
        {
            // Ensure resources are released
            pres.Dispose();
        }
    }
}
