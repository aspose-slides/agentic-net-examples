using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputFolder = "AudioOutput";

                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.IAudioCollection audioCollection = presentation.Audios;
                    for (int i = 0; i < audioCollection.Count; i++)
                    {
                        Aspose.Slides.IAudio audio = audioCollection[i];
                        byte[] audioData = audio.BinaryData;
                        string extension = GetExtensionFromContentType(audio.ContentType);
                        string filePath = Path.Combine(outputFolder, $"audio_{i}{extension}");
                        File.WriteAllBytes(filePath, audioData);
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private static string GetExtensionFromContentType(string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
                return ".bin";

            switch (contentType.ToLower())
            {
                case "audio/mpeg":
                    return ".mp3";
                case "audio/wav":
                    return ".wav";
                case "audio/mp4":
                    return ".m4a";
                default:
                    return ".bin";
            }
        }
    }
}