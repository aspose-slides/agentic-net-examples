using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the transition sound
        Aspose.Slides.IAudio transitionAudio = slide.SlideShowTransition.Sound;

        if (transitionAudio != null)
        {
            // Extract binary data of the sound
            byte[] audioData = transitionAudio.BinaryData;

            // Save the audio to a file
            File.WriteAllBytes("transitionSound.wav", audioData);
        }

        // Save the presentation before exit
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}