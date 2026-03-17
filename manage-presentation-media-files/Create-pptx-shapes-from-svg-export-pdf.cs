using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgToPptxPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input SVG and output PDF paths
                string dataDir = "Data";
                string svgPath = Path.Combine(dataDir, "input.svg");
                string outputPdfPath = Path.Combine(dataDir, "output.pdf");

                // Read SVG content from file
                string svgContent = File.ReadAllText(svgPath);

                // Create a new presentation
                Presentation pres = new Presentation();

                // Create an SVG image object from the content
                ISvgImage svgImage = new SvgImage(svgContent);

                // Add the SVG image to the presentation to obtain its dimensions
                IPPImage ppImage = pres.Images.AddImage(svgImage);

                // Convert the SVG image into individual shapes by adding a group shape
                IGroupShape groupShape = pres.Slides[0].Shapes.AddGroupShape(
                    svgImage,
                    0,
                    0,
                    ppImage.Width,
                    ppImage.Height);

                // Save the resulting presentation as a PDF file
                pres.Save(outputPdfPath, SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}