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
            // Input presentation path
            string inputPath = "input.pptx";
            // Directory to save extracted SVG files
            string outputDir = "ExtractedSvgs";

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Iterate through slides
            int slideIndex = 0;
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                int shapeIndex = 0;
                // Iterate through shapes on the slide
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Check if the shape is a picture frame
                    Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                    if (pictureFrame != null)
                    {
                        // Get the image associated with the picture frame
                        Aspose.Slides.IPPImage img = pictureFrame.PictureFormat.Picture.Image;
                        // Check if the image contains an SVG representation
                        Aspose.Slides.ISvgImage svgImg = img.SvgImage;
                        if (svgImg != null)
                        {
                            // Build a file name for the extracted SVG
                            string svgPath = Path.Combine(outputDir, $"slide{slideIndex}_shape{shapeIndex}.svg");
                            // Write the SVG content to file
                            File.WriteAllText(svgPath, svgImg.SvgContent);
                        }
                    }
                    shapeIndex++;
                }
                slideIndex++;
            }

            // Save the (unchanged) presentation before exiting
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}