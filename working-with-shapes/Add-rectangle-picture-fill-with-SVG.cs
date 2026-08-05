// -----------------------------------------------------------------------------
// Example: Add rectangle picture fill with SVG using C#
//
// Description:
// Demonstrates how to add a rectangle shape and apply a picture fill using an
// SVG image with C# and Aspose.Slides for .NET. The example creates a new
// presentation, loads an SVG file, adds it as an image to the presentation,
// and sets the rectangle's fill to that SVG picture, then saves the PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, Rectangle, Picture Fill,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding rectangle picture fill with SVG.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with SVG graphics in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input SVG and output PPTX paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string svgPath = Path.Combine(dataDir, "image.svg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Verify SVG file exists
        if (!File.Exists(svgPath))
        {
            Console.WriteLine("SVG file not found: " + svgPath);
            return;
        }

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

            // Set fill type to picture
            shape.FillFormat.FillType = FillType.Picture;

            // Load SVG content and create SVG image object
            string svgContent = File.ReadAllText(svgPath);
            ISvgImage svgImage = new SvgImage(svgContent);

            // Add SVG image to the presentation's image collection
            IPPImage ppImg = pres.Images.AddImage(svgImage);

            // Use the SVG image as the picture fill source
            shape.FillFormat.PictureFillFormat.Picture.Image = ppImg;

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
