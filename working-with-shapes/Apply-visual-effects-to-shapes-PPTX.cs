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
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    // Enable outer shadow effect for the shape
                    shape.EffectFormat.EnableOuterShadowEffect();

                    // Set outer shadow properties
                    shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                    shape.EffectFormat.OuterShadowEffect.Direction = 45.0f;
                    shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
                    shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(0, 0, 0);
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}