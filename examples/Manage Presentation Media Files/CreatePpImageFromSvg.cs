using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the SVG file
            string svgFilePath = "content.svg";

            // Read SVG content from file
            string svgContent = File.ReadAllText(svgFilePath);

            // Create an ISvgImage instance from the SVG content
            ISvgImage svgImage = new SvgImage(svgContent);

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Add the SVG image to the presentation's image collection
                // This returns an IPPImage which is actually a PPImage
                IPPImage addedImage = presentation.Images.AddImage(svgImage);

                // Optionally cast to PPImage if specific PPImage members are needed
                PPImage ppImage = (PPImage)addedImage;

                // Save the presentation in PPTX format
                presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
            }
        }
    }
}