using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ShapeThumbnailPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Output file paths
                string outputPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "ShapeThumbnailPerformance.pptx");
                string plainPngPath = Path.Combine(Directory.GetCurrentDirectory(), "PlainShape.png");
                string effectPngPath = Path.Combine(Directory.GetCurrentDirectory(), "EffectShape.png");

                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // -------------------- Plain shape (no effects) --------------------
                IAutoShape plainShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
                plainShape.FillFormat.FillType = FillType.NoFill;
                plainShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

                // Measure thumbnail generation time for plain shape
                Stopwatch plainStopwatch = new Stopwatch();
                plainStopwatch.Start();
                IImage plainImage = plainShape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f);
                plainStopwatch.Stop();

                // Save the thumbnail
                plainImage.Save(plainPngPath, Aspose.Slides.ImageFormat.Png);
                plainImage.Dispose();

                // -------------------- Shape with outer shadow effect --------------------
                IAutoShape effectShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 50, 200, 100);
                effectShape.FillFormat.FillType = FillType.NoFill;
                effectShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;
                // Apply outer shadow effect
                effectShape.EffectFormat.EnableOuterShadowEffect();
                effectShape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                effectShape.EffectFormat.OuterShadowEffect.Direction = 45;
                effectShape.EffectFormat.OuterShadowEffect.Distance = 5.0;
                effectShape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.FromArgb(0, 0, 0);

                // Measure thumbnail generation time for shape with effect
                Stopwatch effectStopwatch = new Stopwatch();
                effectStopwatch.Start();
                IImage effectImage = effectShape.GetImage(ShapeThumbnailBounds.Shape, 1.0f, 1.0f);
                effectStopwatch.Stop();

                // Save the thumbnail
                effectImage.Save(effectPngPath, Aspose.Slides.ImageFormat.Png);
                effectImage.Dispose();

                // Output performance results
                Console.WriteLine("Plain shape thumbnail generation time: {0} ms", plainStopwatch.ElapsedMilliseconds);
                Console.WriteLine("Effect shape thumbnail generation time: {0} ms", effectStopwatch.ElapsedMilliseconds);

                // Save the presentation
                pres.Save(outputPptxPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("File not found: " + fnfEx.Message);
            }
            catch (NotSupportedException nsEx)
            {
                // Format not supported
                Console.WriteLine("Format not supported: " + nsEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}