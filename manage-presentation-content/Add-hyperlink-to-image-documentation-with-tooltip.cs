// -----------------------------------------------------------------------------
// Example: Add hyperlink to image documentation with tooltip using C#
//
// Description:
// Demonstrates how to add a hyperlink with a tooltip to an image in a PowerPoint
// presentation using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts an image, assigns an external URL hyperlink and a tooltip
// to the image, and saves the result as a PPTX file. This pattern can be used to
// automate documentation linking within slides.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Hyperlink, Image, Tooltip,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding hyperlinks with tooltips to images in PowerPoint slides.
// - Build C# utilities for enhancing presentation interactivity.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate and test presentation content before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkImagesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths and hyperlink details
            string imagePath = "image1.png";
            string outputPath = "output.pptx";
            string externalUrl = "https://example.com/documentation";
            string tooltipText = "Open documentation";

            // Verify image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Create a new presentation
                presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load image and add to presentation's image collection
                Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
                Aspose.Slides.IPPImage imgx = presentation.Images.AddImage(image);

                // Add picture frame to the slide
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50, 50, 300, 200,
                    imgx);

                // Set external hyperlink and tooltip on the picture
                pictureFrame.HyperlinkClick = new Aspose.Slides.Hyperlink(externalUrl);
                pictureFrame.HyperlinkClick.Tooltip = tooltipText;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
