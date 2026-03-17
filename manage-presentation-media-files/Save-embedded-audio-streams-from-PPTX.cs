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
            string inputPath = "input.pptx";
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Save the presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                int audioCount = presentation.Audios.Count;
                for (int i = 0; i < audioCount; i++)
                {
                    IAudio audio = presentation.Audios[i];
                    byte[] audioData = audio.BinaryData;
                    string contentType = audio.ContentType;
                    int slashIndex = contentType.LastIndexOf('/');
                    string extension = (slashIndex >= 0 && slashIndex < contentType.Length - 1) ? contentType.Substring(slashIndex + 1) : "bin";
                    string outputFile = $"audio_{i}.{extension}";
                    File.WriteAllBytes(outputFile, audioData);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}