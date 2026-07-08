using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a line shape to the slide
        Aspose.Slides.IAutoShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

        // Set the line color using a theme accent (Accent2)
        lineShape.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent2;

        // Change the theme's Accent2 color to a custom RGB value (dark green)
        pres.MasterTheme.ColorScheme.Accent2.Color = Color.FromArgb(255, 0, 128, 0);

        // Verify the line color after the theme change
        Aspose.Slides.IColorFormat lineColorFormat = lineShape.LineFormat.FillFormat.SolidFillColor;
        Color effectiveColor = lineColorFormat.Color;
        Console.WriteLine("Effective line color after theme change: " + effectiveColor.ToString());

        // Save the presentation
        pres.Save("LineShapeThemeAccent.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}