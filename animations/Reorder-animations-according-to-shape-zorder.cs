using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                Aspose.Slides.Animation.ISequence mainSeq = slide.Timeline.MainSequence;
                Aspose.Slides.IShapeCollection shapes = slide.Shapes;

                // Reorder animation effects to follow the Z‑order of shapes
                for (int i = 0; i < shapes.Count; i++)
                {
                    Aspose.Slides.IShape shape = shapes[i];
                    Aspose.Slides.Animation.IEffect[] effects = mainSeq.GetEffectsByShape(shape);
                    if (effects == null) continue;

                    foreach (Aspose.Slides.Animation.IEffect effect in effects)
                    {
                        // Remove the existing effect
                        mainSeq.Remove(effect);
                        // Re‑add the effect (simplified to a generic Appear effect)
                        mainSeq.AddEffect(shape,
                                          Aspose.Slides.Animation.EffectType.Appear,
                                          Aspose.Slides.Animation.EffectSubtype.None,
                                          Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                    }
                }
            }

            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}