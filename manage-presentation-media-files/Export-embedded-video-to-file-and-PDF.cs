using System;
using System.IO;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputPdfPath = "output.pdf";

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.IVideoCollection videos = presentation.Videos;
                    for (int i = 0; i < videos.Count; i++)
                    {
                        Aspose.Slides.IVideo video = videos[i];
                        string contentType = video.ContentType; // e.g., "video/mp4"
                        string extension = "." + contentType.Split('/')[1];
                        string videoPath = $"video_{i}{extension}";
                        byte[] data = video.BinaryData;
                        File.WriteAllBytes(videoPath, data);
                    }

                    Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
                    presentation.Save(outputPdfPath, Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}