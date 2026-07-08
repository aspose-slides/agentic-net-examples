using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an ellipse shape
            IAutoShape ellipse = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 150);

            // Set fill and line formatting (optional)
            ellipse.FillFormat.FillType = FillType.Solid;
            ellipse.FillFormat.SolidFillColor.Color = Color.LightBlue;
            ellipse.LineFormat.FillFormat.FillType = FillType.Solid;
            ellipse.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
            ellipse.LineFormat.Width = 2;

            // Enable soft edge effect and set radius to 10 points
            ellipse.EffectFormat.EnableSoftEdgeEffect();
            ellipse.EffectFormat.SoftEdgeEffect.Radius = 10;

            // Save the presentation
            string outputPath = "SoftEdgeEllipse.pptx";
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}