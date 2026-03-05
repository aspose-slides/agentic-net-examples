using System;
using System.IO;

namespace AsposeSlidesSoundExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Load audio file into a byte array
            byte[] audioData = File.ReadAllBytes("sample.mp3");

            // Add the audio to the presentation's audio collection
            Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioData);

            // Get the first slide (a new presentation contains one empty slide)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Assign the audio to the slide transition and set a display name
            slide.SlideShowTransition.Sound = audio;
            slide.SlideShowTransition.SoundName = "Sample Sound";

            // Save the presentation in PPTX format
            presentation.Save("SoundPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}