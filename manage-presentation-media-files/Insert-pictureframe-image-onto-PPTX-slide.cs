using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            string imagePath = "image.jpg";

            using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                Aspose.Slides.IShapeCollection shapes = presentation.Slides[0].Shapes;
                shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 200, image);
            }

            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}