using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailWithShadow
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle auto shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);

            // Apply outer shadow effect to the shape
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
            shape.EffectFormat.OuterShadowEffect.Direction = 45;
            shape.EffectFormat.OuterShadowEffect.Distance = 5.0;
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.FromArgb(0, 0, 0);

            // Generate a thumbnail that includes the shape's appearance (shadows)
            IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Appearance, 1f, 1f);

            // Store the thumbnail in a memory stream
            using (MemoryStream thumbnailStream = new MemoryStream())
            {
                shapeImage.Save(thumbnailStream, Aspose.Slides.ImageFormat.Png);
                // The thumbnailStream now contains the PNG image data
                // (Further processing can be done here)
            }

            // Save the presentation to a file before exiting
            pres.Save("output.pptx", SaveFormat.Pptx);

            // Clean up
            pres.Dispose();
        }
    }
}