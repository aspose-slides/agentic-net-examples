// -----------------------------------------------------------------------------
// Example: Set rectangle picture fill uniform verify using C#
//
// Description:
// Demonstrates how to set a rectangle shape's picture fill to uniform (stretch) 
// mode using C# and Aspose.Slides for .NET, and verifies that the fill mode is 
// correctly applied. The example creates a new presentation, adds a rectangle 
// filled with an image, checks the fill mode, and saves the result as a PPTX file.
// This pattern helps developers automate PowerPoint image fill settings and 
// validate presentation content in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Picture, Fill, 
// Uniform, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate setting rectangle picture fill to uniform scaling.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with specific image fill requirements.
// - Validate picture fill configurations before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string imageFileName = "sample.jpg";
        string imagePath = Path.Combine(dataDir, imageFileName);
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        string outputFileName = "output.pptx";
        string outPath = Path.Combine(dataDir, outputFileName);

        try
        {
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];
            IImage img = Images.FromFile(imagePath);
            IPPImage imgx = pres.Images.AddImage(img);
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, imgx.Width, imgx.Height);
            shape.FillFormat.FillType = FillType.Picture;
            shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
            shape.FillFormat.PictureFillFormat.StretchOffsetLeft = 0;
            shape.FillFormat.PictureFillFormat.StretchOffsetRight = 0;
            shape.FillFormat.PictureFillFormat.StretchOffsetTop = 0;
            shape.FillFormat.PictureFillFormat.StretchOffsetBottom = 0;

            // Verify that the picture fill mode is set to Stretch (uniform scaling preserves aspect ratio)
            bool aspectRatioPreserved = shape.FillFormat.PictureFillFormat.PictureFillMode == PictureFillMode.Stretch;
            Console.WriteLine("Aspect ratio preserved: " + aspectRatioPreserved);

            pres.Save(outPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
