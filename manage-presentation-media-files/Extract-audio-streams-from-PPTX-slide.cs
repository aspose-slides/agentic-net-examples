using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AudioExtractionDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                var inputPath = "input.pptx";
                var outputPath = "output.pptx";

                using (var presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        var slide = presentation.Slides[slideIndex];
                        var effectsSequence = slide.Timeline.MainSequence;

                        var effectIndex = 0;
                        foreach (var effect in effectsSequence)
                        {
                            if (effect.Sound == null)
                            {
                                effectIndex++;
                                continue;
                            }

                            var audio = effect.Sound;
                            var audioData = audio.BinaryData;
                            var contentType = audio.ContentType?.ToLowerInvariant() ?? string.Empty;

                            var extension = ".bin";
                            if (contentType.Contains("audio/mpeg"))
                                extension = ".mp3";
                            else if (contentType.Contains("audio/wav"))
                                extension = ".wav";
                            else if (contentType.Contains("audio/ogg"))
                                extension = ".ogg";
                            else if (contentType.Contains("audio/mp4"))
                                extension = ".m4a";

                            var fileName = $"slide_{slideIndex + 1}_effect_{effectIndex + 1}{extension}";
                            File.WriteAllBytes(fileName, audioData);

                            effectIndex++;
                        }
                    }

                    // Save the (unchanged) presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}