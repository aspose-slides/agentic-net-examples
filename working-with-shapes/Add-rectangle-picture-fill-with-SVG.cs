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
            string svgFilePath = "example.svg";
            string outputPath = "RectangleWithSvgFill.pptx";

            if (!File.Exists(svgFilePath))
            {
                Console.WriteLine("SVG file not found: " + svgFilePath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation())
                {
                    ISlide slide = presentation.Slides[0];

                    // Load SVG image and add it to the presentation's image collection
                    SvgImage svgImage = new SvgImage(svgFilePath);
                    IPPImage svgAddedImage = presentation.Images.AddImage(svgImage);

                    // Add a rectangle shape
                    IAutoShape rectangle = slide.Shapes.AddAutoShape(
                        ShapeType.Rectangle, 50f, 50f, 300f, 200f);

                    // Set fill type to picture and assign the SVG image as fill source
                    rectangle.FillFormat.FillType = FillType.Picture;
                    rectangle.FillFormat.PictureFillFormat.Picture.Image = svgAddedImage;

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}