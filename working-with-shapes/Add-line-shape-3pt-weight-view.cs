using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Presentation())
            {
                var slide = presentation.Slides[0];
                var line = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
                line.LineFormat.Width = 3;
                var outputPath = "LineShape.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception)
        {
            // Handle unsupported format or other errors
        }
    }
}