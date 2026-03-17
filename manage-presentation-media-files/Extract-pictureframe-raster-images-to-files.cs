using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractImagesFromPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output paths
                string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
                string outputFolder = Path.Combine(Directory.GetCurrentDirectory(), "ExtractedImages");
                Directory.CreateDirectory(outputFolder);

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    int imageCounter = 0;

                    // Iterate through all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                            if (pictureFrame != null)
                            {
                                // Retrieve the embedded image
                                Aspose.Slides.IPPImage embeddedImage = pictureFrame.PictureFormat.Picture.Image;

                                // Build output file name
                                string imagePath = Path.Combine(outputFolder, $"image_{imageCounter}.png");

                                // Save the image as PNG
                                embeddedImage.Image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                                imageCounter++;
                            }
                        }
                    }

                    // Save the presentation before exiting (as required)
                    string savedPresentationPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
                    presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("Image extraction completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}