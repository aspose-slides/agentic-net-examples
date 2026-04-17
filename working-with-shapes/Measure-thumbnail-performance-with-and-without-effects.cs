using System;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ThumbnailPerformanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file paths
            string outputPptx = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ThumbnailPerformance.pptx");
            string outputPngNoEffect = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ShapeNoEffect.png");
            string outputPngEffect = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "ShapeWithEffect.png");

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
            shape.FillFormat.FillType = FillType.NoFill;

            // Measure thumbnail generation without effects
            Stopwatch swNoEffect = new Stopwatch();
            swNoEffect.Start();
            IImage shapeImageNoEffect = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
            swNoEffect.Stop();

            // Save the thumbnail image
            shapeImageNoEffect.Save(outputPngNoEffect, Aspose.Slides.ImageFormat.Png);

            // Apply an outer shadow effect
            shape.EffectFormat.EnableOuterShadowEffect();

            // Measure thumbnail generation with effects
            Stopwatch swEffect = new Stopwatch();
            swEffect.Start();
            IImage shapeImageEffect = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
            swEffect.Stop();

            // Save the thumbnail image with effect
            shapeImageEffect.Save(outputPngEffect, Aspose.Slides.ImageFormat.Png);

            // Output performance results
            Console.WriteLine("Thumbnail generation without effects: {0} ms", swNoEffect.ElapsedMilliseconds);
            Console.WriteLine("Thumbnail generation with effects: {0} ms", swEffect.ElapsedMilliseconds);

            // Save the presentation before exiting
            pres.Save(outputPptx, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}