using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSvgImages
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output directory for extracted SVG files and saved presentation
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Check if the shape is a picture frame
                        Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Get the image associated with the picture frame
                            Aspose.Slides.IPPImage ppImage = pictureFrame.PictureFormat.Picture.Image;

                            // Check if the image contains an SVG representation
                            Aspose.Slides.ISvgImage svgImage = ppImage.SvgImage;
                            if (svgImage != null)
                            {
                                // Build a file name for the extracted SVG
                                string svgFileName = $"slide_{slideIndex}_shape_{shapeIndex}.svg";
                                string svgFilePath = Path.Combine(outputDir, svgFileName);

                                // Write the SVG content to disk
                                File.WriteAllText(svgFilePath, svgImage.SvgContent);
                            }
                        }
                    }
                }

                // Save the (unchanged) presentation before exiting
                string savedPresentationPath = Path.Combine(outputDir, "saved.pptx");
                pres.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}