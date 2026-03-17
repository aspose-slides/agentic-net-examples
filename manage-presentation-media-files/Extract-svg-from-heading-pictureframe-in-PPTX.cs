using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractSvgFromHeadingPictureFrames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths configuration
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputDir = Path.Combine(dataDir, "ExtractedSvgs");
            string outputPresentationPath = Path.Combine(dataDir, "output.pptx");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Process only picture frames
                            Aspose.Slides.PictureFrame pictureFrame = shape as Aspose.Slides.PictureFrame;
                            if (pictureFrame == null)
                                continue;

                            // Get the image associated with the picture frame
                            Aspose.Slides.IPPImage ppImage = pictureFrame.PictureFormat.Picture.Image;
                            if (ppImage == null)
                                continue;

                            // Check if the image is an SVG image
                            Aspose.Slides.ISvgImage svgImage = ppImage.SvgImage;
                            if (svgImage == null)
                                continue;

                            // Retrieve SVG content
                            string svgContent = svgImage.SvgContent;

                            // Build output file name
                            string svgFileName = $"slide_{slideIndex + 1}_shape_{shapeIndex + 1}.svg";
                            string svgFilePath = Path.Combine(outputDir, svgFileName);

                            // Save SVG content to file
                            File.WriteAllText(svgFilePath, svgContent);
                        }
                    }

                    // Save the (unchanged) presentation before exiting
                    pres.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}