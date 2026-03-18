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
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);
            shape.AddTextFrame(string.Empty);
            var htmlContent = "<p><b>Hello</b> <i>World</i></p><p>Second paragraph</p>";
            shape.TextFrame.Paragraphs.AddFromHtml(htmlContent);
            presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}