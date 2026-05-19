using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtRenderExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define temporary output paths
            string tempFolder = Path.GetTempPath();
            string outputPptx = Path.Combine(tempFolder, "SmartArtPresentation.pptx");
            string outputJpeg = Path.Combine(tempFolder, "SmartArtShape.jpg");

            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Access the first slide
                    Aspose.Slides.ISlide slide = pres.Slides[0];

                    // Add a SmartArt diagram to the slide
                    Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                        50f,               // X position
                        50f,               // Y position
                        400f,              // Width
                        400f,              // Height
                        Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

                    // Render the SmartArt shape to a high‑resolution JPEG image
                    // Use ShapeThumbnailBounds.Shape and scaling factors (e.g., 2x) for higher resolution
                    using (Aspose.Slides.IImage smartArtImage = smartArt.GetImage(
                        Aspose.Slides.ShapeThumbnailBounds.Shape,
                        2f,                // Scale X
                        2f))               // Scale Y
                    {
                        // Save the image as JPEG
                        smartArtImage.Save(outputJpeg, Aspose.Slides.ImageFormat.Jpeg);
                    }

                    // Save the presentation (required before exit)
                    pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                Console.WriteLine("SmartArt rendered and saved to:");
                Console.WriteLine(outputJpeg);
                Console.WriteLine("Presentation saved to:");
                Console.WriteLine(outputPptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The requested file format is not supported by Aspose.Slides.
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}