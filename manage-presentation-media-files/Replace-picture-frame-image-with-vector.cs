// -----------------------------------------------------------------------------
// Example: Replace picture frame image with vector using C#
//
// Description:
// Demonstrates how to replace a picture frame's raster image with an SVG vector
// image in a PowerPoint presentation using Aspose.Slides for .NET. The example
// loads an existing PPTX file, finds the first picture frame on the first slide,
// substitutes its image with an SVG file while preserving the original size,
// and saves the result as a new PPTX file.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, SVG, Vector Image, Picture Frame, Replace Image,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Convert raster images in slides to scalable vector graphics.
// - Automate updating slide graphics with SVG assets.
// - Build .NET tools for batch processing of PPTX files.
// - Ensure high‑quality rendering of images at any resolution.
// -----------------------------------------------------------------------------
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
