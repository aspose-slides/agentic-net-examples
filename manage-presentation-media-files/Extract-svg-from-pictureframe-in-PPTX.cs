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
            // Paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputDir = Path.Combine(dataDir, "ExtractedSvgs");
            string outputPresentationPath = Path.Combine(dataDir, "output.pptx");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load presentation
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
                            Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;

                            if (pictureFrame != null)
                            {
                                // Access the picture fill format
                                Aspose.Slides.IPictureFillFormat pictureFill = pictureFrame.PictureFormat;

                                // The picture fill contains a picture (ISlidesPicture) which holds the image
                                Aspose.Slides.ISlidesPicture slidesPicture = pictureFill.Picture;
                                Aspose.Slides.IPPImage ppImage = slidesPicture.Image;

                                // Check if the image is an SVG
                                Aspose.Slides.ISvgImage svgImage = ppImage.SvgImage;
                                if (svgImage != null)
                                {
                                    // Retrieve SVG content
                                    string svgContent = svgImage.SvgContent;

                                    // Build output file name
                                    string svgFileName = $"slide{slideIndex + 1}_shape{shapeIndex + 1}.svg";
                                    string svgFilePath = Path.Combine(outputDir, svgFileName);

                                    // Write SVG content to file
                                    File.WriteAllText(svgFilePath, svgContent);
                                }
                            }
                        }
                    }

                    // Save the presentation (required by lifecycle rules)
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