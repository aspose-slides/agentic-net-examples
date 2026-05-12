using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Hide the slide
                slide.Hidden = true;

                // Set background to gradient
                pres.Slides[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                pres.Slides[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = Aspose.Slides.TileFlip.FlipBoth;

                // Save the presentation
                pres.Save("HiddenGradientSlide.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}