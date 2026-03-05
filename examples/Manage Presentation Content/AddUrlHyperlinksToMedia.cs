using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load audio file bytes (replace with actual path to your audio file)
        byte[] audioData = File.ReadAllBytes("audio.mp3");

        // Add audio to the presentation
        Aspose.Slides.IAudio audio = presentation.Audios.AddAudio(audioData);

        // Add an audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

        // Set an external hyperlink on click for the audio frame
        audioFrame.HyperlinkClick = new Aspose.Slides.Hyperlink("https://www.aspose.com/");

        // Optionally set a tooltip for the hyperlink
        audioFrame.HyperlinkClick.Tooltip = "Visit Aspose website";

        // Save the presentation
        presentation.Save("MediaHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}