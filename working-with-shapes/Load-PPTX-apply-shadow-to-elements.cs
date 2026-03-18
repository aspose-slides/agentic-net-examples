using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for input and output presentations
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            // Load the presentation
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Access the first slide
            var slide = presentation.Slides[0];

            // Get the first shape on the slide (adjust index as needed)
            var shape = slide.Shapes[0];

            // Enable outer shadow effect for the shape
            shape.EffectFormat.EnableOuterShadowEffect();

            // Configure outer shadow properties
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;          // Blur radius in points
            shape.EffectFormat.OuterShadowEffect.Distance = 10.0;          // Distance from the shape
            shape.EffectFormat.OuterShadowEffect.Direction = 45.0f;       // Direction in degrees
            shape.EffectFormat.OuterShadowEffect.RotateShadowWithShape = true; // Rotate with shape

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Output any errors that occur
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}