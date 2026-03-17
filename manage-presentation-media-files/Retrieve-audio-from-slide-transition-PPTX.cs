using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionAudioExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
                int slideCount = presentation.Slides.Count;

                for (int i = 0; i < slideCount; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;
                    Aspose.Slides.IAudio audio = transition.Sound;

                    if (audio != null)
                    {
                        byte[] audioData = audio.BinaryData;
                        string fileName = "Slide" + (i + 1) + "_TransitionSound.wav";
                        File.WriteAllBytes(fileName, audioData);
                    }
                }

                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}