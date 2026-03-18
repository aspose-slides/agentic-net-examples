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
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Presentation(inputPath))
            {
                var slide = presentation.Slides[0];
                var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
                var autoShape = shape as IAutoShape;
                autoShape.AddTextFrame("First line\nSecond line");

                var paragraphs = autoShape.TextFrame.Paragraphs;
                var lastParagraph = paragraphs[paragraphs.Count - 1];
                var portions = lastParagraph.Portions;
                var lastPortion = portions[portions.Count - 1];

                var portionFormat = lastPortion.PortionFormat;
                portionFormat.FontBold = NullableBool.True;
                portionFormat.FontHeight = 24;
                portionFormat.FillFormat.FillType = FillType.Solid;
                portionFormat.FillFormat.SolidFillColor.Color = Color.Red;

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}