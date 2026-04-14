using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string imagePath = "image.jpg";
        string outputPath = "output.pptx";

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 300, image);
                pictureFrame.EffectFormat.EnableReflectionEffect();

                Aspose.Slides.Effects.IReflection reflection = pictureFrame.EffectFormat.ReflectionEffect;
                reflection.Distance = 2.0;
                reflection.EndReflectionOpacity = 30f;

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}