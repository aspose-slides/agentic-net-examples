using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape to the slide
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

            // Apply outer shadow effect to the shape
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
            shape.EffectFormat.OuterShadowEffect.Direction = 45;
            shape.EffectFormat.OuterShadowEffect.Distance = 5.0;
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.FromArgb(0, 0, 0);

            // Generate a thumbnail that includes the shape's appearance (shadows)
            IImage thumbnail = shape.GetImage(ShapeThumbnailBounds.Appearance, 1.0f, 1.0f);

            // Store the thumbnail in a memory stream as PNG
            using (MemoryStream ms = new MemoryStream())
            {
                thumbnail.Save(ms, Aspose.Slides.ImageFormat.Png);
                // The memory stream now contains the PNG image data
            }

            // Save the presentation before exiting
            string outputPath = "output.pptx";
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The requested format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}