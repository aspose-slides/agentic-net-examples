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
            var presentation = new Presentation();
            var masterSlide = presentation.Masters[0];
            var imageData = File.ReadAllBytes("image.png");
            var picture = presentation.Images.AddImage(imageData);
            masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}