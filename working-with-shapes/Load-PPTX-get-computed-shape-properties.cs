using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LoadPptxGetComputedShapeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                Aspose.Slides.ISlideCollection slides = presentation.Slides;
                for (int slideIndex = 0; slideIndex < slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = slides[slideIndex];
                    Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                    for (int shapeIndex = 0; shapeIndex < shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = shapes[shapeIndex];

                        // Effective Fill Format
                        Aspose.Slides.IFillFormat fillFormat = shape.FillFormat;
                        if (fillFormat != null)
                        {
                            Aspose.Slides.IFillFormatEffectiveData effectiveFill = fillFormat.GetEffective();
                            Console.WriteLine("Shape [{0},{1}] Fill Type: {2}", slideIndex, shapeIndex, effectiveFill.FillType);
                            if (effectiveFill.FillType == Aspose.Slides.FillType.Solid)
                            {
                                System.Drawing.Color solidColor = effectiveFill.SolidFillColor;
                                Console.WriteLine("  Solid Fill Color: {0}", solidColor);
                            }
                        }

                        // Effective Effect Format (Outer Shadow)
                        Aspose.Slides.IEffectFormat effectFormat = shape.EffectFormat;
                        if (effectFormat != null)
                        {
                            Aspose.Slides.IEffectFormatEffectiveData effectiveEffect = effectFormat.GetEffective();
                            if (effectiveEffect.OuterShadowEffect != null)
                            {
                                System.Drawing.Color shadowColor = effectiveEffect.OuterShadowEffect.ShadowColor;
                                Console.WriteLine("  Outer Shadow Color: {0}", shadowColor);
                            }
                        }

                        // Effective Three‑D Format (Extrusion Color)
                        Aspose.Slides.IThreeDFormat threeDFormat = shape.ThreeDFormat;
                        if (threeDFormat != null)
                        {
                            Aspose.Slides.IThreeDFormatEffectiveData effectiveThreeD = threeDFormat.GetEffective();
                            System.Drawing.Color extrusionColor = effectiveThreeD.ExtrusionColor;
                            Console.WriteLine("  Extrusion Color: {0}", extrusionColor);
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}