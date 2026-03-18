using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Enable inner shadow effect
                shape.EffectFormat.EnableInnerShadowEffect();

                // Optionally configure inner shadow properties
                shape.EffectFormat.InnerShadowEffect.BlurRadius = 5.0;
                shape.EffectFormat.InnerShadowEffect.Direction = 45.0f;
                shape.EffectFormat.InnerShadowEffect.Distance = 3.0;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}