using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractTransitionAudio
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputAudioPath = "slideTransitionAudio.mp3";

                using (Presentation presentation = new Presentation(inputPath))
                {
                    int slideIndex = 0;
                    if (slideIndex < 0 || slideIndex >= presentation.Slides.Count)
                    {
                        Console.WriteLine("Invalid slide index.");
                        return;
                    }

                    ISlide slide = presentation.Slides[slideIndex];
                    IAudio transitionAudio = slide.SlideShowTransition.Sound;

                    if (transitionAudio != null && transitionAudio.BinaryData != null)
                    {
                        byte[] audioBytes = transitionAudio.BinaryData;
                        File.WriteAllBytes(outputAudioPath, audioBytes);
                        Console.WriteLine("Audio extracted to " + outputAudioPath);
                    }
                    else
                    {
                        Console.WriteLine("No transition audio found on the specified slide.");
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}