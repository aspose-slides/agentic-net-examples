using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "LineShape.pptx";
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);
            lineShape.LineFormat.Width = 4;
            lineShape.LineFormat.Style = Aspose.Slides.LineStyle.ThickThin;
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported.
        }
    }
}