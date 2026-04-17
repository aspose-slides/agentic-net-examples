using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Presentation presentation = null;
        try
        {
            // Load presentation
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Ensure there is at least one shape
        if (slide.Shapes.Count == 0)
        {
            Console.WriteLine("No shapes found on the slide.");
            // Save unchanged presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            return;
        }

        // Work with the first shape
        IShape shape = slide.Shapes[0];

        // Enable outer shadow effect if not already enabled
        shape.EffectFormat.EnableOuterShadowEffect();

        // Read current blur radius
        double currentBlur = shape.EffectFormat.OuterShadowEffect.BlurRadius;

        // Modify blur radius (increase by 2.0 points)
        shape.EffectFormat.OuterShadowEffect.BlurRadius = currentBlur + 2.0;

        // Save the updated presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}