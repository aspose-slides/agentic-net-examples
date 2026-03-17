using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Path to the SVG file to be inserted
                string svgPath = Path.Combine(Directory.GetCurrentDirectory(), "example.svg");

                // Load the SVG content as an ISvgImage
                Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgPath);

                // Add the SVG image to the presentation's image collection
                Aspose.Slides.IPPImage addedImage = presentation.Images.AddImage(svgImage);

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Insert the SVG image onto the slide as a picture frame
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, addedImage);

                // Export the slide as an SVG file (optional verification)
                string slideSvgPath = Path.Combine(Directory.GetCurrentDirectory(), "slide_1.svg");
                using (FileStream svgStream = File.Create(slideSvgPath))
                {
                    slide.WriteAsSvg(svgStream);
                }

                // Save the presentation to PPTX format
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}