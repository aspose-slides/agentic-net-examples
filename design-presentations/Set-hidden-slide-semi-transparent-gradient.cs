using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SetHiddenSlideGradient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Ensure there is at least one slide
            ISlide slide = pres.Slides[0];

            // Hide the slide
            slide.Hidden = true;

            // Set background to own background with gradient fill
            slide.Background.Type = BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = FillType.Gradient;
            slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

            // Define semi‑transparent gradient stops
            // First stop: semi‑transparent blue at offset 0%
            slide.Background.FillFormat.GradientFormat.GradientStops.Add(0.0f, Color.FromArgb(128, Color.Blue));
            // Second stop: semi‑transparent green at offset 100%
            slide.Background.FillFormat.GradientFormat.GradientStops.Add(1.0f, Color.FromArgb(128, Color.Green));

            // Save the presentation
            string outputPath = "HiddenSlideGradient.pptx";
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported.
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}