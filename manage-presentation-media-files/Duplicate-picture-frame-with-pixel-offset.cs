// -----------------------------------------------------------------------------
// Example: Duplicate picture frame with pixel offset using C#
//
// Description:
// Demonstrates how to duplicate a picture frame with a pixel offset using C# 
// and Aspose.Slides for .NET. The example shows the required presentation-
// processing steps for PowerPoint files and produces the requested output in a 
// standalone console application. Developers can use this pattern to automate 
// PPTX workflows, validate results, or integrate presentation logic into .NET 
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Duplicate, Picture, Frame, 
// Pixel, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate duplicate picture frame with pixel offset.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

namespace DuplicatePictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Define image file name and path
            string imageFileName = "sample.jpg";
            string imagePath = Path.Combine(dataDir, imageFileName);

            // Check if image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Load image and add to presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage imgx = pres.Images.AddImage(img);

            // Add original picture frame
            float originalX = 50f;
            float originalY = 50f;
            Aspose.Slides.IPictureFrame picture = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                originalX,
                originalY,
                imgx.Width,
                imgx.Height,
                imgx);

            // Duplicate the picture frame using AddClone
            Aspose.Slides.IShape clonedShape = slide.Shapes.AddClone(picture);

            // Offset the cloned picture frame by fixed pixels
            float offsetX = 20f; // horizontal offset
            float offsetY = 20f; // vertical offset
            clonedShape.X = picture.X + offsetX;
            clonedShape.Y = picture.Y + offsetY;

            // Save the presentation
            string outPath = Path.Combine(dataDir, "output.pptx");
            try
            {
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
