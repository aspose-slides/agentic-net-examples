using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";

            // Output directory for extracted SVG files
            string outDir = "ExtractedSvg";
            if (!System.IO.Directory.Exists(outDir))
                System.IO.Directory.CreateDirectory(outDir);

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Check if the shape is a picture frame
                    if (shape is Aspose.Slides.IPictureFrame)
                    {
                        Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;
                        Aspose.Slides.IPPImage image = pictureFrame.PictureFormat.Picture.Image;

                        // Check if the image contains an SVG
                        if (image.SvgImage != null)
                        {
                            // Get SVG data
                            byte[] svgData = image.SvgImage.SvgData;

                            // Build output file name
                            string svgFileName = $"slide_{slideIndex + 1}_shape_{shape.Name}.svg";
                            string svgFilePath = System.IO.Path.Combine(outDir, svgFileName);

                            // Write SVG data to file
                            System.IO.File.WriteAllBytes(svgFilePath, svgData);
                        }
                    }
                }
            }

            // Save the (unchanged) presentation before exiting
            string savedPath = System.IO.Path.Combine(outDir, "presentation_saved.pptx");
            presentation.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}