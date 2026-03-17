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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Buffer for streaming video data
            byte[] buffer = new byte[8 * 1024];

            // Iterate through all embedded videos
            for (int index = 0; index < presentation.Videos.Count; index++)
            {
                Aspose.Slides.IVideo video = presentation.Videos[index];

                // Determine file extension from the video's content type
                string contentType = video.ContentType;
                int slashPos = contentType.LastIndexOf('/');
                string extension = contentType.Substring(slashPos + 1);

                // Build output file name
                string outputPath = $"video{index}.{extension}";

                // Write video data to file using streaming to avoid high memory usage
                using (Stream videoStream = video.GetStream())
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    int bytesRead;
                    while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }

            // Save the presentation (if any changes were made)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}