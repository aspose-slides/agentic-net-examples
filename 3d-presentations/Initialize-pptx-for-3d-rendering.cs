using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
            // Configure 3D content for the shape if needed (e.g., shape.ThreeDFormat)

            Aspose.Slides.Export.SaveOptionsFactory factory = new Aspose.Slides.Export.SaveOptionsFactory();
            Aspose.Slides.Export.IPptxOptions options = factory.CreatePptxOptions();
            presentation.Save("3DPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}