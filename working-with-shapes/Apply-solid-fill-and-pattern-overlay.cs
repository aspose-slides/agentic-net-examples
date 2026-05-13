using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape with solid fill
        Aspose.Slides.IShape solidShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
        solidShape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        solidShape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 120, 215); // solid blue

        // Add another rectangle on top with pattern fill and semi-transparency
        Aspose.Slides.IShape patternShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
        patternShape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
        patternShape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
        // Semi-transparent background color
        patternShape.FillFormat.PatternFormat.BackColor.Color = Color.FromArgb(128, 255, 255, 255);
        // Semi-transparent foreground color
        patternShape.FillFormat.PatternFormat.ForeColor.Color = Color.FromArgb(128, 0, 0, 0);

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose presentation
        presentation.Dispose();
    }
}