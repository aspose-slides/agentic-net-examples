using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output PPTX paths
            string dataDir = "Data";
            string svgPath = Path.Combine(dataDir, "input.svg");
            string outPptxPath = Path.Combine(dataDir, "output.pptx");

            // Read SVG content from file
            string svgContent = File.ReadAllText(svgPath);

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Create an ISvgImage from the SVG content
                ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

                // Add the SVG image to the presentation and obtain a PPImage (IPPImage)
                IPPImage ppImage = pres.Images.AddImage(svgImage);

                // Insert the image onto the first slide as a picture frame
                pres.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    0,
                    0,
                    ppImage.Width,
                    ppImage.Height,
                    ppImage);

                // Save the presentation
                pres.Save(outPptxPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}