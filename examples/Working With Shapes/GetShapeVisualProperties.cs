using System;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("sample.pptx");

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Get the first shape on the slide
            Aspose.Slides.IShape shape = slide.Shapes[0];

            // ----- Effective Effect Format -----
            Aspose.Slides.IEffectFormatEffectiveData effectiveEffect = shape.EffectFormat.GetEffective();

            if (effectiveEffect.IsNoEffects)
            {
                Console.WriteLine("The shape has no effects applied.");
            }
            else
            {
                if (effectiveEffect.BlurEffect != null)
                    Console.WriteLine("Blur effect radius: " + effectiveEffect.BlurEffect.Radius);
                if (effectiveEffect.FillOverlayEffect != null)
                    Console.WriteLine("Fill overlay effect fill type: " + effectiveEffect.FillOverlayEffect.FillFormat.FillType);
                if (effectiveEffect.GlowEffect != null)
                    Console.WriteLine("Glow effect color: " + effectiveEffect.GlowEffect.Color);
                if (effectiveEffect.InnerShadowEffect != null)
                    Console.WriteLine("Inner shadow color: " + effectiveEffect.InnerShadowEffect.ShadowColor);
                if (effectiveEffect.OuterShadowEffect != null)
                    Console.WriteLine("Outer shadow color: " + effectiveEffect.OuterShadowEffect.ShadowColor);
                if (effectiveEffect.PresetShadowEffect != null)
                    Console.WriteLine("Preset shadow color: " + effectiveEffect.PresetShadowEffect.ShadowColor);
                if (effectiveEffect.ReflectionEffect != null)
                    Console.WriteLine("Reflection effect distance: " + effectiveEffect.ReflectionEffect.Distance);
                if (effectiveEffect.SoftEdgeEffect != null)
                    Console.WriteLine("Soft edge radius: " + effectiveEffect.SoftEdgeEffect.Radius);
            }

            // ----- Effective Line Format -----
            Aspose.Slides.ILineFormatEffectiveData effectiveLine = shape.LineFormat.GetEffective();

            Console.WriteLine("Line style: " + effectiveLine.Style);
            Console.WriteLine("Line width: " + effectiveLine.Width);
            if (effectiveLine.FillFormat != null)
                Console.WriteLine("Line fill type: " + effectiveLine.FillFormat.FillType);

            // ----- Effective 3D Format (if available) -----
            if (shape.ThreeDFormat != null)
            {
                Aspose.Slides.IThreeDFormatEffectiveData effective3D = shape.ThreeDFormat.GetEffective();

                if (effective3D.Camera != null)
                {
                    Console.WriteLine("Camera type: " + effective3D.Camera.CameraType);
                    Console.WriteLine("Camera field of view: " + effective3D.Camera.FieldOfViewAngle);
                    Console.WriteLine("Camera zoom: " + effective3D.Camera.Zoom);
                }

                if (effective3D.LightRig != null)
                {
                    Console.WriteLine("Light rig type: " + effective3D.LightRig.LightType);
                    Console.WriteLine("Light rig direction: " + effective3D.LightRig.Direction);
                }

                if (effective3D.BevelTop != null)
                {
                    Console.WriteLine("Top bevel type: " + effective3D.BevelTop.BevelType);
                    Console.WriteLine("Top bevel width: " + effective3D.BevelTop.Width);
                    Console.WriteLine("Top bevel height: " + effective3D.BevelTop.Height);
                }
            }

            // ----- Effective Background (slide level) -----
            Aspose.Slides.IBackgroundEffectiveData effectiveBackground = slide.Background.GetEffective();

            if (effectiveBackground.FillFormat != null)
                Console.WriteLine("Background fill type: " + effectiveBackground.FillFormat.FillType);
            Console.WriteLine("Background has effects: " + (!effectiveBackground.EffectFormat.IsNoEffects));

            // Save the presentation (even if unchanged)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}