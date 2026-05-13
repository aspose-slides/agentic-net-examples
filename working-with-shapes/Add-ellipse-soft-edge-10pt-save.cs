using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define output directory and file
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
        string outputPath = Path.Combine(outputDir, "SoftEdgeEllipse.pptx");

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Ellipse,
            100,   // X position
            100,   // Y position
            300,   // Width
            200    // Height
        );

        // Apply soft edge effect with radius 10 points
        ellipse.EffectFormat.EnableSoftEdgeEffect();
        ellipse.EffectFormat.SoftEdgeEffect.Radius = 10;

        // Save the presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported or other save errors
        }
    }
}