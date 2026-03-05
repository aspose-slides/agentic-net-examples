using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string imagePath = "example.jpg";
        string outputPath = "presentationWithImage.pptx";

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        try
        {
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            try
            {
                Aspose.Slides.IPPImage img = pres.Images.AddImage(fileStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
            }
            finally
            {
                fileStream.Close();
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        finally
        {
            pres.Dispose();
        }
    }
}