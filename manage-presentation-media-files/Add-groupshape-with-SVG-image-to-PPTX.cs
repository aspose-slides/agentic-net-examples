using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddGroupShapeFromSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Load SVG file and add it to the presentation images collection
                ISvgImage svgImage;
                using (FileStream svgStream = File.OpenRead("example.svg"))
                {
                    IPPImage ppImage = pres.Images.AddImage(svgStream);
                    svgImage = ppImage.SvgImage;
                }

                // Add a group shape using the SVG image
                IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 50f, 50f, 400f, 300f);

                // Optionally add a rectangle inside the group to demonstrate usage
                groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 0f, 0f, 100f, 50f);

                // Save the presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}