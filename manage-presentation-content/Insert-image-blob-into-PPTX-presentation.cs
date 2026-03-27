using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string imagePath = "large_image.jpg";
        string outputPath = "presentationWithLargeImage.pptx";

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}