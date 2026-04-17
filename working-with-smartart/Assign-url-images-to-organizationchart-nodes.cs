using System;
using System.IO;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;
using Aspose.Slides.SmartArt;
using Aspose.Slides;

namespace PictureOrganizationChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // List of image URLs to assign to chart nodes
            string[] imageUrls = new string[]
            {
                "https://example.com/image1.jpg",
                "https://example.com/image2.jpg",
                "https://example.com/image3.jpg"
            };

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a Picture Organization Chart SmartArt to the first slide
            ISlide slide = presentation.Slides[0];
            ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, SmartArtLayoutType.PictureOrganizationChart);

            // Assign images from URLs to each node (if possible)
            try
            {
                for (int i = 0; i < smartArt.Nodes.Count && i < imageUrls.Length; i++)
                {
                    ISmartArtNode node = smartArt.Nodes[i];
                    if (node.Shapes.Count > 0)
                    {
                        // The first shape of a picture organization chart node is a picture
                        IShape shape = node.Shapes[0];
                        ISlidesPicture picture = shape as ISlidesPicture;
                        if (picture != null)
                        {
                            // Set the online image link; Aspose.Slides will load the image from the URL
                            picture.LinkPathLong = imageUrls[i];
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                // Handle exceptions related to downloading images from URLs
                Console.WriteLine("Error accessing image URL: " + webEx.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported
                // Comment: format not supported.
            }

            // Save the presentation
            string outputPath = "PictureOrganizationChart.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}