using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VideoFrameRendering
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output video file
            string outputVideoPath = "output.mp4";
            // Temporary folder for frame images
            string framesFolder = "frames";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation file not found.");
                return;
            }

            // Ensure frames folder exists
            Directory.CreateDirectory(framesFolder);

            // Frames per second for rendering and encoding
            double fps = 30.0;
            int frameCounter = 0;

            // Load presentation and generate frames
            using (Presentation pres = new Presentation(inputPath))
            {
                using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(pres))
                {
                    using (PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps))
                    {
                        player.FrameTick += (sender, eventArgs) =>
                        {
                            string framePath = Path.Combine(framesFolder, $"frame_{frameCounter:D5}.png");
                            eventArgs.GetFrame().Save(framePath);
                            frameCounter++;
                        };

                        // Run animation generation for all slides
                        animationsGenerator.Run(pres.Slides);
                    }
                }

                // Save presentation (no modifications made)
                pres.Save("temp_output.pptx", SaveFormat.Pptx);
            }

            // Prepare ffmpeg arguments to encode frames into MP4
            string ffmpegArguments = $"-y -framerate {fps} -i \"{framesFolder}\\frame_%05d.png\" -c:v libx264 -pix_fmt yuv420p \"{outputVideoPath}\"";

            // Start ffmpeg process
            Process ffmpegProcess = new Process();
            ffmpegProcess.StartInfo.FileName = "ffmpeg";
            ffmpegProcess.StartInfo.Arguments = ffmpegArguments;
            ffmpegProcess.StartInfo.UseShellExecute = false;
            ffmpegProcess.StartInfo.RedirectStandardOutput = true;
            ffmpegProcess.StartInfo.RedirectStandardError = true;

            try
            {
                ffmpegProcess.Start();
                ffmpegProcess.WaitForExit();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // Handle errors such as ffmpeg not being installed or execution failure
                Console.WriteLine("FFmpeg execution failed: " + ex.Message);
            }

            // Optional: clean up temporary frames
            try
            {
                string[] frameFiles = Directory.GetFiles(framesFolder, "frame_*.png");
                foreach (string file in frameFiles)
                {
                    File.Delete(file);
                }
                Directory.Delete(framesFolder);
            }
            catch (Exception cleanupEx)
            {
                Console.WriteLine("Cleanup failed: " + cleanupEx.Message);
            }
        }
    }
}