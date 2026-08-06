// -----------------------------------------------------------------------------
// Example: Assign URL pictures to org chart nodes using C#
//
// Description:
// Demonstrates how to assign external image URLs to nodes of a Picture
// Organization Chart SmartArt using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a Picture Organization Chart SmartArt, and
// sets each node's picture shape to reference an online image via its URL.
// The resulting PPTX file can be opened in PowerPoint where the images are
// loaded from the specified URLs.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Assign, Pictures, SmartArt, 
// Organization Chart, URL, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate assigning URL pictures to organization chart nodes.
// - Build C# utilities for PowerPoint presentation processing.
// - Generate or transform PPTX files with dynamic image content in .NET.
// - Validate presentation workflows that rely on external image resources.
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace PictureOrganizationChartExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a Picture Organization Chart SmartArt
            ISmartArt smartArt = slide.Shapes.AddSmartArt(
                50, 50, 600, 400,
                SmartArtLayoutType.PictureOrganizationChart);

            // List of image URLs to assign to nodes
            List<string> imageUrls = new List<string>
            {
                "https://example.com/image1.png",
                "https://example.com/image2.png",
                "https://example.com/image3.png",
                "https://example.com/image4.png"
            };

            // Assign each URL to the corresponding node's picture shape
            for (int i = 0; i < smartArt.Nodes.Count && i < imageUrls.Count; i++)
            {
                try
                {
                    ISmartArtNode node = smartArt.Nodes[i];
                    // The picture shape is typically the first shape in the node
                    IPictureFrame pictureShape = (IPictureFrame)node.Shapes[0];
                    pictureShape.LinkPathLong = imageUrls[i];
                }
                catch (Exception ex)
                {
                    // Handle any errors related to setting the online image
                    Console.WriteLine($"Failed to assign image to node {i}: {ex.Message}");
                }
            }

            // Save the presentation
            string outputPath = "PictureOrganizationChart.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}
