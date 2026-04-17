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
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Base rectangle with solid fill
            var solidRect = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
            solidRect.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            solidRect.FillFormat.SolidFillColor.Color = Color.Blue;

            // Overlay rectangle with semi‑transparent pattern fill
            var patternRect = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);
            patternRect.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
            patternRect.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
            patternRect.FillFormat.PatternFormat.BackColor.Color = Color.FromArgb(128, Color.White);
            patternRect.FillFormat.PatternFormat.ForeColor.Color = Color.FromArgb(128, Color.Black);

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file I/O errors)
        }
    }
}