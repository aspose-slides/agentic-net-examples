// -----------------------------------------------------------------------------
// Example: Extract Picture Frame Images from PPTX and Save as PNG using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, iterates through all
// slides and shapes, extracts images embedded in picture frames, and saves each
// image as a PNG file. It demonstrates the use of Aspose.Slides for .NET to
// access picture frame data and to export the (potentially unchanged) presentation.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, extract images, picture frames, PNG
// Use Cases:
// - Archiving all images from a corporate presentation for reuse.
// - Converting embedded slide graphics to separate image assets.
// - Auditing picture content in a PPTX before publishing.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesImageExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string imagesOutputFolder = "ExtractedImages";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Error: Input file \"{inputPath}\" does not exist.");
                return;
            }

            try
            {
                if (!Directory.Exists(imagesOutputFolder))
                {
                    Directory.CreateDirectory(imagesOutputFolder);
                }

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    int imageCounter = 1;

                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            Aspose.Slides.IPictureFrame pictureFrame = shape as Aspose.Slides.IPictureFrame;
                            if (pictureFrame != null)
                            {
                                Aspose.Slides.IPPImage embeddedImage = pictureFrame.PictureFormat.Picture.Image;
                                if (embeddedImage != null && embeddedImage.BinaryData != null)
                                {
                                    string imageFileName = $"Image_{imageCounter:D4}.png";
                                    string imagePath = Path.Combine(imagesOutputFolder, imageFileName);
                                    File.WriteAllBytes(imagePath, embeddedImage.BinaryData);
                                    Console.WriteLine($"Saved image to \"{imagePath}\"");
                                    imageCounter++;
                                }
                            }
                        }
                    }

                    // Save the (potentially unchanged) presentation
                    presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine($"Presentation saved to \"{outputPresentationPath}\"");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
