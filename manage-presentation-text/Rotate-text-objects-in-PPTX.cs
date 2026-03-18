using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);
            autoShape.AddTextFrame("Rotated Text");
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
            Aspose.Slides.ITextFrameFormat textFrameFormat = textFrame.TextFrameFormat;
            textFrameFormat.RotationAngle = 45f;
            presentation.Save("RotatedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}