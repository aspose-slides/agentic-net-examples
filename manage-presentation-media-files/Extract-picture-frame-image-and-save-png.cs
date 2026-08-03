// -----------------------------------------------------------------------------
// Example: Extract picture frame image and save PNG using C#
//
// Description:
// Demonstrates how to extract images from picture frames within a PowerPoint
// presentation and save them as PNG files using C# and Aspose.Slides for .NET.
// The example loads a PPTX file, iterates through slides and shapes, identifies
// picture frames, extracts the embedded image data, and writes each image to a
// separate PNG file. It also shows how to save the (potentially unchanged)
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Extract, Picture Frame,
// Image, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of picture frame images from presentations.
// - Build tools that convert embedded PPTX images to PNG format.
// - Integrate image extraction into .NET applications for reporting or
//   content analysis.
// - Validate and process presentation media files before publishing.
// -----------------------------------------------------------------------------
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
                                embeddedImage.Save(outputImagePath, Aspose.Slides.Export.ImageFormat.Png);
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
