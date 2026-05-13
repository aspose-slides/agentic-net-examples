using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddEllipseLineCapRoundToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add an ellipse shape
                    IAutoShape ellipse = slide.Shapes.AddAutoShape(
                        ShapeType.Ellipse, 100, 100, 300, 200);

                    // Set line cap style to round
                    ellipse.LineFormat.CapStyle = LineCapStyle.Round;

                    // Enable and configure glow effect
                    ellipse.EffectFormat.EnableGlowEffect();
                    ellipse.EffectFormat.GlowEffect.Radius = 5.0;

                    // Save the presentation as TIFF
                    presentation.Save("EllipseWithGlow.tiff", SaveFormat.Tiff);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file I/O)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}