using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // List of image URLs to be used in the organization chart
        string[] imageUrls = new string[]
        {
            "https://example.com/image1.png",
            "https://example.com/image2.png",
            "https://example.com/image3.png"
        };

        // Output presentation file
        string outputPath = "PictureOrganizationChart.pptx";

        // Create a new presentation
        Presentation presentation = new Presentation();
        ISlide slide = presentation.Slides[0];

        // Add a Picture Organization Chart SmartArt diagram
        ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, SmartArtLayoutType.PictureOrganizationChart);

        // Ensure there are enough nodes for the images (root node + child nodes)
        for (int i = 0; i < imageUrls.Length - 1; i++)
        {
            // Add child nodes to the root node
            smartArt.Nodes[0].ChildNodes.AddNode();
        }

        // Prepare HTTP client for downloading images
        HttpClient httpClient = new HttpClient();

        // Assign images to each node
        int nodeCount = Math.Min(imageUrls.Length, smartArt.Nodes.Count);
        for (int i = 0; i < nodeCount; i++)
        {
            try
            {
                // Download image data
                byte[] imageBytes = httpClient.GetByteArrayAsync(imageUrls[i]).Result;

                // Add image to the presentation's image collection
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    IPPImage img = presentation.Images.AddImage(ms);

                    // Each node contains a picture shape at index 0
                    ISmartArtNode node = smartArt.Nodes[i];
                    if (node.Shapes.Count > 0 && node.Shapes[0] is ISlidesPicture picture)
                    {
                        picture.Image = img;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle download or image insertion errors
                Console.WriteLine("Error processing image URL: " + imageUrls[i] + " - " + ex.Message);
            }
        }

        // Save the presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other save errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }

        // Clean up resources
        presentation.Dispose();
        httpClient.Dispose();
    }
}