using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the input presentation
            string inputPath = "input.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // List to store raw audio byte arrays
            List<byte[]> audioByteArrays = new List<byte[]>();

            // Iterate through all embedded audios
            for (int index = 0; index < presentation.Audios.Count; index++)
            {
                Aspose.Slides.IAudio audio = presentation.Audios[index];

                // Retrieve the raw bytes of the audio
                byte[] audioData = audio.BinaryData;

                // Store the byte array
                audioByteArrays.Add(audioData);

                // Optional: write each audio to a file using its content type for extension
                string extension = GetExtensionFromContentType(audio.ContentType);
                string outputFile = $"audio_{index}{extension}";
                File.WriteAllBytes(outputFile, audioData);
            }

            // Save the (unchanged) presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    // Helper method to map MIME types to file extensions
    private static string GetExtensionFromContentType(string contentType)
    {
        if (contentType == "audio/mpeg")
            return ".mp3";
        if (contentType == "audio/wav")
            return ".wav";
        if (contentType == "audio/ogg")
            return ".ogg";
        // Default binary extension if type is unknown
        return ".bin";
    }
}