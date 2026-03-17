using System;
using System.Drawing;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Aspose.Slides.Presentation presentation = null;
            try
            {
                // Create a new presentation
                presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape
                Aspose.Slides.IShape tempShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 200);
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)tempShape;

                // Set solid fill color for the shape
                shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                shape.FillFormat.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 255); // Blue

                // Enable outer shadow effect and configure its properties
                shape.EffectFormat.EnableOuterShadowEffect();
                shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
                shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(128, 0, 0, 0); // Semi‑transparent black

                // Set slide background to a solid light gray color
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                slide.Background.FillFormat.SolidFillColor.Color = Color.LightGray;

                // Save the presentation
                presentation.Save("ModifiedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}