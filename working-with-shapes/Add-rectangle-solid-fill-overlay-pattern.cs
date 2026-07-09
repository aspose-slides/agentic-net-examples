using System;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        var presentation = new Aspose.Slides.Presentation();
        var slide = presentation.Slides[0];

        // Base rectangle with solid fill
        var solidRect = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
        solidRect.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        solidRect.FillFormat.SolidFillColor.Color = Color.Blue;

        // Overlay rectangle with semi‑transparent pattern fill
        var patternRect = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
        patternRect.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
        patternRect.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
        patternRect.FillFormat.PatternFormat.BackColor.Color = Color.FromArgb(0, Color.White);
        patternRect.FillFormat.PatternFormat.ForeColor.Color = Color.FromArgb(128, Color.Black);

        // Save presentation
        presentation.Save("OverlayPattern.pptx", SaveFormat.Pptx);
        presentation.Dispose();
    }
}