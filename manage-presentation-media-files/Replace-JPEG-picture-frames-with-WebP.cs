using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReplaceJpegWithWebP
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            string webpReplacementPath = Path.Combine(Directory.GetCurrentDirectory(), "replacement.webp");

            // Verify that the input presentation exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            // Verify that the replacement WebP image exists
            if (!File.Exists(webpReplacementPath))
            {
                Console.WriteLine("WebP replacement image not found: " + webpReplacementPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Load WebP image bytes once (reused for all replacements)
                    byte[] webpBytes = File.ReadAllBytes(webpReplacementPath);
                    Aspose.Slides.IPPImage webpImage = presentation.Images.AddImage(webpBytes);

                    // Iterate through all slides and shapes
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                            if (pictureFrame != null)
                            {
                                // Access the embedded image via PictureFormat.Picture.Image
                                Aspose.Slides.IPPImage embeddedImage = pictureFrame.PictureFormat.Picture.Image;
                                if (embeddedImage != null && embeddedImage.ContentType != null &&
                                    embeddedImage.ContentType.IndexOf("jpeg", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    // Replace JPEG image with the WebP image
                                    pictureFrame.PictureFormat.Picture.Image = webpImage;
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported by Aspose.Slides.
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}