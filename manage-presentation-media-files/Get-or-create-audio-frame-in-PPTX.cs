using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load an audio file stream (ensure the file exists at the specified path)
            using (FileStream audioStream = new FileStream("sample.wav", FileMode.Open, FileAccess.Read))
            {
                // Add an embedded audio frame to the slide
                Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
                // Set audio playback properties
                audioFrame.PlayMode = Aspose.Slides.AudioPlayModePreset.Auto;
                audioFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
            }

            // Retrieve the added audio frame (first shape on the slide)
            Aspose.Slides.IAudioFrame retrievedAudioFrame = (Aspose.Slides.IAudioFrame)slide.Shapes[0];
            // Modify a property of the retrieved audio frame
            retrievedAudioFrame.HideAtShowing = true;

            // Save the presentation
            presentation.Save("AudioFrameExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}