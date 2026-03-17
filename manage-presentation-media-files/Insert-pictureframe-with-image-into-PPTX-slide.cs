using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            using (var fileStream = new FileStream("image.jpg", FileMode.Open, FileAccess.Read))
            {
                var image = presentation.Images.AddImage(fileStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                var pictureFrame = slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 300f, 200f, image);
            }
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}