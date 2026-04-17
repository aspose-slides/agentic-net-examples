using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = Path.Combine("Data", "image.jpg");
        string outputPath = Path.Combine("Output", "result.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Insert the raster image as a picture frame
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50, 50, 400, 300,
            presentation.Images.AddImage(File.ReadAllBytes(inputPath)));

        // Access the image transform collection
        Aspose.Slides.Effects.IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

        // Apply a hue‑shift effect (e.g., shift hue by 30 degrees)
        imageTransform.AddHSLEffect(30f, 0f, 0f);

        // Save the presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other saving errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}