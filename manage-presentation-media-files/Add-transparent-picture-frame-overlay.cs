// -----------------------------------------------------------------------------
// Example: Add transparent picture frame overlay using C#
//
// Description:
// Demonstrates how to add a transparent picture frame overlay to an existing
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// loads a PPTX file, inserts a picture frame with a transparent background
// on the first slide, and saves the modified presentation. This pattern can be
// used to automate overlay insertion, create custom branding layers, or
// enhance slides with non‑obstructive graphics.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Transparent, Picture, Frame,
// Overlay, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding transparent picture frame overlays.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string presentationPath = "input.pptx";
        string outputPath = "output.pptx";
        string imagePath = "overlay.png";

        // Verify that the input files exist
        if (!File.Exists(presentationPath))
        {
            Console.WriteLine("Presentation file not found.");
            return;
        }

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found.");
            return;
        }

        try
        {
            // Load the existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath);
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load the image and add it to the presentation's image collection
            Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage ippImage = presentation.Images.AddImage(image);

            // Add a picture frame with transparent background on top of existing content
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                100,    // X position
                100,    // Y position
                ippImage.Width,
                ippImage.Height,
                ippImage);
            pictureFrame.FillFormat.FillType = Aspose.Slides.FillType.NoFill; // Transparent background

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported formats or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
