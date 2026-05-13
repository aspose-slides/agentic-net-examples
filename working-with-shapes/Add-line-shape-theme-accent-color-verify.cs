using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line shape
            Aspose.Slides.IAutoShape lineShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 50, 50, 300, 0);

            // Set line color using theme Accent1
            lineShape.LineFormat.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;

            // Verify initial line color (should reflect Accent1)
            Aspose.Slides.ILineFormatEffectiveData effectiveBefore = lineShape.LineFormat.GetEffective();
            Color colorBefore = effectiveBefore.FillFormat.SolidFillColor;
            Console.WriteLine("Line color before theme change: " + colorBefore.ToString());

            // Change the theme's Accent1 color to Green
            presentation.MasterTheme.ColorScheme.Accent1.Color = Color.Green;

            // Verify line color after theme change
            Aspose.Slides.ILineFormatEffectiveData effectiveAfter = lineShape.LineFormat.GetEffective();
            Color colorAfter = effectiveAfter.FillFormat.SolidFillColor;
            Console.WriteLine("Line color after theme change: " + colorAfter.ToString());

            // Save the presentation
            presentation.Save("LineThemeAccent.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (FileNotFoundException ex)
        {
            // Input file not found
            Console.WriteLine("File not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling (including unsupported format)
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}