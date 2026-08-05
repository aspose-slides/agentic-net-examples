// -----------------------------------------------------------------------------
// Example: Insert image into picture placeholder from path using C#
//
// Description:
// Demonstrates how to insert an image from a file path into a picture placeholder
// in a PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a picture placeholder to a blank layout slide,
// loads an external image, and places it into the placeholder on the first slide.
// It then saves the presentation as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert Image, Picture Placeholder,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate inserting images into picture placeholders from file paths.
// - Build C# tools for PowerPoint presentation generation and editing.
// - Generate or transform PPTX files programmatically in .NET applications.
// - Validate presentation workflows involving image placement before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertImageIntoPlaceholder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input image path and output presentation path
            string imagePath = "input.jpg";
            string outputPath = "output.pptx";

            // Check if the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            try
            {
                // Get a blank layout slide
                ILayoutSlide layout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

                // Add a picture placeholder to the layout slide
                IAutoShape placeholder = layout.PlaceholderManager.AddPicturePlaceholder(50, 50, 400, 300);

                // Load the external image
                IImage img = Images.FromFile(imagePath);
                IPPImage imgX = pres.Images.AddImage(img);

                // Add a picture frame to the first slide using the placeholder's dimensions
                ISlide slide = pres.Slides[0];
                slide.Shapes.AddPictureFrame(ShapeType.Rectangle, placeholder.X, placeholder.Y, placeholder.Width, placeholder.Height, imgX);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}
