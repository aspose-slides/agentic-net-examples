using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ReflectionEffectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.jpg";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input image file not found: " + inputPath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Load the image and add it as a picture frame
                IImage img = Images.FromFile(inputPath);
                IPPImage image = pres.Images.AddImage(img);
                IPictureFrame picture = pres.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    50, 50,
                    img.Width, img.Height,
                    image);

                // Enable reflection effect and configure properties
                picture.EffectFormat.EnableReflectionEffect();
                picture.EffectFormat.ReflectionEffect.Distance = 2.0; // two point distance
                picture.EffectFormat.ReflectionEffect.EndReflectionOpacity = 70f; // 30% transparency

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Handle format not supported or other specific exceptions as needed
            }
        }
    }
}