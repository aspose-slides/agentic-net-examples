using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 300, 200);

        // Set fill to pattern
        shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;

        // Choose a pattern style
        shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;

        // Set foreground color with transparency (alpha 128)
        shape.FillFormat.PatternFormat.ForeColor.Color = System.Drawing.Color.FromArgb(128, 255, 0, 0); // semi-transparent red

        // Set background color opaque blue
        shape.FillFormat.PatternFormat.BackColor.Color = System.Drawing.Color.FromArgb(255, 0, 0, 255); // blue

        // Save the presentation
        pres.Save("PatternFillTransparency.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose presentation
        pres.Dispose();
    }
}