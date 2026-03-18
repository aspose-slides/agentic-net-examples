using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var presentation = new Aspose.Slides.Presentation();
        try
        {
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 100);
            shape.AddTextFrame("Why Use Bullet Lists?");
            presentation.Save("BulletListSlide.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            presentation.Dispose();
        }
    }
}