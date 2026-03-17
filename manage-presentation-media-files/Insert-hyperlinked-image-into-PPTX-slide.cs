using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string imagePath = "image.png";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                Aspose.Slides.IPPImage img;
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    img = pres.Images.AddImage(fs, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                }

                Aspose.Slides.IPictureFrame picture = pres.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    10, 10, 200, 150,
                    img);

                picture.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.example.com");

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}