using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
                Aspose.Slides.ISlide slide = presentation.Slides[0];
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 30, 30, 350, 100);
                autoShape.AddTextFrame("Sample text");
                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;
                Aspose.Slides.ITextFrameFormat textFrameFormat = textFrame.TextFrameFormat;
                textFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shape;
                presentation.Save("AutofitShape.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}