using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Hello World");
            Aspose.Slides.PortionFormat format = new Aspose.Slides.PortionFormat();
            format.FontHeight = 32f;
            Aspose.Slides.Util.SlideUtil.FindAndReplaceText(pres, true, "Hello World", "Hello World", format);
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}