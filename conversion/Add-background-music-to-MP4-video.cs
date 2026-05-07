using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path
        var inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation file does not exist.");
            return;
        }

        // Background audio path
        var audioPath = "background.mp3";
        if (!File.Exists(audioPath))
        {
            Console.WriteLine("Background audio file does not exist.");
            return;
        }

        // Output video path
        var outputVideoPath = "output.mp4";

        // Directory to store rendered frames
        var framesDir = "frames";
        if (!Directory.Exists(framesDir))
        {
            Directory.CreateDirectory(framesDir);
        }

        try
        {
            // Load presentation
            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Render animation frames
                using (var animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation))
                {
                    var fps = 30.0;
                    using (var player = new Aspose.Slides.Export.PresentationPlayer(animationsGenerator, fps))
                    {
                        var frameIndex = 0;
                        player.FrameTick += (sender, args) =>
                        {
                            var framePath = Path.Combine(framesDir, $"frame_{frameIndex++.ToString("D5")}.png");
                            args.GetFrame().Save(framePath);
                        };

                        animationsGenerator.Run(presentation.Slides);
                    }
                }

                // Save presentation before exit (optional)
                presentation.Save("temp.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }

            // Invoke ffmpeg to create MP4 with background music
            var ffmpegPath = "ffmpeg"; // Assumes ffmpeg is in PATH
            var ffmpegArgs = $"-y -r 30 -i \"{Path.Combine(framesDir, "frame_%05d.png")}\" -i \"{audioPath}\" -c:v libx264 -pix_fmt yuv420p -c:a aac -shortest \"{outputVideoPath}\"";

            var startInfo = new ProcessStartInfo
            {
                FileName = ffmpegPath,
                Arguments = ffmpegArgs,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    var output = process.StandardOutput.ReadToEnd();
                    var error = process.StandardError.ReadToEnd();
                    // Optionally log output and error
                }
            }
            catch (Exception ex)
            {
                // Handle exception related to external tool execution
                Console.WriteLine($"Error executing ffmpeg: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other processing errors
            // Format not supported
            Console.WriteLine($"Processing error: {ex.Message}");
        }
        finally
        {
            // Cleanup frames directory if needed
            // Directory.Delete(framesDir, true);
        }
    }
}