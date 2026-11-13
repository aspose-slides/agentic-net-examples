// -----------------------------------------------------------------------------
// Example: Add rectangle picture fill with SVG using C#
// 
// Description:
// Demonstrates how to create a new PowerPoint presentation, add a rectangle
// shape, and apply an SVG image as a picture fill using Aspose.Slides for .NET.
// The program generates a simple SVG file if missing, embeds it into the
// presentation, and saves the result as a PPTX file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SVG, rectangle, picture fill
// 
// Use Cases:
// - Automate insertion of SVG graphics as shape fills in presentations.
// - Build .NET tools for batch processing of PPTX files with vector images.
// - Generate marketing decks with scalable SVG artwork programmatically.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string svgPath = Path.Combine(dataDir, "image.svg");
        if (!File.Exists(svgPath))
        {
            try
            {
                string sampleSvg = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\"><rect width=\"200\" height=\"200\" fill=\"green\"/></svg>";
                File.WriteAllText(svgPath, sampleSvg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample SVG file: " + ex.Message);
                Environment.Exit(1);
            }
        }

        string outputPath = Path.Combine(dataDir, "output.pptx");

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IAutoShape rectShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 300);
            rectShape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

            string svgContent = File.ReadAllText(svgPath);
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);
            Aspose.Slides.IPPImage ppImage = pres.Images.AddImage(svgImage);
            rectShape.FillFormat.PictureFillFormat.Picture.Image = ppImage;

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
