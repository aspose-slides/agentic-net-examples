using System;
using System.IO;
using System.Drawing.Imaging;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output PPTX file path (saved after processing)
        string outputPath = "output.pptx";
        // Directory to store extracted raster images
        string imagesDirectory = "ExtractedImages";

        // Ensure the images directory exists
        System.IO.Directory.CreateDirectory(imagesDirectory);

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Check if the shape is a picture (implements ISlidesPicture)
                Aspose.Slides.ISlidesPicture pictureShape = shape as Aspose.Slides.ISlidesPicture;
                if (pictureShape != null)
                {
                    // Get the embedded image (IPPImage)
                    Aspose.Slides.IPPImage ppImage = pictureShape.Image;
                    if (ppImage != null)
                    {
                        // Retrieve the raster image (IImage) from the IPPImage
                        Aspose.Slides.IImage rasterImage = ppImage.Image;
                        if (rasterImage != null)
                        {
                            // Build a unique file name for each extracted image
                            string imageFileName = $"slide{slideIndex}_shape{shapeIndex}.png";
                            string imagePath = System.IO.Path.Combine(imagesDirectory, imageFileName);

                            // Save the raster image as PNG
                            rasterImage.Save(imagePath, ImageFormat.Png);
                        }
                    }
                }
            }
        }

        // Save the (potentially modified) presentation before exiting
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}