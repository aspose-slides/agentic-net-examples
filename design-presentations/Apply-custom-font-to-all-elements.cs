using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Sample Text");

            var portion = shape.TextFrame.Paragraphs[0].Portions[0];
            portion.PortionFormat.FontHeight = 24;
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            var options = new PptxOptions();
            options.DefaultRegularFont = "Comic Sans MS";

            presentation.Save("CustomFontPresentation.pptx", SaveFormat.Pptx, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}