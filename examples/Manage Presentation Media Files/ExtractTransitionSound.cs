using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths to the input presentation, extracted audio, and output presentation
        string inputPath = "input.pptx";
        string outputAudioPath = "transition_sound.wav";
        string outputPresPath = "output.pptx";

        // Load the presentation
        Presentation pres = new Presentation(inputPath);

        // Access the first slide (adjust index as needed)
        ISlide slide = pres.Slides[0];

        // Retrieve the slide show transition object
        ISlideShowTransition transition = slide.SlideShowTransition;

        // Extract the embedded transition sound, if any
        IAudio audio = transition.Sound;
        if (audio != null && audio.BinaryData != null)
        {
            File.WriteAllBytes(outputAudioPath, audio.BinaryData);
        }

        // Save the (potentially unchanged) presentation before exiting
        pres.Save(outputPresPath, SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}