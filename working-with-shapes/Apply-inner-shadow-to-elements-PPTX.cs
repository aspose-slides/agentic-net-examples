using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load the presentation
                var presentationPath = "input.pptx";
                var presentation = new Aspose.Slides.Presentation(presentationPath);

                // Get the first slide
                var slide = presentation.Slides[0];

                // Get the first shape on the slide (ensure it exists)
                var shape = slide.Shapes[0];

                // Enable inner shadow effect for the shape
                shape.EffectFormat.EnableInnerShadowEffect();

                // Configure inner shadow properties
                var innerShadow = shape.EffectFormat.InnerShadowEffect;
                innerShadow.BlurRadius = 5.0;          // Blur radius in points
                innerShadow.Direction = 45.0f;        // Direction in degrees
                innerShadow.Distance = 3.0;           // Distance in points

                // Save the modified presentation
                var outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}