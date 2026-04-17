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