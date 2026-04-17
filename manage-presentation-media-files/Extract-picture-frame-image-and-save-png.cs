using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";
            // Verify that the file exists
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
                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];
                            // Process only picture frames
                            IPictureFrame pictureFrame = shape as IPictureFrame;
                            if (pictureFrame != null)
                            {
                                // Extract the embedded image using the correct property chain
                                IPPImage embeddedImage = pictureFrame.PictureFormat.Picture.Image;
                                // Save the image as a lossless PNG
                                string outputImagePath = $"slide_{slideIndex}_shape_{shapeIndex}.png";
                                embeddedImage.Image.Save(outputImagePath, Aspose.Slides.ImageFormat.Png);
                                Console.WriteLine("Saved image: " + outputImagePath);
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation before exiting
                    string outputPresentationPath = "output.pptx";
                    presentation.Save(outputPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}