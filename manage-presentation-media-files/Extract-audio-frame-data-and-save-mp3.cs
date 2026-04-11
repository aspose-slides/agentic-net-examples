using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExtractAudio
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    int audioIndex = 0;

                    foreach (ISlide slide in presentation.Slides)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is IAudioFrame audioFrame && audioFrame.EmbeddedAudio != null)
                            {
                                IAudio audio = audioFrame.EmbeddedAudio;
                                byte[] data = audio.BinaryData;
                                string contentType = audio.ContentType ?? "audio/mpeg";
                                string extension = contentType.Substring(contentType.LastIndexOf('/') + 1);
                                if (extension.Equals("mpeg", StringComparison.OrdinalIgnoreCase))
                                    extension = "mp3";

                                string outputFile = $"audio_{audioIndex}.{extension}";
                                using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                                {
                                    fs.Write(data, 0, data.Length);
                                }

                                Console.WriteLine($"Extracted audio to {outputFile}");
                                audioIndex++;
                            }
                        }
                    }

                    // Save the presentation before exiting (optional)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported for PPT
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}