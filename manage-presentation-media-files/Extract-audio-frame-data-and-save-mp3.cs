// -----------------------------------------------------------------------------
// Example: Extract audio frame data and save mp3 using C#
//
// Description:
// Demonstrates how to iterate through slides, locate embedded audio frames,
// extract their binary data and save each as an MP3 (or appropriate audio
// format) file using Aspose.Slides for .NET. The example also shows optional
// saving of the presentation after processing. This pattern can be used to
// automate audio extraction from PowerPoint files in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Extract, Audio, Frame, Data,
// Presentation Processing, Office Automation, MP3, BinaryData
//
// Use Cases:
// - Automate extraction of embedded audio from PPTX presentations.
// - Build tools that convert or archive audio assets from PowerPoint files.
// - Integrate audio processing into .NET workflows that handle Office documents.
// - Validate and inspect presentation media before publishing or further
//   transformation.
// -----------------------------------------------------------------------------
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
