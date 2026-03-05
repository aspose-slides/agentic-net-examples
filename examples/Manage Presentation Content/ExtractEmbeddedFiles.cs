using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Extract embedded audio files
        for (int i = 0; i < presentation.Audios.Count; i++)
        {
            Aspose.Slides.IAudio audio = presentation.Audios[i];
            using (Stream audioStream = audio.GetStream())
            {
                using (FileStream fileStream = new FileStream($"audio{i}.bin", FileMode.Create, FileAccess.Write))
                {
                    audioStream.CopyTo(fileStream);
                }
            }
        }

        // Extract embedded video files
        for (int i = 0; i < presentation.Videos.Count; i++)
        {
            Aspose.Slides.IVideo video = presentation.Videos[i];
            using (Stream videoStream = video.GetStream())
            {
                using (FileStream fileStream = new FileStream($"video{i}.bin", FileMode.Create, FileAccess.Write))
                {
                    videoStream.CopyTo(fileStream);
                }
            }
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}