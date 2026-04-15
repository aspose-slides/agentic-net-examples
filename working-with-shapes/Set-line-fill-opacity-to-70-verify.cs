using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LineOpacityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Add a decorative line shape
                IShape lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 400, 0);

                // Set line fill to solid color with 70% opacity (alpha = 179)
                lineShape.LineFormat.FillFormat.FillType = FillType.Solid;
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(179, Color.Black);

                // Verify effective line fill opacity
                ILineFormatEffectiveData effectiveLineFormat = lineShape.LineFormat.GetEffective();
                ILineFillFormatEffectiveData effectiveFill = effectiveLineFormat.FillFormat;
                Color effectiveColor = effectiveFill.SolidFillColor;
                float effectiveOpacity = (float)effectiveColor.A / 255f * 100f;

                Console.WriteLine("Effective line fill opacity: " + effectiveOpacity + "%");

                // Save the presentation
                string outputPath = "LineOpacityExample.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}