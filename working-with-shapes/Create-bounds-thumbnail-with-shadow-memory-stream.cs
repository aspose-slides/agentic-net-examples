using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths
            string outputPptxPath = "output.pptx";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

            // Apply solid fill
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;

            // Enable outer shadow effect
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
            shape.EffectFormat.OuterShadowEffect.Direction = 45;
            shape.EffectFormat.OuterShadowEffect.Distance = 5.0;
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.Gray;

            // Generate a thumbnail that includes shape appearance (shadows)
            IImage shapeThumbnail = shape.GetImage(ShapeThumbnailBounds.Appearance, 1f, 1f);

            // Store the thumbnail in a memory stream
            MemoryStream thumbnailStream = new MemoryStream();
            shapeThumbnail.Save(thumbnailStream, ImageFormat.Png);
            thumbnailStream.Position = 0; // Reset stream position for further use

            // Save the presentation before exiting
            pres.Save(outputPptxPath, SaveFormat.Pptx);
            pres.Dispose();

            // Optionally, you can use the thumbnailStream here (e.g., write to file, send over network, etc.)
            // For demonstration, write the thumbnail to a file
            using (FileStream file = new FileStream("shape_thumbnail.png", FileMode.Create, FileAccess.Write))
            {
                thumbnailStream.CopyTo(file);
            }

            // Clean up
            thumbnailStream.Dispose();
        }
    }
}