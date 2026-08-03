// -----------------------------------------------------------------------------
// Example: Download png image and set slide background using C#
//
// Description:
// Demonstrates how to download a PNG image from a remote URL, add it to a
// presentation, set it as the background of the first slide, and save the
// result as a PPTX file using Aspose.Slides for .NET. The example includes
// error handling for network issues and ensures proper disposal of resources.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Download, Image, Slide,
// Background, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate downloading a PNG image and applying it as a slide background.
// - Build C# utilities for PowerPoint presentation manipulation.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate presentation workflows involving external image resources.
// -----------------------------------------------------------------------------
using System;
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string imageUrl = "https://example.com/image.png";
        string outputPath = "output.pptx";

        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation();

            // Download image data from remote URL
            byte[] imageData;
            using (WebClient client = new WebClient())
            {
                try
                {
                    imageData = client.DownloadData(imageUrl);
                }
                catch (WebException we)
                {
                    Console.WriteLine("Failed to download image: " + we.Message);
                    return;
                }
            }

            // Add image to presentation
            Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

            // Set slide background to the downloaded image
            Aspose.Slides.ISlide slide = pres.Slides[0];
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            slide.Background.FillFormat.PictureFillFormat.Picture.Image = img;

            // Save presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (pres != null)
            {
                pres.Dispose();
            }
        }
    }
}
