using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputImagePath = "image.jpg";
        string outputPath = "output.pptx";

        // Verify that the input image file exists
        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine("Input image file does not exist.");
            return;
        }

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Load the image and add it as a picture frame
        IImage image = Images.FromFile(inputImagePath);
        IPPImage ppImage = presentation.Images.AddImage(image);
        IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 100, 100, 400, 300, ppImage);

        // Enable reflection effect on the picture shape
        pictureFrame.EffectFormat.EnableReflectionEffect();

        // Configure reflection: distance of 2 points and 30% opacity (transparency)
        pictureFrame.EffectFormat.ReflectionEffect.Distance = 2;
        pictureFrame.EffectFormat.ReflectionEffect.EndReflectionOpacity = 30;

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}