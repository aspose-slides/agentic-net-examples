using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Reset formatting of all shapes on the slide (including the selected shape)
                slide.Reset();

                // Select a shape (for example, the first shape)
                IShape shape = slide.Shapes[0];

                // Apply new visual effects: enable outer shadow
                shape.EffectFormat.EnableOuterShadowEffect();
                shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
                shape.EffectFormat.OuterShadowEffect.Direction = 45;
                shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(0, 0, 0);

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}