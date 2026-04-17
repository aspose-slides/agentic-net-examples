using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplacePictureWithVector
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string svgPath = "vector.svg";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found.");
                return;
            }

            if (!File.Exists(svgPath))
            {
                Console.WriteLine("SVG file not found.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Find the first picture frame on the first slide
                    IPictureFrame pictureFrame = null;
                    foreach (IShape shape in pres.Slides[0].Shapes)
                    {
                        pictureFrame = shape as IPictureFrame;
                        if (pictureFrame != null)
                            break;
                    }

                    if (pictureFrame == null)
                    {
                        Console.WriteLine("No picture frame found on the first slide.");
                        return;
                    }

                    // Preserve original dimensions
                    float originalWidth = pictureFrame.Width;
                    float originalHeight = pictureFrame.Height;

                    // Load SVG content
                    string svgXml = File.ReadAllText(svgPath);
                    ISvgImage svgImage = new SvgImage(svgXml);

                    // Add SVG image to the presentation's image collection
                    IPPImage addedImage = pres.Images.AddImage(svgImage);

                    // Replace the picture frame's image with the SVG image
                    pictureFrame.PictureFormat.Picture.Image = addedImage;

                    // Restore original dimensions (in case they changed)
                    pictureFrame.Width = originalWidth;
                    pictureFrame.Height = originalHeight;

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}