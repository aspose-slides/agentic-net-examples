// -----------------------------------------------------------------------------
// Example: Insert SVG picture frame on slide two using C#
//
// Description:
// Demonstrates how to insert an SVG picture frame onto the second slide of a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, ensures a second slide exists, reads an SVG file,
// converts it to an Aspose.Slides image, adds it as a picture frame preserving
// vector quality, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Insert, Picture, Frame,
// Slide, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of SVG picture frames on specific slides.
// - Build .NET tools for PowerPoint presentation processing involving vector graphics.
// - Generate or transform PPTX files with embedded SVG content.
// - Validate presentation workflows that require high‑quality scalable images.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputSvgPath = Path.Combine(Directory.GetCurrentDirectory(), "input.svg");
        string outputPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

        if (!File.Exists(inputSvgPath))
        {
            Console.WriteLine("Input SVG file does not exist.");
            return;
        }

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Ensure there is a second slide
            ISlide slide2;
            if (pres.Slides.Count > 1)
            {
                slide2 = pres.Slides[1];
            }
            else
            {
                slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
            }

            // Read SVG content
            string svgContent = File.ReadAllText(inputSvgPath);

            // Create SVG image object
            ISvgImage svgImage = new SvgImage(svgContent);

            // Add SVG image to presentation preserving vector quality
            IPPImage ppImage = pres.Images.AddImage(svgImage);

            // Add picture frame to second slide
            slide2.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, ppImage.Width, ppImage.Height, ppImage);

            // Save presentation
            pres.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
