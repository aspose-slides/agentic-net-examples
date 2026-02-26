using System;
using System.IO;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Create output directory for extracted audio files
        string outputFolder = "ExtractedAudios";
        System.IO.Directory.CreateDirectory(outputFolder);

        // Get the collection of embedded audio files
        Aspose.Slides.IAudioCollection audioCollection = presentation.Audios;

        // Iterate through each audio and save it to a file
        for (int index = 0; index < audioCollection.Count; index++)
        {
            Aspose.Slides.IAudio audio = audioCollection[index];
            byte[] audioData = audio.BinaryData;
            string outputPath = System.IO.Path.Combine(outputFolder, $"audio_{index + 1}.mp3");
            System.IO.File.WriteAllBytes(outputPath, audioData);
        }

        // Save the presentation (unchanged) before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}