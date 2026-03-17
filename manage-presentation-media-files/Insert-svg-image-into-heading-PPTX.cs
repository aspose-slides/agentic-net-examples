using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input SVG and output PPTX
            string dataDir = "Data";
            string svgPath = Path.Combine(dataDir, "heading.svg");
            string outPath = Path.Combine(dataDir, "output.pptx");

            // Read SVG file content
            string svgContent = File.ReadAllText(svgPath);

            // Create SVG image object
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Add SVG image to the presentation's image collection
                Aspose.Slides.IPPImage ppImage = pres.Images.AddImage(svgImage);

                // Insert the SVG as a picture frame at the top-left corner (heading)
                pres.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0,
                    0,
                    ppImage.Width,
                    ppImage.Height,
                    ppImage);

                // Save the presentation
                pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}