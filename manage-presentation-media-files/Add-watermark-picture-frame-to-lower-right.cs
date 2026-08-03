// -----------------------------------------------------------------------------
// Example: Add watermark picture frame to lower right using C#
//
// Description:
// Demonstrates how to add a watermark picture frame to the lower right corner
// of each slide in a PowerPoint presentation using C# and Aspose.Slides for .NET.
// The example loads an input PPTX, inserts a PNG image as a picture frame on
// every slide, and saves the result as a new PPTX file. This pattern can be used
// to automate watermarking of presentations in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Watermark, Picture Frame, Lower Right,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically add a logo or watermark to the lower right of all slides.
// - Build command‑line tools for batch processing of PowerPoint files.
// - Integrate watermarking into document generation pipelines.
// - Ensure branding consistency across presentation assets.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchWatermark
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect three arguments: input presentation, watermark image, output presentation
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: BatchWatermark <input.pptx> <watermark.png> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string watermarkPath = args[1];
            string outputPath = args[2];

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist: " + inputPath);
                return;
            }

            if (!File.Exists(watermarkPath))
            {
                Console.WriteLine("Watermark image file does not exist: " + watermarkPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(inputPath);

                // Load the watermark image and add it to the presentation's image collection
                IImage watermarkImage = Images.FromFile(watermarkPath);
                IPPImage watermarkPpImage = pres.Images.AddImage(watermarkImage);

                // Define a margin from the slide edges
                const float margin = 10f;

                // Iterate through all slides and add the watermark picture frame
                foreach (ISlide slide in pres.Slides)
                {
                    // Calculate position for lower right corner
                    float slideWidth = pres.SlideSize.Size.Width;
                    float slideHeight = pres.SlideSize.Size.Height;
                    float pictureWidth = watermarkPpImage.Width;
                    float pictureHeight = watermarkPpImage.Height;

                    float posX = slideWidth - pictureWidth - margin;
                    float posY = slideHeight - pictureHeight - margin;

                    // Add picture frame using the provided rule pattern
                    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                        ShapeType.Rectangle,
                        posX,
                        posY,
                        pictureWidth,
                        pictureHeight,
                        watermarkPpImage);
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Watermark added to all slides. Saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the exception is due to unsupported format, you could add a comment here.
                // Format not supported.
            }
        }
    }
}
