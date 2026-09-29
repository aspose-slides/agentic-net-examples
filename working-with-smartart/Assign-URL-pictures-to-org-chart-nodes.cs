// -----------------------------------------------------------------------------
// Example: Assign URL Images to Picture Organization Chart SmartArt Nodes using C#
// 
// Description:
// This console application creates a new PowerPoint presentation, adds a
// Picture Organization Chart SmartArt, downloads images from external URLs,
// and assigns each image to the corresponding SmartArt node's picture shape.
// The resulting PPTX can be opened in PowerPoint where the nodes display the
// downloaded images.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Picture Organization Chart, SmartArt, URL images
// 
// Use Cases:
// - Automatically generate org charts with employee photos sourced from a web service.
// - Populate presentation templates with dynamic images retrieved from online sources.
// - Build marketing decks where product images are fetched from CDN URLs.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsposeSlidesOrgChartUrlImages
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Define output directory and file
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }
            string outputPath = Path.Combine(outputDirectory, "OrgChartWithUrlImages.pptx");

            // URLs of images to assign to nodes (replace with real URLs)
            string[] imageUrls = new string[]
            {
                "https://example.com/images/person1.jpg",
                "https://example.com/images/person2.jpg",
                "https://example.com/images/person3.jpg",
                "https://example.com/images/person4.jpg"
            };

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add Picture Organization Chart SmartArt
            Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                20, 20, 600, 500,
                Aspose.Slides.SmartArt.SmartArtLayoutType.PictureOrganizationChart);

            // HttpClient for downloading images
            HttpClient httpClient = new HttpClient();

            // Assign images to each node
            int nodeCount = smartArt.AllNodes.Count;
            int assignCount = Math.Min(nodeCount, imageUrls.Length);

            for (int i = 0; i < assignCount; i++)
            {
                string url = imageUrls[i];
                try
                {
                    byte[] imageData = await httpClient.GetByteArrayAsync(url);
                    using (MemoryStream memoryStream = new MemoryStream(imageData))
                    {
                        Aspose.Slides.IImage slideImage = Aspose.Slides.Images.FromStream(memoryStream);
                        Aspose.Slides.IPPImage ippImage = presentation.Images.AddImage(slideImage);

                        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[i];
                        // Each node contains at least one shape; the first shape holds the picture
                        Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];
                        shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                        shape.FillFormat.PictureFillFormat.Picture.Image = ippImage;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Failed to download image from URL '{url}': {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing node {i}: {ex.Message}");
                }
            }

            // Save the presentation
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save presentation: {ex.Message}");
            }
            finally
            {
                presentation.Dispose();
                httpClient.Dispose();
            }
        }
    }
}
