using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export;
using System.Drawing;

namespace VideoFrameRenderer
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputVideoPath = "output.mp4";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file does not exist.");
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Create animations generator
                    using (Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
                    {
                        // Prepare ffmpeg process
                        ProcessStartInfo ffmpegInfo = new ProcessStartInfo();
                        ffmpegInfo.FileName = "ffmpeg";
                        ffmpegInfo.Arguments = $"-y -f image2pipe -vcodec png -i - -c:v libx264 -pix_fmt yuv420p \"{outputVideoPath}\"";
                        ffmpegInfo.UseShellExecute = false;
                        ffmpegInfo.RedirectStandardInput = true;
                        ffmpegInfo.CreateNoWindow = true;

                        using (Process ffmpegProcess = new Process())
                        {
                            ffmpegProcess.StartInfo = ffmpegInfo;
                            ffmpegProcess.Start();

                            using (Aspose.Slides.Export.PresentationPlayer player = new Aspose.Slides.Export.PresentationPlayer(animationsGenerator, 30))
                            {
                                player.FrameTick += (sender, eventArgs) =>
                                {
                                    using (MemoryStream frameStream = new MemoryStream())
                                    {
                                        // Save current frame as PNG to memory stream
                                        eventArgs.GetFrame().Save(frameStream, Aspose.Slides.ImageFormat.Png);
                                        byte[] frameBytes = frameStream.ToArray();

                                        // Write PNG bytes to ffmpeg stdin
                                        ffmpegProcess.StandardInput.BaseStream.Write(frameBytes, 0, frameBytes.Length);
                                        ffmpegProcess.StandardInput.BaseStream.Flush();
                                    }
                                };

                                // Run animation generation for all slides
                                animationsGenerator.Run(presentation.Slides);
                            }

                            // Signal end of input to ffmpeg
                            ffmpegProcess.StandardInput.BaseStream.Close();
                            ffmpegProcess.WaitForExit();
                        }
                    }

                    // Save presentation (no changes made, but required by rule)
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}