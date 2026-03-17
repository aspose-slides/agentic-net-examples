using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var inputPath = "input.pptx";
            using (var pres = new Aspose.Slides.Presentation(inputPath))
            {
                var buffer = new byte[8 * 1024];
                for (int i = 0; i < pres.Videos.Count; i++)
                {
                    var video = pres.Videos[i];
                    var extension = GetExtensionFromContentType(video.ContentType);
                    var outputPath = $"video{i}{extension}";
                    using (var videoStream = video.GetStream())
                    using (var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        int bytesRead;
                        while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
                // Save the presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Maps MIME content type to a file extension
    private static string GetExtensionFromContentType(string contentType)
    {
        if (string.IsNullOrEmpty(contentType))
            return ".bin";

        var slashIndex = contentType.LastIndexOf('/');
        if (slashIndex >= 0 && slashIndex < contentType.Length - 1)
        {
            var type = contentType.Substring(slashIndex + 1);
            return "." + type;
        }
        return ".bin";
    }
}