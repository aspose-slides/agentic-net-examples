using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertSvgToEmf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        IShapeCollection shapes = slide.Shapes;

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                        {
                            IPictureFrame pictureFrame = shapes[shapeIndex] as IPictureFrame;
                            if (pictureFrame == null)
                                continue;

                            // Get the image associated with the picture frame
                            IPPImage pictureImage = pictureFrame.PictureFormat.Picture.Image;
                            if (pictureImage == null)
                                continue;

                            // Check if the image is an SVG
                            ISvgImage svgImage = pictureImage.SvgImage;
                            if (svgImage == null)
                                continue;

                            // Convert SVG to EMF using a memory stream
                            using (MemoryStream emfStream = new MemoryStream())
                            {
                                svgImage.WriteAsEmf(emfStream);
                                emfStream.Position = 0; // Reset stream position

                                // Add the EMF image to the presentation's image collection
                                IPPImage emfImage = presentation.Images.AddImage(emfStream);

                                // Replace the original picture frame image with the EMF image
                                pictureFrame.PictureFormat.Picture.Image = emfImage;
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Conversion completed successfully. Saved to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}