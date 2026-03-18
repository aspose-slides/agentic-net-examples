using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation("input.pptx");
            var slideCount = presentation.Slides.Count;
            for (var i = 0; i < slideCount; i++)
            {
                var slide = presentation.Slides[i];
                var shapeCount = slide.Shapes.Count;
                for (var j = 0; j < shapeCount; j++)
                {
                    var shape = slide.Shapes[j];
                    if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                    {
                        autoShape.TextFrame.TextFrameFormat.RotationAngle = 45f;
                    }
                }
            }

            var saveOptionsFactory = new SaveOptionsFactory();
            var options = saveOptionsFactory.CreatePptxOptions();
            presentation.Save("output.pptx", SaveFormat.Pptx, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}