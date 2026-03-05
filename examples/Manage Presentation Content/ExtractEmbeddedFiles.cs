using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation with default load options
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DeleteEmbeddedBinaryObjects = false;
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.ppt", loadOptions);

        // Extract embedded videos
        int videoCount = presentation.Videos.Count;
        for (int i = 0; i < videoCount; i++)
        {
            Aspose.Slides.IVideo video = presentation.Videos[i];
            using (Stream videoStream = video.GetStream())
            {
                string contentType = video.ContentType;
                int slashIndex = contentType.LastIndexOf('/');
                string extension = contentType.Substring(slashIndex + 1);
                string outputPath = $"video_{i}.{extension}";
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        // Extract embedded audios
        int audioCount = presentation.Audios.Count;
        for (int i = 0; i < audioCount; i++)
        {
            Aspose.Slides.IAudio audio = presentation.Audios[i];
            using (Stream audioStream = audio.GetStream())
            {
                string contentType = audio.ContentType;
                int slashIndex = contentType.LastIndexOf('/');
                string extension = contentType.Substring(slashIndex + 1);
                string outputPath = $"audio_{i}.{extension}";
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[8192];
                    int bytesRead;
                    while ((bytesRead = audioStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        // Save the presentation (no modifications made)
        presentation.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt);
        presentation.Dispose();
    }
}