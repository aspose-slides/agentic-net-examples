using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AudioExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Get the collection of embedded audio files
                Aspose.Slides.IAudioCollection audioCollection = presentation.Audios;

                // Iterate through each audio and save it to a file
                for (int index = 0; index < audioCollection.Count; index++)
                {
                    Aspose.Slides.IAudio audio = audioCollection[index];

                    // Retrieve binary data of the audio
                    byte[] audioData = audio.BinaryData;

                    // Determine file extension based on content type
                    string contentType = audio.ContentType;
                    string extension = ".bin";

                    if (!string.IsNullOrEmpty(contentType))
                    {
                        if (contentType.Contains("mpeg"))
                        {
                            extension = ".mp3";
                        }
                        else if (contentType.Contains("wav"))
                        {
                            extension = ".wav";
                        }
                        else if (contentType.Contains("mp4"))
                        {
                            extension = ".mp4";
                        }
                    }

                    // Build output file name
                    string outputFileName = $"audio_{index}{extension}";

                    // Write the audio bytes to disk
                    File.WriteAllBytes(outputFileName, audioData);
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}