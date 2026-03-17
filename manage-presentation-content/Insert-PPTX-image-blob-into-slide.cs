using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string imagePath = "large_image.jpg";
            string outputPath = "presentationWithLargeImage.pptx";

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage img = pres.Images.AddImage(fileStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                    pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}