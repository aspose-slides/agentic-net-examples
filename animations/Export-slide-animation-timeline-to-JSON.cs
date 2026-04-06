using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AnimationTimelineExport
{
    class Program
    {
        static void Main()
        {
            var inputPath = "input.pptx";
            var outputJsonPath = "animation_timeline.json";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    var slidesData = new List<object>();

                    foreach (var slide in presentation.Slides)
                    {
                        var timeline = slide.Timeline; // IAnimationTimeLine
                        var mainSequence = timeline.MainSequence; // ISequence
                        var interactiveSequences = timeline.InteractiveSequences; // ISequenceCollection
                        var textAnimations = timeline.TextAnimationCollection; // ITextAnimationCollection

                        var slideInfo = new
                        {
                            SlideIndex = presentation.Slides.IndexOf(slide),
                            MainSequenceCount = mainSequence.Count,
                            InteractiveSequencesCount = interactiveSequences.Count,
                            TextAnimationsCount = textAnimations.Count
                        };

                        slidesData.Add(slideInfo);
                    }

                    var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                    var json = JsonSerializer.Serialize(slidesData, jsonOptions);
                    File.WriteAllText(outputJsonPath, json);

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}