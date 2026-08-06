// -----------------------------------------------------------------------------
// Example: Apply picture fill to smartart node using C#
//
// Description:
// Demonstrates how to apply a picture fill to a SmartArt node using C# and
// Aspose.Slides for .NET. The example creates a presentation, adds a SmartArt
// diagram, retrieves an image from a web service, and sets the image as the
// fill for the first shape within the first SmartArt node. The resulting
// presentation is saved as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Picture Fill, Image,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying picture fills to SmartArt nodes in PowerPoint files.
// - Build .NET tools for dynamic presentation styling.
// - Integrate external images into SmartArt diagrams programmatically.
// - Validate and test SmartArt formatting workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace ApplyPictureFillToSmartArtNode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a SmartArt diagram to the first slide
            ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);

            // Get the first node of the SmartArt
            ISmartArtNode firstNode = smartArt.Nodes[0];

            // Ensure the node has at least one shape
            if (firstNode.Shapes.Count == 0)
            {
                Console.WriteLine("The SmartArt node does not contain any shapes.");
                presentation.Save("output.pptx", SaveFormat.Pptx);
                return;
            }

            // Get the first shape within the node
            ISmartArtShape shape = firstNode.Shapes[0];

            // Retrieve an image from an external web service
            byte[] imageBytes = null;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    // Example URL – replace with a valid image URL
                    string imageUrl = "https://example.com/sample-image.jpg";
                    HttpResponseMessage response = httpClient.GetAsync(imageUrl).Result;
                    response.EnsureSuccessStatusCode();
                    imageBytes = response.Content.ReadAsByteArrayAsync().Result;
                }
            }
            catch (HttpRequestException)
            {
                // Handle errors related to the external request
                Console.WriteLine("Failed to retrieve the image from the web service.");
                presentation.Save("output.pptx", SaveFormat.Pptx);
                return;
            }

            // Add the image to the presentation's image collection
            IPPImage ippImage = presentation.Images.AddImage(imageBytes);

            // Apply picture fill to the SmartArt shape
            shape.FillFormat.PictureFillFormat.Picture.Image = ippImage;

            // Save the presentation
            try
            {
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex) when (ex is NotSupportedException || ex is ArgumentException)
            {
                // Format not supported or other save-related issue
                // Comment: format not supported.
                Console.WriteLine("Failed to save the presentation: " + ex.Message);
            }
        }
    }
}
