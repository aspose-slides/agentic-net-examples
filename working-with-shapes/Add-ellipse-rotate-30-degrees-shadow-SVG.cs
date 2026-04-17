using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Ensure output directory exists
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        string svgPath = Path.Combine(outputDir, "ellipse.svg");
        string pptxPath = Path.Combine(outputDir, "ellipse.pptx");

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add an ellipse shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 75, 200, 100);

            // Set rotation to 30 degrees
            shape.Rotation = 30f;

            // Apply outer shadow effect
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
            shape.EffectFormat.OuterShadowEffect.Direction = 45f;
            shape.EffectFormat.OuterShadowEffect.Distance = 5.0;
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.FromArgb(128, 0, 0, 0);

            // Export the slide as SVG
            using (FileStream svgStream = File.Create(svgPath))
            {
                slide.WriteAsSvg(svgStream);
            }

            // Save the presentation as PPTX (optional)
            pres.Save(pptxPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}