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
            // Load the presentation
            Presentation presentation = new Presentation("input.pptx");

            // Iterate through all embedded audio files
            for (int i = 0; i < presentation.Audios.Count; i++)
            {
                IAudio audio = presentation.Audios[i];

                // Get binary data of the audio
                byte[] audioData = audio.BinaryData;

                // Determine file extension from content type (e.g., "audio/mpeg" -> ".mpeg")
                string contentType = audio.ContentType;
                string extension = ".bin";
                if (!string.IsNullOrEmpty(contentType))
                {
                    int slashIndex = contentType.IndexOf('/');
                    if (slashIndex >= 0 && slashIndex < contentType.Length - 1)
                    {
                        string extPart = contentType.Substring(slashIndex + 1);
                        // Simple mapping for common types
                        if (extPart.Equals("mpeg", StringComparison.OrdinalIgnoreCase))
                            extension = ".mp3";
                        else if (extPart.Equals("wav", StringComparison.OrdinalIgnoreCase))
                            extension = ".wav";
                        else if (extPart.Equals("ogg", StringComparison.OrdinalIgnoreCase))
                            extension = ".ogg";
                        else
                            extension = "." + extPart;
                    }
                }

                // Save the audio file
                string outputPath = $"audio_{i}{extension}";
                File.WriteAllBytes(outputPath, audioData);
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