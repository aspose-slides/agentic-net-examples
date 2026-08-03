// -----------------------------------------------------------------------------
// Example: Set audio frame hideatshowing based on transition using C#
//
// Description:
// Demonstrates how to set the HideAtShowing property of audio frames
// depending on the slide transition type (e.g., Fade) using Aspose.Slides for .NET.
// The example loads a PPTX, iterates through slides and shapes, updates the
// property, and saves the modified presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Audio, Frame, HideAtShowing,
// Transition, Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically hide audio frames when a slide uses a Fade transition.
// - Build tools that adjust media playback settings based on slide animations.
// - Process and transform PPTX files programmatically in .NET applications.
// - Validate and enforce presentation consistency before distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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
            using (Presentation pres = new Presentation(inputPath))
            {
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    ISlideShowTransition transition = slide.SlideShowTransition;
                    Aspose.Slides.SlideShow.TransitionType transitionType = (Aspose.Slides.SlideShow.TransitionType)transition.Type;

                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is AudioFrame)
                        {
                            AudioFrame audio = (AudioFrame)shape;
                            if (transitionType == Aspose.Slides.SlideShow.TransitionType.Fade)
                            {
                                audio.HideAtShowing = true;
                            }
                            else
                            {
                                audio.HideAtShowing = false;
                            }
                        }
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
