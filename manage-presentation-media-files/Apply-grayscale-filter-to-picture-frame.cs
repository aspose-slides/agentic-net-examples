// -----------------------------------------------------------------------------
// Example: Apply grayscale filter to picture frame using C#
//
// Description:
// Demonstrates how to apply grayscale filter to picture frame using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Grayscale, Filter, 
// Picture, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate apply grayscale filter to picture frame.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input image and output presentation
        string inputImagePath = "input.jpg";
        string outputPresentationPath = "output.pptx";

        // Verify that the input image file exists
        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine("Input image file does not exist.");
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Load the image from file and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(inputImagePath);
            Aspose.Slides.IPPImage imgX = pres.Images.AddImage(img);

            // Insert the image as a picture frame on the slide
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50f,
                50f,
                imgX.Width,
                imgX.Height,
                imgX);

            // Apply a grayscale effect to the picture
            pictureFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

            // Save the presentation
            pres.Save(outputPresentationPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported formats or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
