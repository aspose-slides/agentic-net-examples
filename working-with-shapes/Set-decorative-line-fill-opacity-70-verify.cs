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
                var presentation = new Presentation();
                var slide = presentation.Slides[0];

                // Add a decorative line shape
                var lineShape = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 100, 400, 0);

                // Set line width
                lineShape.LineFormat.Width = 5;

                // Set solid fill with 70% opacity (alpha = 178)
                lineShape.LineFormat.FillFormat.FillType = FillType.Solid;
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(178, Color.Black);

                // Verify effective opacity
                var effectiveLine = lineShape.LineFormat.GetEffective();
                var effectiveFill = effectiveLine.FillFormat;
                var effectiveColor = effectiveFill.SolidFillColor;
                Console.WriteLine("Effective line fill color ARGB: " + effectiveColor.ToArgb());

                // Save the presentation
                var outputPath = "LineOpacityExample.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}