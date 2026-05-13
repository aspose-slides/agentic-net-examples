using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "ArrowLine.pptx";
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
        Aspose.Slides.IAutoShape line = (Aspose.Slides.IAutoShape)secondSlide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 150, 300, 0);
        line.LineFormat.Style = Aspose.Slides.LineStyle.ThickBetweenThin;
        line.LineFormat.Width = 10;
        line.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;
        line.LineFormat.BeginArrowheadLength = Aspose.Slides.LineArrowheadLength.Short;
        line.LineFormat.BeginArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Oval;
        line.LineFormat.EndArrowheadLength = Aspose.Slides.LineArrowheadLength.Long;
        line.LineFormat.EndArrowheadStyle = Aspose.Slides.LineArrowheadStyle.Triangle;
        line.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}