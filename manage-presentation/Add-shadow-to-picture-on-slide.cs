using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string imagePath = "sample.jpg";
        string outputPath = "output.pptx";

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];

                // Load image into the presentation
                IPPImage image;
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    image = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
                }

                // Add picture frame to the slide
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 300, image);

                // Enable outer shadow effect
                pictureFrame.EffectFormat.EnableOuterShadowEffect();

                // Configure shadow properties
                pictureFrame.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                pictureFrame.EffectFormat.OuterShadowEffect.Direction = 45.0f;
                pictureFrame.EffectFormat.OuterShadowEffect.Distance = 3.0;

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}