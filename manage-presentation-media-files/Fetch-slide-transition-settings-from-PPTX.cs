using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideTransitionInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPath = "output.pptx";

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                int slideCount = presentation.Slides.Count;
                for (int i = 0; i < slideCount; i++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[i];
                    Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;

                    Aspose.Slides.SlideShow.TransitionType type = transition.Type;
                    int duration = transition.Duration;
                    bool advanceOnClick = transition.AdvanceOnClick;
                    uint advanceAfterTime = transition.AdvanceAfterTime;

                    Console.WriteLine("Slide {0}:", i + 1);
                    Console.WriteLine("  Transition Type: {0}", type);
                    Console.WriteLine("  Duration (ms): {0}", duration);
                    Console.WriteLine("  Advance On Click: {0}", advanceOnClick);
                    Console.WriteLine("  Advance After Time (ms): {0}", advanceAfterTime);
                }

                // Save the presentation (even if unchanged)
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}