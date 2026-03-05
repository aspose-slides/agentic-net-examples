using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSvgFromPictureFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PowerPoint file containing a picture frame with an SVG image
            string inputPath = "input.pptx";
            // Output file for the extracted SVG content
            string outputSvgPath = "extracted.svg";
            // Output path for the (possibly unchanged) presentation
            string outputPptxPath = "output.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through shapes on the first slide to find a PictureFrame
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.PictureFrame)
                    {
                        Aspose.Slides.PictureFrame pictureFrame = (Aspose.Slides.PictureFrame)shape;

                        // Get the image associated with the picture frame
                        Aspose.Slides.IPPImage pictureImage = pictureFrame.PictureFormat.Picture.Image;

                        // Check if the image contains an SVG representation
                        if (pictureImage.SvgImage != null)
                        {
                            // Retrieve the SVG content as a string
                            string svgContent = pictureImage.SvgImage.SvgContent;

                            // Write the SVG content to a file
                            File.WriteAllText(outputSvgPath, svgContent);
                        }

                        // Stop after processing the first picture frame
                        break;
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}