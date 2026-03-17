using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string imagePath = "large_image.jpg";
            string outputPath = "output.pptx";

            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputStream))
                {
                    using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        Aspose.Slides.IPPImage img = pres.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                        pres.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
                    }

                    using (FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        pres.Save(outputStream, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}