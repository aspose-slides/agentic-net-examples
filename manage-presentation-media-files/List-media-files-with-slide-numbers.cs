using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ListMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string presentationPath = "input.pptx";

            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath))
                {
                    // List videos and the slides they appear on
                    for (int v = 0; v < pres.Videos.Count; v++)
                    {
                        Aspose.Slides.IVideo video = pres.Videos[v];

                        // Derive a file name from the content type (e.g., "video/mp4")
                        string contentType = video.ContentType;
                        string extension = "";
                        int slashIndex = contentType.LastIndexOf('/');
                        if (slashIndex >= 0 && slashIndex < contentType.Length - 1)
                        {
                            extension = contentType.Substring(slashIndex + 1);
                        }
                        string videoFileName = $"video{v}.{extension}";

                        // Find slide numbers that contain this video
                        List<int> slideNumbers = new List<int>();
                        for (int s = 0; s < pres.Slides.Count; s++)
                        {
                            Aspose.Slides.ISlide slide = pres.Slides[s];
                            foreach (Aspose.Slides.IShape shape in slide.Shapes)
                            {
                                Aspose.Slides.IVideoFrame videoFrame = shape as Aspose.Slides.IVideoFrame;
                                if (videoFrame != null && videoFrame.EmbeddedVideo == video)
                                {
                                    slideNumbers.Add(s + 1); // Slides are 1‑based for display
                                }
                            }
                        }

                        Console.WriteLine($"Video: {videoFileName}");
                        if (slideNumbers.Count > 0)
                        {
                            Console.WriteLine("Appears on slides: " + string.Join(", ", slideNumbers));
                        }
                        else
                        {
                            Console.WriteLine("Not used on any slide.");
                        }
                    }

                    // List audios (slide numbers omitted due to lack of IAudioFrame in the API)
                    for (int a = 0; a < pres.Audios.Count; a++)
                    {
                        Aspose.Slides.IAudio audio = pres.Audios[a];

                        string contentType = audio.ContentType;
                        string extension = "";
                        int slashIndex = contentType.LastIndexOf('/');
                        if (slashIndex >= 0 && slashIndex < contentType.Length - 1)
                        {
                            extension = contentType.Substring(slashIndex + 1);
                        }
                        string audioFileName = $"audio{a}.{extension}";

                        Console.WriteLine($"Audio: {audioFileName}");
                    }

                    // Save the presentation before exiting (no changes made)
                    pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (System.Net.WebException)
            {
                // External URL or web service failure
                Console.WriteLine("Failed to access an external resource.");
            }
        }
    }
}