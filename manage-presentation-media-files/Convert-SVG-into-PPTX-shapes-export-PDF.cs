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
            // Paths for input SVG and output files
            string svgFilePath = "input.svg";
            string pptxFilePath = "output.pptx";
            string pdfFilePath = "output.pdf";

            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Load the SVG image from file
                    ISvgImage svgImage = new SvgImage(svgFilePath);

                    // Convert the SVG image into a group of shapes and add to the slide
                    // Parameters: svgImage, X, Y, Width, Height (in points)
                    IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 0f, 0f, 500f, 500f);

                    // Optional: Save the intermediate PPTX file
                    presentation.Save(pptxFilePath, SaveFormat.Pptx);

                    // Export the presentation as PDF
                    presentation.Save(pdfFilePath, SaveFormat.Pdf);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}