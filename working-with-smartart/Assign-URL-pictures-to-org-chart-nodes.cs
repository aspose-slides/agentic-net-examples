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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a Picture Organization Chart SmartArt
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                50, 50, 600, 400,
                Aspose.Slides.SmartArt.SmartArtLayoutType.PictureOrganizationChart);

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
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.Nodes[i];
                    // The picture shape is typically the first shape in the node
                    Aspose.Slides.ISlidesPicture pictureShape = (Aspose.Slides.ISlidesPicture)node.Shapes[0];
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
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}