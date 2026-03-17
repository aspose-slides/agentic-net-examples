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
            // Input presentation path
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            // Directory to store extracted media
            string outputDir = Path.Combine(Environment.CurrentDirectory, "ExtractedMedia");
            Directory.CreateDirectory(outputDir);

            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            try
            {
                // Extract embedded audio files
                Aspose.Slides.IAudioCollection audioCollection = pres.Audios;
                for (int i = 0; i < audioCollection.Count; i++)
                {
                    Aspose.Slides.IAudio audio = audioCollection[i];
                    string audioExtension = GetExtensionFromContentType(audio.ContentType);
                    string audioFilePath = Path.Combine(outputDir, $"audio_{i}{audioExtension}");
                    File.WriteAllBytes(audioFilePath, audio.BinaryData);
                }

                // Extract embedded video files
                Aspose.Slides.IVideoCollection videoCollection = pres.Videos;
                for (int i = 0; i < videoCollection.Count; i++)
                {
                    Aspose.Slides.IVideo video = videoCollection[i];
                    string videoExtension = GetExtensionFromContentType(video.ContentType);
                    string videoFilePath = Path.Combine(outputDir, $"video_{i}{videoExtension}");
                    File.WriteAllBytes(videoFilePath, video.BinaryData);
                }

                // Save presentation to preserve structure
                string savedPath = Path.Combine(Environment.CurrentDirectory, "output_preserved.pptx");
                pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            finally
            {
                // Ensure resources are released
                pres.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Helper to derive file extension from MIME type
    private static string GetExtensionFromContentType(string contentType)
    {
        if (string.IsNullOrEmpty(contentType))
            return string.Empty;
        int slashPos = contentType.LastIndexOf('/');
        if (slashPos < 0 || slashPos == contentType.Length - 1)
            return string.Empty;
        return "." + contentType.Substring(slashPos + 1);
    }
}