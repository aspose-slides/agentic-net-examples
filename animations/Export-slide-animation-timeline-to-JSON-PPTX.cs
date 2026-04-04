using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                var slidesData = new List<object>();

                // Iterate through each slide
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    Aspose.Slides.IAnimationTimeLine timeline = presentation.Slides[i].Timeline;
                    Aspose.Slides.Animation.ISequence mainSequence = timeline.MainSequence;
                    var effectsData = new List<object>();

                    // Extract information from each effect in the main sequence
                    foreach (Aspose.Slides.Animation.IEffect effect in mainSequence)
                    {
                        var effectInfo = new
                        {
                            Type = effect.Type.ToString(),
                            Subtype = effect.Subtype.ToString(),
                            TriggerType = effect.Timing.TriggerType.ToString(),
                            Duration = effect.Timing.Duration
                        };
                        effectsData.Add(effectInfo);
                    }

                    var slideInfo = new
                    {
                        SlideIndex = i,
                        Effects = effectsData
                    };
                    slidesData.Add(slideInfo);
                }

                // Serialize the collected data to JSON
                string json = JsonSerializer.Serialize(slidesData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("animation_timeline.json", json);

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported file formats
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}