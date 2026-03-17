using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source SVG file
                string svgPath = "input.svg";
                // Path to the output PDF file
                string pdfPath = "output.pdf";

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Add a blank slide
                ISlide slide = presentation.Slides[0];

                // Read SVG content into a byte array
                byte[] svgBytes;
                using (FileStream svgFileStream = File.OpenRead(svgPath))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        svgFileStream.CopyTo(ms);
                        svgBytes = ms.ToArray();
                    }
                }

                // Add the SVG as an image to the slide (treated as a shape)
                IPictureFrame picture = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height, presentation.Images.AddImage(svgBytes));

                // Optionally, you can manipulate the picture shape here (e.g., resize, reposition)

                // Save the presentation as PDF
                presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}