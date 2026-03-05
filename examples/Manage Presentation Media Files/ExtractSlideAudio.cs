using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "slideAudio.wav";

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        Aspose.Slides.ISlide slide = pres.Slides[0];
        Aspose.Slides.ISlideShowTransition transition = slide.SlideShowTransition;
        byte[] audio = transition.Sound != null ? transition.Sound.BinaryData : null;
        if (audio != null && audio.Length > 0)
        {
            File.WriteAllBytes(outputPath, audio);
        }

        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}