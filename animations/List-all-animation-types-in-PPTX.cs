using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var filePath = "input.pptx";
            using (var presentation = new Presentation(filePath))
            {
                var animationTypes = new System.Collections.Generic.HashSet<EffectType>();
                foreach (var slide in presentation.Slides)
                {
                    var mainSeq = slide.Timeline.MainSequence;
                    foreach (var effect in mainSeq)
                    {
                        animationTypes.Add(effect.Type);
                    }

                    foreach (var seq in slide.Timeline.InteractiveSequences)
                    {
                        foreach (var effect in seq)
                        {
                            animationTypes.Add(effect.Type);
                        }
                    }
                }

                Console.WriteLine("Animation types in presentation:");
                foreach (var type in animationTypes)
                {
                    Console.WriteLine(type);
                }

                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}