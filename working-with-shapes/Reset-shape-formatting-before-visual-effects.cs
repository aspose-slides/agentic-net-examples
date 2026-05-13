using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Reset formatting of all shapes on the slide (including the target shape)
                slide.Reset();

                // Example: work with the first shape on the slide
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Apply a new visual effect: enable outer shadow
                shape.EffectFormat.EnableOuterShadowEffect();
                shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
                shape.EffectFormat.OuterShadowEffect.Direction = 45;
                shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.FromArgb(0, 0, 0);

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}