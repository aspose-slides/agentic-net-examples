// -----------------------------------------------------------------------------
// Example: Stream large media BLOB data using C#
//
// Description:
// Demonstrates how to stream large media BLOB data (videos) from a PowerPoint
// presentation using Aspose.Slides for .NET. The example loads a PPTX file,
// extracts each embedded video as a stream, writes the video data to separate
// files, and then saves the presentation. This pattern can be used to handle
// large media BLOBs without loading the entire content into memory.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Stream, Large Media, Blob,
// Video Extraction, Presentation Processing, Office Automation
//
// Use Cases:
// - Extract and save embedded videos from PPTX files.
// - Process large media BLOBs in a memory‑efficient way.
// - Build tools that need to archive or analyze presentation media.
// - Automate PPTX workflows that involve media handling.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputFolder = "output_videos";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;

                using (Presentation pres = new Presentation(inputPath, loadOptions))
                {
                    byte[] buffer = new byte[8 * 1024];
                    for (int i = 0; i < pres.Videos.Count; i++)
                    {
                        IVideo video = pres.Videos[i];
                        using (Stream videoStream = video.GetStream())
                        {
                            string outputPath = Path.Combine(outputFolder, "video" + i + ".dat");
                            using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                            {
                                int bytesRead;
                                while ((bytesRead = videoStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    outputFile.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }

                    string savedPath = "saved_output.pptx";
                    pres.Save(savedPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
