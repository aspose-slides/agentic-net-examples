using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
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

                // Load SVG content and create SVG image object
                string svgContent = File.ReadAllText(svgPath);
                ISvgImage svgImage = new SvgImage(svgContent);

                // Add SVG image to the presentation's image collection
                IPPImage ppImg = pres.Images.AddImage(svgImage);

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

                // Set fill type to picture
                shape.FillFormat.FillType = FillType.Picture;

                // Assign the SVG image as the fill source
                shape.FillFormat.PictureFillFormat.Picture.Image = ppImg;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external resource errors)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}