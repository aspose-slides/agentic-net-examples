using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace GetEffectiveShapeVisualProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.IShape shape = slide.Shapes[0];

                // Effective Fill Format
                Aspose.Slides.IFillFormatEffectiveData fillEff = shape.FillFormat.GetEffective();
                Console.WriteLine("=== Effective Fill Format ===");
                Console.WriteLine("Fill Type: " + fillEff.FillType);
                if (fillEff.FillType == Aspose.Slides.FillType.Solid)
                {
                    Console.WriteLine("Solid Fill Color: " + fillEff.SolidFillColor);
                }
                else if (fillEff.FillType == Aspose.Slides.FillType.Pattern)
                {
                    Console.WriteLine("Pattern Style: " + fillEff.PatternFormat.PatternStyle);
                    Console.WriteLine("Fore Color: " + fillEff.PatternFormat.ForeColor);
                    Console.WriteLine("Back Color: " + fillEff.PatternFormat.BackColor);
                }
                else if (fillEff.FillType == Aspose.Slides.FillType.Gradient)
                {
                    Console.WriteLine("Gradient Direction: " + fillEff.GradientFormat.GradientDirection);
                    Console.WriteLine("Gradient Stops Count: " + fillEff.GradientFormat.GradientStops.Count);
                }
                else if (fillEff.FillType == Aspose.Slides.FillType.Picture)
                {
                    Console.WriteLine("Picture Width: " + fillEff.PictureFillFormat.Picture.Image.Width);
                    Console.WriteLine("Picture Height: " + fillEff.PictureFillFormat.Picture.Image.Height);
                }

                // Effective Effect Format
                Aspose.Slides.IEffectFormatEffectiveData effectEff = shape.EffectFormat.GetEffective();
                Console.WriteLine("\n=== Effective Effect Format ===");
                Console.WriteLine("Is No Effects: " + effectEff.IsNoEffects);
                if (effectEff.BlurEffect != null)
                {
                    Console.WriteLine("Blur Effect Radius: " + effectEff.BlurEffect.Radius);
                }
                if (effectEff.FillOverlayEffect != null)
                {
                    Console.WriteLine("Fill Overlay Fill Type: " + effectEff.FillOverlayEffect.FillFormat.FillType);
                }
                if (effectEff.GlowEffect != null)
                {
                    Console.WriteLine("Glow Effect Color: " + effectEff.GlowEffect.Color);
                }
                if (effectEff.InnerShadowEffect != null)
                {
                    Console.WriteLine("Inner Shadow Color: " + effectEff.InnerShadowEffect.ShadowColor);
                }
                if (effectEff.OuterShadowEffect != null)
                {
                    Console.WriteLine("Outer Shadow Color: " + effectEff.OuterShadowEffect.ShadowColor);
                }
                if (effectEff.PresetShadowEffect != null)
                {
                    Console.WriteLine("Preset Shadow Color: " + effectEff.PresetShadowEffect.ShadowColor);
                }
                if (effectEff.ReflectionEffect != null)
                {
                    Console.WriteLine("Reflection Distance: " + effectEff.ReflectionEffect.Distance);
                }
                if (effectEff.SoftEdgeEffect != null)
                {
                    Console.WriteLine("Soft Edge Radius: " + effectEff.SoftEdgeEffect.Radius);
                }

                // Effective Line Format
                Aspose.Slides.ILineFormatEffectiveData lineEff = shape.LineFormat.GetEffective();
                Console.WriteLine("\n=== Effective Line Format ===");
                Console.WriteLine("Line Style: " + lineEff.Style);
                Console.WriteLine("Line Width: " + lineEff.Width);
                Console.WriteLine("Line Fill Type: " + lineEff.FillFormat.FillType);

                // Effective 3D Format
                Aspose.Slides.IThreeDFormatEffectiveData threeDEff = shape.ThreeDFormat.GetEffective();
                Console.WriteLine("\n=== Effective 3D Format ===");
                Console.WriteLine("Camera Type: " + threeDEff.Camera.CameraType);
                Console.WriteLine("Camera Field of View: " + threeDEff.Camera.FieldOfViewAngle);
                Console.WriteLine("Camera Zoom: " + threeDEff.Camera.Zoom);
                Console.WriteLine("Light Rig Type: " + threeDEff.LightRig.LightType);
                Console.WriteLine("Light Rig Direction: " + threeDEff.LightRig.Direction);
                Console.WriteLine("Bevel Top Type: " + threeDEff.BevelTop.BevelType);
                Console.WriteLine("Bevel Top Width: " + threeDEff.BevelTop.Width);
                Console.WriteLine("Bevel Top Height: " + threeDEff.BevelTop.Height);
                Console.WriteLine("Bevel Bottom Type: " + threeDEff.BevelBottom.BevelType);
                Console.WriteLine("Bevel Bottom Width: " + threeDEff.BevelBottom.Width);
                Console.WriteLine("Bevel Bottom Height: " + threeDEff.BevelBottom.Height);
                Console.WriteLine("Extrusion Height: " + threeDEff.ExtrusionHeight);
                Console.WriteLine("Extrusion Color: " + threeDEff.ExtrusionColor);
                Console.WriteLine("Contour Color: " + threeDEff.ContourColor);
                Console.WriteLine("Depth: " + threeDEff.Depth);
                Console.WriteLine("Material: " + threeDEff.Material);

                // Save the presentation before exit
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}