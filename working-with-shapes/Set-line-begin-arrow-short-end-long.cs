using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a line shape to the slide
        IAutoShape line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

        // Configure line formatting
        line.LineFormat.Style = LineStyle.ThickBetweenThin;
        line.LineFormat.Width = 10;
        line.LineFormat.DashStyle = LineDashStyle.DashDot;
        line.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
        line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;
        line.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
        line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
        line.LineFormat.FillFormat.FillType = FillType.Solid;
        line.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

        // Save the presentation
        string outputPath = "DecorativeLine.pptx";
        presentation.Save(outputPath, SaveFormat.Pptx);
    }
}