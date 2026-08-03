// -----------------------------------------------------------------------------
// Example: Insert network stream image into picture frame using C#
//
// Description:
// Demonstrates how to insert a network stream image into a picture frame using
// C# and Aspose.Slides for .NET. The example shows the required presentation-
// processing steps for PowerPoint files and produces the requested output in a
// standalone console application. Developers can use this pattern to automate
// PPTX workflows, validate results, or integrate presentation logic into .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Network, Stream, Image,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of a network stream image into a picture frame.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Net;
using System.IO;
using Aspose.Slides.Export;

namespace InsertNetworkImage
{
    class Program
    {
        static void Main(string[] args)
        {
            // URL of the image to download
            string imageUrl = "https://example.com/image.jpg";
            // Output presentation file path
            string outputPath = "NetworkImagePresentation.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Stream to hold the downloaded image
            Stream imageStream = null;
            try
            {
                // Download image as a stream
                WebClient client = new WebClient();
                imageStream = client.OpenRead(imageUrl);

                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                // Insert the image into a picture frame on the first slide
                presentation.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50, 50, 400, 300,
                    image);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (WebException webEx)
            {
                // Handle network-related errors
                Console.WriteLine("Failed to download image: " + webEx.Message);
            }
            catch (Exception ex)
            {
                // Handle other errors (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Clean up resources
                if (imageStream != null)
                {
                    imageStream.Dispose();
                }
                presentation.Dispose();
            }
        }
    }
}
