using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Define output file path
        string outputPath = "GradientBackground.pptx";

        // Set background to gradient on the first slide
        pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
        pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
        pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

        // Set custom linear gradient angle (in degrees)
        pres.Slides[0].Background.FillFormat.GradientFormat.LinearGradientAngle = 45f;

        // Add gradient stops with custom colors
        pres.Slides[0].Background.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Purple);
        pres.Slides[0].Background.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Red);

        // Save the presentation
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}