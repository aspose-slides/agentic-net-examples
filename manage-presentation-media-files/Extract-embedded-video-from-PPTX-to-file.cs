using System;
using System.IO;
using Aspose.Slides.Export;

namespace ExtractVideo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string presentationPath = "input.pptx";
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    byte[] buffer = new byte[8 * 1024];
                    for (int index = 0; index < presentation.Videos.Count; index++)
                    {
                        Aspose.Slides.IVideo video = presentation.Videos[index];
                        string contentType = video.ContentType;
                        int slashPos = contentType.LastIndexOf('/');
                        string extension = contentType.Substring(slashPos + 1);
                        string outputPath = $"video{index}.{extension}";
                        using (Stream videoStream = video.GetStream())
                        {
                            using (FileStream fileStream = File.OpenWrite(outputPath))
                            {
                                int bytesRead;
                                while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fileStream.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }
                    // Save the presentation before exiting
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}