using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                IAutoShape shape = slide.Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    50, 100, 300, 150);

                // Apply solid fill with a scheme color
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;

                // Apply line formatting
                shape.LineFormat.Width = 5;
                shape.LineFormat.FillFormat.FillType = FillType.Solid;
                shape.LineFormat.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent2;

                // Enable outer shadow effect and set its color
                shape.EffectFormat.EnableOuterShadowEffect();
                shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.FromArgb(128, 0, 0, 0);
                shape.EffectFormat.OuterShadowEffect.Distance = 5;

                // Save the presentation
                presentation.Save("FormattedShape.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}