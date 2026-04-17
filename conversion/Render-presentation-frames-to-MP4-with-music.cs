using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Export;

namespace VideoWithBackgroundMusic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input files
            string presentationPath = "input.pptx";
            string backgroundMusicPath = "music.mp3";

            // Output settings
            string framesDirectory = "frames";
            string outputVideoPath = "output.mp4";
            string outputPresentationPath = "output.pptx";

            // Verify input files exist
            if (!File.Exists(presentationPath))
            {
                Console.WriteLine("Presentation file not found: " + presentationPath);
                return;
            }

            if (!File.Exists(backgroundMusicPath))
            {
                Console.WriteLine("Background music file not found: " + backgroundMusicPath);
                return;
            }

            // Ensure frames directory exists
            if (!Directory.Exists(framesDirectory))
            {
                Directory.CreateDirectory(framesDirectory);
            }

            try
            {
                // Load presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(presentationPath))
                {
                    // Create animations generator
                    using (Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
                    {
                        // Set frames per second
                        double fps = 30.0;

                        // Create player
                        using (Aspose.Slides.Export.PresentationPlayer player = new Aspose.Slides.Export.PresentationPlayer(animationsGenerator, fps))
                        {
                            int frameIndex = 0;

                            // Capture each frame as PNG
                            player.FrameTick += (sender, eventArgs) =>
                            {
                                string framePath = Path.Combine(framesDirectory, $"frame_{frameIndex:D5}.png");
                                eventArgs.GetFrame().Save(framePath);
                                frameIndex++;
                            };

                            // Run animation generation
                            animationsGenerator.Run(presentation.Slides);
                        }
                    }

                    // Save presentation before exit (even if unchanged)
                    presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                // Build ffmpeg arguments
                string ffmpegExecutable = "ffmpeg";
                string ffmpegArguments = $"-y -r 30 -i \"{Path.Combine(framesDirectory, "frame_%05d.png")}\" -i \"{backgroundMusicPath}\" -c:v libx264 -pix_fmt yuv420p -c:a aac -shortest \"{outputVideoPath}\"";

                // Start ffmpeg process
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = ffmpegExecutable,
                    Arguments = ffmpegArguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                try
                {
                    using (Process ffmpegProcess = Process.Start(startInfo))
                    {
                        ffmpegProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception for external tool invocation
                    Console.WriteLine("Error invoking ffmpeg: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}