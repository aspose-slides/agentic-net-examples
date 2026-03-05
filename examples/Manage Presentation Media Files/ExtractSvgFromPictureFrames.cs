using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSvgFromPictureFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load the presentation
            string inputPath = "input.pptx";
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a picture frame
                        if (shape is IPictureFrame)
                        {
                            IPictureFrame pictureFrame = (IPictureFrame)shape;
                            IPPImage image = pictureFrame.PictureFormat.Picture.Image;

                            // Check if the image contains an SVG representation
                            if (image.SvgImage != null)
                            {
                                ISvgImage svgImage = image.SvgImage;

                                // Retrieve SVG content
                                string svgContent = svgImage.SvgContent;

                                // Define output file name
                                string outputFileName = $"slide_{slideIndex}_shape_{shapeIndex}.svg";

                                // Write SVG content to file
                                File.WriteAllText(outputFileName, svgContent);
                            }
                        }
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                string outputPresentationPath = "output.pptx";
                presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            }
        }
    }
}