using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Path to the audio file
                    string audioPath = "audio.mp3";

                    // Ensure the audio is added only once
                    Aspose.Slides.IAudioCollection audioCollection = presentation.Audios;
                    if (audioCollection.Count == 0 && File.Exists(audioPath))
                    {
                        byte[] audioData = File.ReadAllBytes(audioPath);
                        Aspose.Slides.IAudio audio = audioCollection.AddAudio(audioData);
                    }

                    // Save the presentation
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}