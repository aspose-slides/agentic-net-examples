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