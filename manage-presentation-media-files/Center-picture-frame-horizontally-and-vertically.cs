// -----------------------------------------------------------------------------
// Example: Center picture frame horizontally and vertically using C#
//
// Description:
// Demonstrates how to center a picture frame both horizontally and vertically 
// using C# and Aspose.Slides for .NET. The example loads an image, inserts it 
// as a picture frame into a new presentation, aligns the shape to the center 
// of the slide, and saves the result as a PPTX file. This pattern can be used 
// for automating PowerPoint layout tasks in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Center, Picture, Frame, 
// Horizontally, Vertically, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate centering picture frames horizontally and vertically.
// - Build C# tools for PowerPoint presentation layout processing.
// - Generate or transform PPTX files with centered images in .NET applications.
// - Validate slide designs before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string imagePath = Path.Combine(dataDir, "image.jpg");
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        Presentation pres = new Presentation();
        IImage img = Aspose.Slides.Images.FromFile(imagePath);
        IPPImage pptImg = pres.Images.AddImage(img);
        IPictureFrame pf = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pptImg.Width, pptImg.Height, pptImg);
        SlideUtil.AlignShapes(ShapesAlignmentType.AlignCenter, true, pres.Slides[0]);

        string outPath = Path.Combine(dataDir, "output.pptx");
        try
        {
            pres.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            pres.Dispose();
        }
    }
}
