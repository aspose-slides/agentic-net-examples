using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var loadOptions = new Aspose.Slides.LoadOptions();
            var presentation = new Aspose.Slides.Presentation("input.pptx", loadOptions);
            var slide = presentation.Slides[0];
            var autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
            autoShape.AddTextFrame("Custom Shape");
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}