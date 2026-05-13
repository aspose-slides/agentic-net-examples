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
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape (used as decorative line)
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 5);

            // Configure line format
            shape.LineFormat.Width = 5;
            shape.LineFormat.Style = LineStyle.ThickThin;
            shape.LineFormat.DashStyle = LineDashStyle.Dash;

            // Set line fill to solid with 70% opacity (alpha = 178 out of 255)
            shape.LineFormat.FillFormat.FillType = FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.FromArgb(178, 0, 0, 255); // Semi-transparent blue

            // Verify effective line format opacity
            ILineFormatEffectiveData effectiveLineFormat = shape.LineFormat.GetEffective();
            ILineFillFormatEffectiveData effectiveFill = effectiveLineFormat.FillFormat;

            // Output effective fill type and color (including alpha)
            Console.WriteLine("Effective Line Fill Type: " + effectiveFill.FillType);
            Console.WriteLine("Effective Line Fill Color (ARGB): " + effectiveFill.SolidFillColor.ToString());

            // Save the presentation
            try
            {
                presentation.Save("LineOpacityDemo.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            finally
            {
                presentation.Dispose();
            }
        }
    }
}